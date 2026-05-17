using System.Reflection;
using ApiSports.Sdk.Nba.Clients;

namespace ApiSports.Sdk.Nba.Tests;

public static class NbaEndpointCatalog
{
    public static IReadOnlyList<EndpointDefinition> Endpoints { get; } = new List<EndpointDefinition>
    {
        new(typeof(StatusClient), nameof(StatusClient.GetAsync), "/status", "get", "status.json"),
        new(typeof(SeasonsClient), nameof(SeasonsClient.GetAsync), "/seasons", "get", "seasons.json"),
        new(typeof(LeaguesClient), nameof(LeaguesClient.GetAsync), "/leagues", "get", "leagues.json"),
        new(typeof(TeamsClient), nameof(TeamsClient.GetAsync), "/teams", "get", "teams/teams.json"),
        new(typeof(TeamsClient), nameof(TeamsClient.GetStatisticsAsync), "/teams/statistics", "get", "teams/statistics.json"),
        new(typeof(PlayersClient), nameof(PlayersClient.GetAsync), "/players", "get", "players/players.json"),
        new(typeof(PlayersClient), nameof(PlayersClient.GetStatisticsAsync), "/players/statistics", "get", "players/statistics.json"),
        new(typeof(GamesClient), nameof(GamesClient.GetAsync), "/games", "get", "games/games.json"),
        new(typeof(GamesClient), nameof(GamesClient.GetStatisticsAsync), "/games/statistics", "get", "games/statistics.json"),
        new(typeof(StandingsClient), nameof(StandingsClient.GetAsync), "/standings", "get", "standings.json"),
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
            typeof(NbaClient),
            typeof(StatusClient),
            typeof(SeasonsClient),
            typeof(LeaguesClient),
            typeof(TeamsClient),
            typeof(PlayersClient),
            typeof(GamesClient),
            typeof(StandingsClient),
        ];
    }
}

public readonly record struct MethodKey(Type ClientType, string MethodName);

public sealed record EndpointDefinition(Type ClientType, string MethodName, string Path, string HttpMethod, string SamplePath);
