using System.Text.Json;
using System.Text.Json.Serialization.Metadata;
using ApiSports.Sdk.Abstractions;
using ApiSports.Sdk.Football.Clients;
using ApiSports.Sdk.Football.Models;
using ApiSports.Sdk.Football.Tests.Helpers;
using ApiSports.Sdk.Football.Tests.Serialization;
using Xunit;

namespace ApiSports.Sdk.Football.Tests;

public sealed class FootballSampleResponseTests
{
    public static IEnumerable<object[]> SampleEndpoints =>
        BuildSampleEndpoints().Select(endpoint => new object[] { endpoint });

    [SkippableTheory]
    [MemberData(nameof(SampleEndpoints))]
    public void SampleResponsesDeserializeWithoutErrors(ISampleEndpoint endpoint)
    {
        (bool found, string? json) = SampleJsonLoader.TryLoadFootballSample(endpoint.Definition.SamplePath);
        Skip.If(!found, $"Missing concrete sample json for {endpoint.Definition.Path}.");

        endpoint.AssertSample(json ?? string.Empty);
    }

    [SkippableFact]
    public void TeamCodeIsDeserializedFromTheOfficialSample()
    {
        (bool found, string? json) = SampleJsonLoader.TryLoadFootballSample("teams/teams.json");
        Skip.If(!found, "Missing concrete sample json for /teams.");

        ApiResponse<ApiTeamResponse[]>? parsed = JsonSerializer.Deserialize(
            json ?? string.Empty,
            FootballJsonContext.Default.ApiResponseApiTeamResponseArray);

        Assert.Equal("LAZ", parsed?.Response?.FirstOrDefault()?.Team.Code);
    }

    [Fact]
    public void FixtureExtraAndStandingsAreDeserializedFromTheOfficialSample()
    {
        (bool found, string? json) = SampleJsonLoader.TryLoadFootballSample("fixtures/fixtures.json");
        Assert.True(found, "Missing concrete sample json for /fixtures.");

        ApiResponse<FixtureResponse[]>? parsed = JsonSerializer.Deserialize(
            json ?? string.Empty,
            FootballJsonContext.Default.ApiResponseFixtureResponseArray);

        FixtureResponse fixture = Assert.IsType<FixtureResponse>(parsed?.Response?.FirstOrDefault());
        Assert.Equal((ushort)1, fixture.Fixture.Status?.Extra);
        Assert.True(fixture.League.Standings);
    }

    [Fact]
    public void DatedRoundsAreDeserializedFromTheOfficialExample()
    {
        (bool found, string? json) = SampleJsonLoader.TryLoadFootballSample("fixtures/rounds-with-dates.json");
        Assert.True(found, "Missing concrete sample json for /fixtures/rounds?dates=true.");

        ApiResponse<FixtureRound[]>? parsed = JsonSerializer.Deserialize(
            json ?? string.Empty,
            FootballJsonContext.Default.ApiResponseFixtureRoundArray);

        FixtureRound first = Assert.IsType<FixtureRound>(parsed?.Response?.FirstOrDefault());
        Assert.Equal("Regular Season - 1", first.Round);
        Assert.Equal(new DateOnly(2024, 8, 16), first.Dates[0]);
    }

    [Fact]
    public void ApiFootball393EndpointAndStatisticsAdditionsAreDeserialized()
    {
        (bool profileFound, string? profileJson) = SampleJsonLoader.TryLoadFootballSample("players/profiles.json");
        (bool teamsFound, string? teamsJson) = SampleJsonLoader.TryLoadFootballSample("players/teams.json");
        (bool statisticsFound, string? statisticsJson) = SampleJsonLoader.TryLoadFootballSample("teams/statistics.json");
        Assert.True(profileFound && teamsFound && statisticsFound, "Missing API-Football 3.9.3 response examples.");

        ApiResponse<PlayerProfileResponse[]>? profiles = JsonSerializer.Deserialize(
            profileJson ?? string.Empty,
            FootballJsonContext.Default.ApiResponsePlayerProfileResponseArray);
        ApiResponse<PlayerTeamResponse[]>? teams = JsonSerializer.Deserialize(
            teamsJson ?? string.Empty,
            FootballJsonContext.Default.ApiResponsePlayerTeamResponseArray);
        ApiResponse<TeamStatisticsResponse>? statistics = JsonSerializer.Deserialize(
            statisticsJson ?? string.Empty,
            FootballJsonContext.Default.ApiResponseTeamStatisticsResponse);

        Assert.Equal((uint)276, profiles?.Response?.FirstOrDefault()?.Player.Id);
        Assert.Contains(2018, teams?.Response?.FirstOrDefault()?.Seasons ?? []);
        Assert.Equal(12, statistics?.Response?.Goals.For.UnderOver["0.5"].Over);
        Assert.Equal(6, statistics?.Response?.Goals.For.UnderOver["0.5"].Under);
    }

    private static IEnumerable<ISampleEndpoint> BuildSampleEndpoints()
    {
        FootballJsonContext context = FootballJsonContext.Default;

        return
        [
            new SampleEndpoint<Status>(GetDefinition(typeof(StatusClient), nameof(StatusClient.GetAsync)), context.ApiResponseStatus),
            new SampleEndpoint<FixtureResponse[]>(GetDefinition(typeof(FixturesClient), nameof(FixturesClient.GetAsync)), context.ApiResponseFixtureResponseArray),
            new SampleEndpoint<string[]>(GetDefinition(typeof(FixturesClient), nameof(FixturesClient.GetRoundsAsync)), context.ApiResponseStringArray),
            new SampleEndpoint<FixtureRound[]>(GetDefinition(typeof(FixturesClient), nameof(FixturesClient.GetRoundsWithDatesAsync)), context.ApiResponseFixtureRoundArray),
            new SampleEndpoint<HeadToHead[]>(GetDefinition(typeof(FixturesClient), nameof(FixturesClient.GetHeadToHeadAsync)), context.ApiResponseHeadToHeadArray),
            new SampleEndpoint<FixtureStatisticsResponse[]>(GetDefinition(typeof(FixturesClient), nameof(FixturesClient.GetStatisticsAsync)), context.ApiResponseFixtureStatisticsResponseArray),
            new SampleEndpoint<FixtureEvent[]>(GetDefinition(typeof(FixturesClient), nameof(FixturesClient.GetEventsAsync)), context.ApiResponseFixtureEventArray),
            new SampleEndpoint<FixtureLineupResponse[]>(GetDefinition(typeof(FixturesClient), nameof(FixturesClient.GetLineupsAsync)), context.ApiResponseFixtureLineupResponseArray),
            new SampleEndpoint<FixturePlayerResponse[]>(GetDefinition(typeof(FixturesClient), nameof(FixturesClient.GetPlayersAsync)), context.ApiResponseFixturePlayerResponseArray),
            new SampleEndpoint<ApiLeagueResponse[]>(GetDefinition(typeof(LeaguesClient), nameof(LeaguesClient.GetAsync)), context.ApiResponseApiLeagueResponseArray),
            new SampleEndpoint<int[]>(GetDefinition(typeof(LeaguesClient), nameof(LeaguesClient.GetSeasonsAsync)), context.ApiResponseInt32Array),
            new SampleEndpoint<ApiTeamResponse[]>(GetDefinition(typeof(TeamsClient), nameof(TeamsClient.GetAsync)), context.ApiResponseApiTeamResponseArray),
            new SampleEndpoint<TeamStatisticsResponse>(GetDefinition(typeof(TeamsClient), nameof(TeamsClient.GetStatisticsAsync)), context.ApiResponseTeamStatisticsResponse),
            new SampleEndpoint<int[]>(GetDefinition(typeof(TeamsClient), nameof(TeamsClient.GetSeasonsAsync)), context.ApiResponseInt32Array),
            new SampleEndpoint<Country[]>(GetDefinition(typeof(TeamsClient), nameof(TeamsClient.GetCountriesAsync)), context.ApiResponseCountryArray),
            new SampleEndpoint<ApiPlayerResponse[]>(GetDefinition(typeof(PlayersClient), nameof(PlayersClient.GetAsync)), context.ApiResponseApiPlayerResponseArray),
            new SampleEndpoint<int[]>(GetDefinition(typeof(PlayersClient), nameof(PlayersClient.GetSeasonsAsync)), context.ApiResponseInt32Array),
            new SampleEndpoint<PlayerProfileResponse[]>(GetDefinition(typeof(PlayersClient), nameof(PlayersClient.GetProfilesAsync)), context.ApiResponsePlayerProfileResponseArray),
            new SampleEndpoint<PlayerSquadResponse[]>(GetDefinition(typeof(PlayersClient), nameof(PlayersClient.GetSquadsAsync)), context.ApiResponsePlayerSquadResponseArray),
            new SampleEndpoint<PlayerTeamResponse[]>(GetDefinition(typeof(PlayersClient), nameof(PlayersClient.GetTeamsAsync)), context.ApiResponsePlayerTeamResponseArray),
            new SampleEndpoint<ApiPlayerResponse[]>(GetDefinition(typeof(PlayersClient), nameof(PlayersClient.GetTopScorersAsync)), context.ApiResponseApiPlayerResponseArray),
            new SampleEndpoint<ApiPlayerResponse[]>(GetDefinition(typeof(PlayersClient), nameof(PlayersClient.GetTopAssistsAsync)), context.ApiResponseApiPlayerResponseArray),
            new SampleEndpoint<ApiPlayerResponse[]>(GetDefinition(typeof(PlayersClient), nameof(PlayersClient.GetTopYellowCardsAsync)), context.ApiResponseApiPlayerResponseArray),
            new SampleEndpoint<ApiPlayerResponse[]>(GetDefinition(typeof(PlayersClient), nameof(PlayersClient.GetTopRedCardsAsync)), context.ApiResponseApiPlayerResponseArray),
            new SampleEndpoint<ApiPredictionsResponse[]>(GetDefinition(typeof(PredictionsClient), nameof(PredictionsClient.GetAsync)), context.ApiResponseApiPredictionsResponseArray),
            new SampleEndpoint<OddsResponse[]>(GetDefinition(typeof(OddsClient), nameof(OddsClient.GetAsync)), context.ApiResponseOddsResponseArray),
            new SampleEndpoint<OddsResponse[]>(GetDefinition(typeof(OddsClient), nameof(OddsClient.GetLiveAsync)), context.ApiResponseOddsResponseArray),
            new SampleEndpoint<OddsBetResponse[]>(GetDefinition(typeof(OddsClient), nameof(OddsClient.GetLiveBetsAsync)), context.ApiResponseOddsBetResponseArray),
            new SampleEndpoint<OddsMappingResponse[]>(GetDefinition(typeof(OddsClient), nameof(OddsClient.GetMappingAsync)), context.ApiResponseOddsMappingResponseArray),
            new SampleEndpoint<OddsBookmakerResponse[]>(GetDefinition(typeof(OddsClient), nameof(OddsClient.GetBookmakersAsync)), context.ApiResponseOddsBookmakerResponseArray),
            new SampleEndpoint<OddsBetResponse[]>(GetDefinition(typeof(OddsClient), nameof(OddsClient.GetBetsAsync)), context.ApiResponseOddsBetResponseArray),
            new SampleEndpoint<ApiStandingsResponse[]>(GetDefinition(typeof(StandingsClient), nameof(StandingsClient.GetAsync)), context.ApiResponseApiStandingsResponseArray),
            new SampleEndpoint<Injury[]>(GetDefinition(typeof(InjuriesClient), nameof(InjuriesClient.GetAsync)), context.ApiResponseInjuryArray),
            new SampleEndpoint<TransferResponse[]>(GetDefinition(typeof(TransfersClient), nameof(TransfersClient.GetAsync)), context.ApiResponseTransferResponseArray),
            new SampleEndpoint<Coach[]>(GetDefinition(typeof(CoachsClient), nameof(CoachsClient.GetAsync)), context.ApiResponseCoachArray),
            new SampleEndpoint<TrophyResponse[]>(GetDefinition(typeof(TrophiesClient), nameof(TrophiesClient.GetAsync)), context.ApiResponseTrophyResponseArray),
            new SampleEndpoint<SidelinedResponse[]>(GetDefinition(typeof(SidelinedClient), nameof(SidelinedClient.GetAsync)), context.ApiResponseSidelinedResponseArray),
            new SampleEndpoint<Country[]>(GetDefinition(typeof(CountriesClient), nameof(CountriesClient.GetAsync)), context.ApiResponseCountryArray),
            new SampleEndpoint<Venue[]>(GetDefinition(typeof(VenuesClient), nameof(VenuesClient.GetAsync)), context.ApiResponseVenueArray),
            new SampleEndpoint<string[]>(GetDefinition(typeof(TimezoneClient), nameof(TimezoneClient.GetAsync)), context.ApiResponseStringArray)
        ];
    }

    private static EndpointDefinition GetDefinition(Type clientType, string methodName)
    {
        MethodKey key = new(clientType, methodName);
        return !FootballEndpointCatalog.EndpointByMethod.TryGetValue(key, out EndpointDefinition? definition) ?
            throw new InvalidOperationException($"Missing endpoint definition for {clientType.Name}.{methodName}.") :
            definition;
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
        switch (element.ValueKind)
        {
            case JsonValueKind.Array:
                return element.GetArrayLength() > 0;
            case JsonValueKind.Object:
                return element.EnumerateObject().Any();
            case JsonValueKind.String:
                {
                    string? value = element.GetString();
                    return !string.IsNullOrWhiteSpace(value);
                }
            default:
                return false;
        }
    }

    public interface ISampleEndpoint
    {
        EndpointDefinition Definition { get; }

        void AssertSample(string json);
    }

    private sealed class SampleEndpoint<TResponse>(
        EndpointDefinition definition,
        JsonTypeInfo<ApiResponse<TResponse>> typeInfo)
        : ISampleEndpoint
    {
        public EndpointDefinition Definition { get; } = definition;

        public void AssertSample(string json)
        {
            AssertEnvelope(json, typeInfo);
        }
    }
}
