using System.Reflection;
using System.Runtime.CompilerServices;
using ApiSports.Sdk.Abstractions;
using ApiSports.Sdk.Formula1.Tests.Helpers;
using Xunit;
using YamlDotNet.RepresentationModel;

namespace ApiSports.Sdk.Formula1.Tests;

public sealed class Formula1OpenApiContractTests
{
    [Fact]
    public void PublicClientMethodsMatchOpenApiOperations()
    {
        YamlMappingNode root = LoadOpenApiRoot();
        YamlMappingNode paths = GetMapping(root, "paths");

        IReadOnlyList<MethodInfo> endpointMethods = Formula1EndpointCatalog.GetEndpointMethods();
        Assert.NotEmpty(endpointMethods);

        foreach (MethodInfo method in endpointMethods)
        {
            var key = new MethodKey(method.DeclaringType ?? throw new InvalidOperationException("Missing declaring type."), method.Name);
            Assert.True(Formula1EndpointCatalog.EndpointByMethod.TryGetValue(key, out EndpointDefinition? definition), $"Missing catalog entry for {key.ClientType.Name}.{key.MethodName}.");

            AssertApiResponseEnvelope(method);

            YamlMappingNode pathItem = GetMapping(paths, definition.Path);
            YamlMappingNode operation = GetMapping(pathItem, definition.HttpMethod);

            YamlMappingNode responses = GetMapping(operation, "responses");
            Assert.True(responses.Children.Count > 0, $"OpenAPI operation {definition.Path} {definition.HttpMethod} defines no responses.");
        }
    }

    [Fact]
    public void CatalogEntriesCorrespondToClientMethods()
    {
        IReadOnlyList<MethodInfo> endpointMethods = Formula1EndpointCatalog.GetEndpointMethods();
        var methodKeys = endpointMethods
            .Select(method => new MethodKey(method.DeclaringType ?? throw new InvalidOperationException("Missing declaring type."), method.Name))
            .ToHashSet();

        foreach (EndpointDefinition definition in Formula1EndpointCatalog.Endpoints)
        {
            var key = new MethodKey(definition.ClientType, definition.MethodName);
            Assert.Contains(key, methodKeys);
        }
    }

    [Fact]
    public void RequiredQueryParametersAreRequiredOnQueries()
    {
        YamlMappingNode root = LoadOpenApiRoot();
        YamlMappingNode paths = GetMapping(root, "paths");

        foreach (EndpointDefinition definition in Formula1EndpointCatalog.Endpoints)
        {
            MethodInfo method = GetMethod(definition);

            YamlMappingNode pathItem = GetMapping(paths, definition.Path);
            YamlMappingNode operation = GetMapping(pathItem, definition.HttpMethod);
            IReadOnlyList<OpenApiParameter> queryParameters = GetQueryParameters(operation);

            OpenApiParameter[] requiredParameters = queryParameters
                .Where(parameter => parameter.Required)
                .ToArray();

            if (requiredParameters.Length == 0)
            {
                continue;
            }

            ParameterInfo? queryParameter = method.GetParameters()
                .FirstOrDefault(parameter => typeof(IQueryString).IsAssignableFrom(parameter.ParameterType));

            Assert.NotNull(queryParameter);

            Type queryType = queryParameter!.ParameterType;

            foreach (OpenApiParameter parameter in requiredParameters)
            {
                string propertyName = ToPascalCase(parameter.Name);
                PropertyInfo? property = queryType.GetProperty(propertyName, BindingFlags.Instance | BindingFlags.Public);
                Assert.NotNull(property);

                bool isRequired = property!.CustomAttributes
                    .Any(attribute => attribute.AttributeType == typeof(RequiredMemberAttribute));

                Assert.True(isRequired, $"Expected {queryType.Name}.{propertyName} to be required for {definition.Path}.");
            }
        }
    }

    private static MethodInfo GetMethod(EndpointDefinition definition)
    {
        MethodInfo? method = definition.ClientType.GetMethod(definition.MethodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.DeclaredOnly);
        return method ?? throw new InvalidOperationException($"Missing method {definition.ClientType.Name}.{definition.MethodName}.");
    }

    private static IReadOnlyList<OpenApiParameter> GetQueryParameters(YamlMappingNode operation)
    {
        foreach (KeyValuePair<YamlNode, YamlNode> child in operation.Children)
        {
            if (child.Key is not YamlScalarNode { Value: not null } scalar ||
                !string.Equals(scalar.Value, "parameters", StringComparison.OrdinalIgnoreCase))
            {
                continue;
            }

            if (child.Value is not YamlSequenceNode sequence)
            {
                return [];
            }

            var parameters = new List<OpenApiParameter>();
            foreach (YamlNode entry in sequence)
            {
                if (entry is not YamlMappingNode mapping)
                {
                    continue;
                }

                string? location = GetScalarValue(mapping, "in");
                if (!string.Equals(location, "query", StringComparison.OrdinalIgnoreCase))
                {
                    continue;
                }

                string? name = GetScalarValue(mapping, "name");
                if (string.IsNullOrWhiteSpace(name))
                {
                    continue;
                }

                bool required = false;
                string? requiredRaw = GetScalarValue(mapping, "required");
                if (bool.TryParse(requiredRaw, out bool parsed))
                {
                    required = parsed;
                }

                parameters.Add(new OpenApiParameter(name, required));
            }

            return parameters;
        }

        return [];
    }

    private static string? GetScalarValue(YamlMappingNode mapping, string key)
    {
        foreach (KeyValuePair<YamlNode, YamlNode> child in mapping.Children)
        {
            if (child.Key is not YamlScalarNode { Value: not null } scalar ||
                !string.Equals(scalar.Value, key, StringComparison.OrdinalIgnoreCase))
            {
                continue;
            }

            if (child.Value is YamlScalarNode value)
            {
                return value.Value;
            }
        }

        return null;
    }

    private static void AssertApiResponseEnvelope(MethodInfo method)
    {
        Type returnType = method.ReturnType;
        Assert.True(returnType.IsGenericType, $"Expected {method.Name} to return Task<ApiResponse<T>>.");
        Assert.Equal(typeof(Task<>), returnType.GetGenericTypeDefinition());

        Type resultType = returnType.GetGenericArguments()[0];
        Assert.True(resultType.IsGenericType, $"Expected {method.Name} to return Task<ApiResponse<T>>.");
        Assert.Equal(typeof(ApiResponse<>), resultType.GetGenericTypeDefinition());
    }

    private static string ToPascalCase(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            return value;
        }

        string[] parts = value.Split(['_', '-'], StringSplitOptions.RemoveEmptyEntries);
        string result = string.Concat(parts.Select(part => char.ToUpperInvariant(part[0]) + part[1..]));
        return result;
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

    private sealed record OpenApiParameter(string Name, bool Required);
}
