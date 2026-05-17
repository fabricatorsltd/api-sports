using System.Reflection;
using ApiSports.Sdk.Afl.Clients;

namespace ApiSports.Sdk.Afl.Tests;

public static class AflEndpointCatalog
{
    public static IReadOnlyList<EndpointDefinition> Endpoints { get; } = new List<EndpointDefinition>
    {
        new(typeof(StatusClient), nameof(StatusClient.GetAsync), "/status", "get", "status.json"),
        new(typeof(TimezoneClient), nameof(TimezoneClient.GetAsync), "/timezone", "get", "timezone.json"),
        new(typeof(SeasonsClient), nameof(SeasonsClient.GetAsync), "/seasons", "get", "seasons.json"),
        new(typeof(LeaguesClient), nameof(LeaguesClient.GetAsync), "/leagues", "get", "leagues.json"),
        new(typeof(TeamsClient), nameof(TeamsClient.GetAsync), "/teams", "get", "teams/teams.json"),
        new(typeof(TeamsClient), nameof(TeamsClient.GetStatisticsAsync), "/teams/statistics", "get", "teams/statistics.json"),
        new(typeof(StandingsClient), nameof(StandingsClient.GetAsync), "/standings", "get", "standings/standings.json"),
        new(typeof(GamesClient), nameof(GamesClient.GetAsync), "/games", "get", "games/games.json"),
        new(typeof(GamesClient), nameof(GamesClient.GetEventsAsync), "/games/events", "get", "games/events.json"),
        new(typeof(GamesClient), nameof(GamesClient.GetQuartersAsync), "/games/quarters", "get", "games/quarters.json"),
        new(typeof(GamesClient), nameof(GamesClient.GetTeamStatisticsAsync), "/games/statistics/teams", "get", "games/statistics/teams.json"),
        new(typeof(GamesClient), nameof(GamesClient.GetPlayerStatisticsAsync), "/games/statistics/players", "get", "games/statistics/players.json"),
        new(typeof(PlayersClient), nameof(PlayersClient.GetAsync), "/players", "get", "players/players.json"),
        new(typeof(PlayersClient), nameof(PlayersClient.GetStatisticsAsync), "/players/statistics", "get", "players/statistics.json"),
        new(typeof(OddsClient), nameof(OddsClient.GetAsync), "/odds", "get", "odds/odds.json"),
        new(typeof(OddsClient), nameof(OddsClient.GetBetsAsync), "/odds/bets", "get", "odds/bets.json"),
        new(typeof(OddsClient), nameof(OddsClient.GetBookmakersAsync), "/odds/bookmakers", "get", "odds/bookmakers.json"),
    };

    public static IReadOnlyDictionary<MethodKey, EndpointDefinition> EndpointByMethod { get; } = Endpoints
        .ToDictionary(definition => new MethodKey(definition.ClientType, definition.MethodName));

    public static IReadOnlyList<MethodInfo> GetEndpointMethods()
    {
        var methods = new List<MethodInfo>();
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
            typeof(AflClient),
            typeof(StatusClient),
            typeof(TimezoneClient),
            typeof(SeasonsClient),
            typeof(LeaguesClient),
            typeof(TeamsClient),
            typeof(StandingsClient),
            typeof(GamesClient),
            typeof(PlayersClient),
            typeof(OddsClient),
        ];
    }
}

public readonly record struct MethodKey(Type ClientType, string MethodName);

public sealed record EndpointDefinition(Type ClientType, string MethodName, string Path, string HttpMethod, string SamplePath);
