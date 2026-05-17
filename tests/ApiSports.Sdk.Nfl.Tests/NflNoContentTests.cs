using System.Net;
using ApiSports.Sdk.Abstractions;
using ApiSports.Sdk.Core;
using ApiSports.Sdk.Nfl.Clients;
using ApiSports.Sdk.Nfl.Tests.Helpers;
using Xunit;

namespace ApiSports.Sdk.Nfl.Tests;

public sealed class NflNoContentTests
{
    [Fact]
    public async Task NoContentResponseDoesNotThrow()
    {
        var handler = new FakeHttpMessageHandler((_, _) =>
        {
            var response = new HttpResponseMessage(HttpStatusCode.NoContent)
            {
                Content = new ByteArrayContent([])
            };

            return Task.FromResult(response);
        });

        using var httpClient = new HttpClient(handler);
        httpClient.BaseAddress = new Uri("https://example.test");

        var apiClient = new ApiSportsHttpClient(httpClient);
        var timezoneClient = new TimezoneClient(apiClient);

        ApiResponse<string[]> result = await timezoneClient.GetAsync(CancellationToken.None);

        Assert.NotNull(result);
        Assert.Equal(0, result.Results);
        Assert.Null(result.Response);
        Assert.Null(result.Errors);
    }
}
