using System.Reflection;
using ApiSports.Sdk.Football.Tests.Helpers;
using Xunit;
using YamlDotNet.RepresentationModel;

namespace ApiSports.Sdk.Football.Tests;

public sealed class FootballOpenApiContractTests
{
    [Fact]
    public void PublicClientMethodsMatchOpenApiOperations()
    {
        YamlMappingNode root = LoadOpenApiRoot();
        YamlMappingNode paths = GetMapping(root, "paths");

        IReadOnlyList<MethodInfo> endpointMethods = FootballEndpointCatalog.GetEndpointMethods();
        Assert.NotEmpty(endpointMethods);

        bool hasNoContentResponse = false;

        foreach (MethodInfo method in endpointMethods)
        {
            MethodKey key = new(method.DeclaringType ?? throw new InvalidOperationException("Missing declaring type."), method.Name);
            Assert.True(FootballEndpointCatalog.EndpointByMethod.TryGetValue(key, out EndpointDefinition? definition), $"Missing catalog entry for {key.ClientType.Name}.{key.MethodName}.");

            if (definition.Path == "/status")
            {
                // OpenApi spec does not define this endpoint.
                continue;
            }
            
            YamlMappingNode pathItem = GetMapping(paths, definition.Path);
            YamlMappingNode operation = GetMapping(pathItem, definition.HttpMethod);

            YamlMappingNode responses = GetMapping(operation, "responses");
            Assert.True(responses.Children.Count > 0, $"OpenAPI operation {definition.Path} {definition.HttpMethod} defines no responses.");

            if (responses.Children.Keys.OfType<YamlScalarNode>().Any(node => string.Equals(node.Value, "204", StringComparison.OrdinalIgnoreCase)))
            {
                hasNoContentResponse = true;
            }
        }

        Assert.True(hasNoContentResponse, "Expected OpenAPI to define at least one 204 response.");
    }

    [Fact]
    public void CatalogEntriesCorrespondToClientMethods()
    {
        IReadOnlyList<MethodInfo> endpointMethods = FootballEndpointCatalog.GetEndpointMethods();
        var methodKeys = endpointMethods
            .Select(method => new MethodKey(method.DeclaringType ?? throw new InvalidOperationException("Missing declaring type."), method.Name))
            .ToHashSet();

        foreach (EndpointDefinition definition in FootballEndpointCatalog.Endpoints)
        {
            MethodKey key = new(definition.ClientType, definition.MethodName);
            Assert.Contains(key, methodKeys);
        }
    }

    private static YamlMappingNode LoadOpenApiRoot()
    {
        string yaml = File.ReadAllText(SamplePaths.OpenApiPath);
        var stream = new YamlStream();
        using var reader = new StringReader(yaml);
        stream.Load(reader);
        return (YamlMappingNode)stream.Documents[0].RootNode;
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
