using System.Net;
using ApiSports.Sdk.Abstractions;
using ApiSports.Sdk.Core;
using ApiSports.Sdk.Football.Clients;
using ApiSports.Sdk.Football.Tests.Helpers;
using Xunit;

namespace ApiSports.Sdk.Football.Tests;

public sealed class FootballNoContentTests
{
    [Fact]
    public async Task NoContentResponseDoesNotThrow()
    {
        using var handler = new FakeHttpMessageHandler((_, _) =>
        {
            HttpResponseMessage response = new(HttpStatusCode.NoContent)
            {
                Content = new ByteArrayContent(Array.Empty<byte>())
            };

            return Task.FromResult(response);
        });

        using var httpClient = new HttpClient(handler);
        httpClient.BaseAddress = new Uri("https://example.test");

        var apiClient = new ApiSportsHttpClient(httpClient);
        var statusClient = new StatusClient(apiClient);

        ApiResponse<Models.Status> result = await statusClient.GetAsync(CancellationToken.None);

        Assert.NotNull(result);
        Assert.Equal(0, result.Results);
        Assert.Null(result.Response);
        Assert.Null(result.Errors);
    }
}
