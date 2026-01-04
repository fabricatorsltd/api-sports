using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using ApiSports.Sdk.Football;
using ApiSports.Sdk.Football.Clients;

namespace ApiSports.Sdk.Football.Tests;

public static class FootballEndpointCatalog
{
    public static IReadOnlyList<EndpointDefinition> Endpoints { get; } =
    [
        new EndpointDefinition(typeof(StatusClient), nameof(StatusClient.GetAsync), "/status", "get", "status.json"),
        new EndpointDefinition(typeof(FixturesClient), nameof(FixturesClient.GetAsync), "/fixtures", "get", "fixtures/fixtures.json"),
        new EndpointDefinition(typeof(FixturesClient), nameof(FixturesClient.GetRoundsAsync), "/fixtures/rounds", "get", "fixtures/rounds.json"),
        new EndpointDefinition(typeof(FixturesClient), nameof(FixturesClient.GetHeadToHeadAsync), "/fixtures/headtohead", "get", "fixtures/headtohead.json"),
        new EndpointDefinition(typeof(FixturesClient), nameof(FixturesClient.GetStatisticsAsync), "/fixtures/statistics", "get", "fixtures/statistics.json"),
        new EndpointDefinition(typeof(FixturesClient), nameof(FixturesClient.GetEventsAsync), "/fixtures/events", "get", "fixtures/events.json"),
        new EndpointDefinition(typeof(FixturesClient), nameof(FixturesClient.GetLineupsAsync), "/fixtures/lineups", "get", "fixtures/lineups.json"),
        new EndpointDefinition(typeof(FixturesClient), nameof(FixturesClient.GetPlayersAsync), "/fixtures/players", "get", "fixtures/players.json"),
        new EndpointDefinition(typeof(LeaguesClient), nameof(LeaguesClient.GetAsync), "/leagues", "get", "leagues/leagues.json"),
        new EndpointDefinition(typeof(LeaguesClient), nameof(LeaguesClient.GetSeasonsAsync), "/leagues/seasons", "get", "leagues/seasons.json"),
        new EndpointDefinition(typeof(TeamsClient), nameof(TeamsClient.GetAsync), "/teams", "get", "teams/teams.json"),
        new EndpointDefinition(typeof(TeamsClient), nameof(TeamsClient.GetStatisticsAsync), "/teams/statistics", "get", "teams/statistics.json"),
        new EndpointDefinition(typeof(TeamsClient), nameof(TeamsClient.GetSeasonsAsync), "/teams/seasons", "get", "teams/seasons.json"),
        new EndpointDefinition(typeof(TeamsClient), nameof(TeamsClient.GetCountriesAsync), "/teams/countries", "get", "teams/countries.json"),
        new EndpointDefinition(typeof(PlayersClient), nameof(PlayersClient.GetAsync), "/players", "get", "players/players.json"),
        new EndpointDefinition(typeof(PlayersClient), nameof(PlayersClient.GetSeasonsAsync), "/players/seasons", "get", "players/seasons.json"),
        new EndpointDefinition(typeof(PlayersClient), nameof(PlayersClient.GetProfilesAsync), "/players/profiles", "get", "players/players.json"),
        new EndpointDefinition(typeof(PlayersClient), nameof(PlayersClient.GetSquadsAsync), "/players/squads", "get", "players/squads.json"),
        new EndpointDefinition(typeof(PlayersClient), nameof(PlayersClient.GetTeamsAsync), "/players/teams", "get", "players/teams.json"),
        new EndpointDefinition(typeof(PlayersClient), nameof(PlayersClient.GetTopScorersAsync), "/players/topscorers", "get", "players/topscorers.json"),
        new EndpointDefinition(typeof(PlayersClient), nameof(PlayersClient.GetTopAssistsAsync), "/players/topassists", "get", "players/topassists.json"),
        new EndpointDefinition(typeof(PlayersClient), nameof(PlayersClient.GetTopYellowCardsAsync), "/players/topyellowcards", "get", "players/topyellowcards.json"),
        new EndpointDefinition(typeof(PlayersClient), nameof(PlayersClient.GetTopRedCardsAsync), "/players/topredcards", "get", "players/topredcards.json"),
        new EndpointDefinition(typeof(PredictionsClient), nameof(PredictionsClient.GetAsync), "/predictions", "get", "predictions.json"),
        new EndpointDefinition(typeof(OddsClient), nameof(OddsClient.GetAsync), "/odds", "get", "odds/odds.json"),
        new EndpointDefinition(typeof(OddsClient), nameof(OddsClient.GetLiveAsync), "/odds/live", "get", "odds/live.json"),
        new EndpointDefinition(typeof(OddsClient), nameof(OddsClient.GetLiveBetsAsync), "/odds/live/bets", "get", "odds/live/bets.json"),
        new EndpointDefinition(typeof(OddsClient), nameof(OddsClient.GetMappingAsync), "/odds/mapping", "get", "odds/mapping.json"),
        new EndpointDefinition(typeof(OddsClient), nameof(OddsClient.GetBookmakersAsync), "/odds/bookmakers", "get", "odds/bookmakers.json"),
        new EndpointDefinition(typeof(OddsClient), nameof(OddsClient.GetBetsAsync), "/odds/bets", "get", "odds/bets.json"),
        new EndpointDefinition(typeof(StandingsClient), nameof(StandingsClient.GetAsync), "/standings", "get", "standings.json"),
        new EndpointDefinition(typeof(InjuriesClient), nameof(InjuriesClient.GetAsync), "/injuries", "get", "injuries.json"),
        new EndpointDefinition(typeof(TransfersClient), nameof(TransfersClient.GetAsync), "/transfers", "get", "transfers.json"),
        new EndpointDefinition(typeof(CoachsClient), nameof(CoachsClient.GetAsync), "/coachs", "get", "coachs.json"),
        new EndpointDefinition(typeof(TrophiesClient), nameof(TrophiesClient.GetAsync), "/trophies", "get", "trophies.json"),
        new EndpointDefinition(typeof(SidelinedClient), nameof(SidelinedClient.GetAsync), "/sidelined", "get", "sidelined.json"),
        new EndpointDefinition(typeof(CountriesClient), nameof(CountriesClient.GetAsync), "/countries", "get", "countries.json"),
        new EndpointDefinition(typeof(VenuesClient), nameof(VenuesClient.GetAsync), "/venues", "get", "venues.json"),
        new EndpointDefinition(typeof(TimezoneClient), nameof(TimezoneClient.GetAsync), "/timezone", "get", "timezone.json")
    ];

    public static IReadOnlyDictionary<MethodKey, EndpointDefinition> EndpointByMethod { get; } = Endpoints
        .ToDictionary(definition => new MethodKey(definition.ClientType, definition.MethodName));

    public static IReadOnlyList<MethodInfo> GetEndpointMethods()
    {
        List<MethodInfo> methods = new();
        foreach (Type clientType in GetClientTypes())
        {
            IEnumerable<MethodInfo> clientMethods = clientType
                .GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.DeclaredOnly)
                .Where(method => !method.IsSpecialName);

            methods.AddRange(clientMethods);
        }

        return methods;
    }

    private static IReadOnlyList<Type> GetClientTypes()
    {
        return
        [
            typeof(FootballClient),
            typeof(TeamsClient),
            typeof(LeaguesClient),
            typeof(FixturesClient),
            typeof(PlayersClient),
            typeof(OddsClient),
            typeof(StandingsClient),
            typeof(InjuriesClient),
            typeof(PredictionsClient),
            typeof(CoachsClient),
            typeof(TransfersClient),
            typeof(TrophiesClient),
            typeof(SidelinedClient),
            typeof(CountriesClient),
            typeof(VenuesClient),
            typeof(StatusClient),
            typeof(TimezoneClient)
        ];
    }
}

public readonly record struct MethodKey(Type ClientType, string MethodName);

public sealed record EndpointDefinition(Type ClientType, string MethodName, string Path, string HttpMethod, string SamplePath);
