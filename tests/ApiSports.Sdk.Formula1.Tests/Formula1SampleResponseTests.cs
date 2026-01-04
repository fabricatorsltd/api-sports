using System.Text.Json;
using System.Text.Json.Serialization.Metadata;
using ApiSports.Sdk.Abstractions;
using ApiSports.Sdk.Formula1.Clients;
using ApiSports.Sdk.Formula1.Json;
using ApiSports.Sdk.Formula1.Models;
using ApiSports.Sdk.Formula1.Tests.Helpers;
using Xunit;

namespace ApiSports.Sdk.Formula1.Tests;

public sealed class Formula1SampleResponseTests
{
    public static IEnumerable<object[]> SampleEndpoints =>
        BuildSampleEndpoints().Select(endpoint => new object[] { endpoint });

    [SkippableTheory]
    [MemberData(nameof(SampleEndpoints))]
    public void SampleResponsesDeserializeWithoutErrors(ISampleEndpoint endpoint)
    {
        (bool found, string? json) = SampleJsonLoader.TryLoadFormula1Sample(endpoint.Definition.SamplePath);
        Skip.If(!found, $"Missing concrete sample json for {endpoint.Definition.Path}.");

        endpoint.AssertSample(json ?? string.Empty);
    }

    private static IEnumerable<ISampleEndpoint> BuildSampleEndpoints()
    {
        Formula1JsonSerializerContext context = Formula1JsonSerializerContext.Default;

        return
        [
            new SampleEndpoint<string[]>(GetDefinition(typeof(TimezoneClient), nameof(TimezoneClient.GetAsync)), context.ApiResponseStringArray),
            new SampleEndpoint<int[]>(GetDefinition(typeof(SeasonsClient), nameof(SeasonsClient.GetAsync)), context.ApiResponseInt32Array),
            new SampleEndpoint<ApiCompetitionResponse[]>(GetDefinition(typeof(CompetitionsClient), nameof(CompetitionsClient.GetAsync)), context.ApiResponseApiCompetitionResponseArray),
            new SampleEndpoint<ApiCircuitResponse[]>(GetDefinition(typeof(CircuitsClient), nameof(CircuitsClient.GetAsync)), context.ApiResponseApiCircuitResponseArray),
            new SampleEndpoint<ApiTeamResponse[]>(GetDefinition(typeof(TeamsClient), nameof(TeamsClient.GetAsync)), context.ApiResponseApiTeamResponseArray),
            new SampleEndpoint<ApiDriverResponse[]>(GetDefinition(typeof(DriversClient), nameof(DriversClient.GetAsync)), context.ApiResponseApiDriverResponseArray),
            new SampleEndpoint<ApiRaceResponse[]>(GetDefinition(typeof(RacesClient), nameof(RacesClient.GetAsync)), context.ApiResponseApiRaceResponseArray),
            new SampleEndpoint<ApiTeamRankingResponse[]>(GetDefinition(typeof(RankingsClient), nameof(RankingsClient.GetTeamsAsync)), context.ApiResponseApiTeamRankingResponseArray),
            new SampleEndpoint<ApiDriverRankingResponse[]>(GetDefinition(typeof(RankingsClient), nameof(RankingsClient.GetDriversAsync)), context.ApiResponseApiDriverRankingResponseArray),
            new SampleEndpoint<ApiRaceRankingResponse[]>(GetDefinition(typeof(RankingsClient), nameof(RankingsClient.GetRacesAsync)), context.ApiResponseApiRaceRankingResponseArray),
            new SampleEndpoint<ApiFastestLapRankingResponse[]>(GetDefinition(typeof(RankingsClient), nameof(RankingsClient.GetFastestLapsAsync)), context.ApiResponseApiFastestLapRankingResponseArray),
            new SampleEndpoint<ApiStartingGridRankingResponse[]>(GetDefinition(typeof(RankingsClient), nameof(RankingsClient.GetStartingGridAsync)), context.ApiResponseApiStartingGridRankingResponseArray),
            new SampleEndpoint<ApiPitStopResponse[]>(GetDefinition(typeof(PitStopsClient), nameof(PitStopsClient.GetAsync)), context.ApiResponseApiPitStopResponseArray)
        ];
    }

    private static EndpointDefinition GetDefinition(Type clientType, string methodName)
    {
        var key = new MethodKey(clientType, methodName);
        if (!Formula1EndpointCatalog.EndpointByMethod.TryGetValue(key, out EndpointDefinition? definition))
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
