using System.Text.Json;
using System.Text.Json.Serialization.Metadata;
using ApiSports.Sdk.Abstractions;
using ApiSports.Sdk.Abstractions.Models.Common;
using ApiSports.Sdk.Rugby.Clients;
using ApiSports.Sdk.Rugby.Json;
using ApiSports.Sdk.Rugby.Models;
using ApiSports.Sdk.Rugby.Tests.Helpers;
using Xunit;

namespace ApiSports.Sdk.Rugby.Tests;

public sealed class RugbySampleResponseTests
{
    public static IEnumerable<object[]> SampleEndpoints =>
        BuildSampleEndpoints().Select(endpoint => new object[] { endpoint });

    [SkippableTheory]
    [MemberData(nameof(SampleEndpoints))]
    public void SampleResponsesDeserializeWithoutErrors(ISampleEndpoint endpoint)
    {
        (bool found, string? json) = SampleJsonLoader.TryLoadRugbySample(endpoint.Definition.SamplePath);
        Skip.If(!found, $"Missing concrete sample json for {endpoint.Definition.Path}.");

        endpoint.AssertSample(json ?? string.Empty);
    }

    private static IEnumerable<ISampleEndpoint> BuildSampleEndpoints()
    {
        RugbyJsonSerializerContext context = RugbyJsonSerializerContext.Default;

        return
        [
            new SampleEndpoint<StatusResponse>(GetDefinition(typeof(StatusClient), nameof(StatusClient.GetAsync)), context.ApiResponseStatusResponse),
            new SampleEndpoint<string[]>(GetDefinition(typeof(TimezoneClient), nameof(TimezoneClient.GetAsync)), context.ApiResponseStringArray),
            new SampleEndpoint<int[]>(GetDefinition(typeof(SeasonsClient), nameof(SeasonsClient.GetAsync)), context.ApiResponseInt32Array),
            new SampleEndpoint<Country[]>(GetDefinition(typeof(CountriesClient), nameof(CountriesClient.GetAsync)), context.ApiResponseCountryArray),
            new SampleEndpoint<League[]>(GetDefinition(typeof(LeaguesClient), nameof(LeaguesClient.GetAsync)), context.ApiResponseLeagueArray),
            new SampleEndpoint<Team[]>(GetDefinition(typeof(TeamsClient), nameof(TeamsClient.GetAsync)), context.ApiResponseTeamArray),
            new SampleEndpoint<TeamStatisticsResponse>(GetDefinition(typeof(TeamsClient), nameof(TeamsClient.GetStatisticsAsync)), context.ApiResponseTeamStatisticsResponse),
            new SampleEndpoint<Standing[][]>(GetDefinition(typeof(StandingsClient), nameof(StandingsClient.GetAsync)), context.ApiResponseStandingArrayArray),
            new SampleEndpoint<string[]>(GetDefinition(typeof(StandingsClient), nameof(StandingsClient.GetStagesAsync)), context.ApiResponseStringArray),
            new SampleEndpoint<string[]>(GetDefinition(typeof(StandingsClient), nameof(StandingsClient.GetGroupsAsync)), context.ApiResponseStringArray),
            new SampleEndpoint<Game[]>(GetDefinition(typeof(GamesClient), nameof(GamesClient.GetAsync)), context.ApiResponseGameArray),
            new SampleEndpoint<Game[]>(GetDefinition(typeof(GamesClient), nameof(GamesClient.GetHeadToHeadAsync)), context.ApiResponseGameArray),
            new SampleEndpoint<OddsResponse[]>(GetDefinition(typeof(OddsClient), nameof(OddsClient.GetAsync)), context.ApiResponseOddsResponseArray),
            new SampleEndpoint<BetDefinition[]>(GetDefinition(typeof(OddsClient), nameof(OddsClient.GetBetsAsync)), context.ApiResponseBetDefinitionArray),
            new SampleEndpoint<BookmakerDefinition[]>(GetDefinition(typeof(OddsClient), nameof(OddsClient.GetBookmakersAsync)), context.ApiResponseBookmakerDefinitionArray),
        ];
    }

    private static EndpointDefinition GetDefinition(Type clientType, string methodName)
    {
        var key = new MethodKey(clientType, methodName);
        if (!RugbyEndpointCatalog.EndpointByMethod.TryGetValue(key, out EndpointDefinition? definition))
        {
            throw new InvalidOperationException($"Missing endpoint definition for {clientType.Name}.{methodName}.");
        }

        return definition;
    }

    private static void AssertEnvelope<TResponse>(string json, JsonTypeInfo<ApiResponse<TResponse>> typeInfo)
    {
        ApiResponse<TResponse>? parsed = JsonSerializer.Deserialize(json, typeInfo);
        Assert.NotNull(parsed);
        AssertEnvelope(parsed);
    }

    private static void AssertEnvelope<TResponse>(ApiResponse<TResponse> parsed)
    {
        Assert.True(parsed.Results >= 0);
        if (parsed.Results > 0)
        {
            Assert.NotNull(parsed.Response);
        }

        if (parsed.Paging is not null)
        {
            Assert.True(parsed.Paging.Current >= 0);
            Assert.True(parsed.Paging.Total >= parsed.Paging.Current);
        }

        Assert.False(HasErrors(parsed.Errors));
    }

    private static bool HasErrors(JsonElement? errors)
    {
        if (!errors.HasValue)
        {
            return false;
        }

        JsonElement element = errors.Value;
        if (element.ValueKind == JsonValueKind.Array)
        {
            return element.GetArrayLength() > 0;
        }

        if (element.ValueKind == JsonValueKind.Object)
        {
            return element.EnumerateObject().Any();
        }

        if (element.ValueKind == JsonValueKind.String)
        {
            string? value = element.GetString();
            return !string.IsNullOrWhiteSpace(value);
        }

        return false;
    }

    public interface ISampleEndpoint
    {
        EndpointDefinition Definition { get; }

        void AssertSample(string json);
    }

    private sealed class SampleEndpoint<TResponse> : ISampleEndpoint
    {
        private readonly JsonTypeInfo<ApiResponse<TResponse>> _typeInfo;

        public SampleEndpoint(EndpointDefinition definition, JsonTypeInfo<ApiResponse<TResponse>> typeInfo)
        {
            Definition = definition;
            _typeInfo = typeInfo;
        }

        public EndpointDefinition Definition { get; }

        public void AssertSample(string json)
        {
            AssertEnvelope(json, _typeInfo);
        }
    }
}
