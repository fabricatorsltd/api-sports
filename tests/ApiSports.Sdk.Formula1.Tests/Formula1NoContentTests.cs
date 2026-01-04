using System.Net;
using ApiSports.Sdk.Abstractions;
using ApiSports.Sdk.Core;
using ApiSports.Sdk.Formula1.Clients;
using ApiSports.Sdk.Formula1.Tests.Helpers;
using Xunit;
using YamlDotNet.RepresentationModel;

namespace ApiSports.Sdk.Formula1.Tests;

public sealed class Formula1NoContentTests
{
    [SkippableFact]
    public async Task NoContentResponseDoesNotThrow()
    {
        Skip.If(!HasNoContentResponse(), "OpenAPI defines no 204 responses.");

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

    private static bool HasNoContentResponse()
    {
        string yaml = File.ReadAllText(SamplePaths.OpenApiPath);
        var stream = new YamlStream();
        using var reader = new StringReader(yaml);
        stream.Load(reader);
        var root = (YamlMappingNode)stream.Documents[0].RootNode;
        YamlMappingNode paths = GetMapping(root, "paths");

        foreach (KeyValuePair<YamlNode, YamlNode> pathEntry in paths.Children)
        {
            if (pathEntry.Value is not YamlMappingNode pathItem)
            {
                continue;
            }

            foreach (KeyValuePair<YamlNode, YamlNode> operationEntry in pathItem.Children)
            {
                if (operationEntry.Value is not YamlMappingNode operation)
                {
                    continue;
                }

                YamlMappingNode responses = GetMapping(operation, "responses");
                bool hasNoContent = responses.Children.Keys
                    .OfType<YamlScalarNode>()
                    .Any(node => string.Equals(node.Value, "204", StringComparison.OrdinalIgnoreCase));

                if (hasNoContent)
                {
                    return true;
                }
            }
        }

        return false;
    }

    private static YamlMappingNode GetMapping(YamlMappingNode parent, string key)
    {
        foreach (KeyValuePair<YamlNode, YamlNode> child in parent.Children)
        {
            if (child.Key is not YamlScalarNode { Value: not null } scalar ||
                !string.Equals(scalar.Value, key, StringComparison.OrdinalIgnoreCase))
            {
                continue;
            }

            if (child.Value is YamlMappingNode mapping)
            {
                return mapping;
            }
        }

        throw new InvalidOperationException($"Missing mapping node '{key}'.");
    }
}
