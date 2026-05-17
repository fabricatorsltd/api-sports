using System.Reflection;
using ApiSports.Sdk.Mma.Clients;

namespace ApiSports.Sdk.Mma.Tests;

public static class MmaEndpointCatalog
{
    public static IReadOnlyList<EndpointDefinition> Endpoints { get; } = new List<EndpointDefinition>
    {
        new(typeof(StatusClient), nameof(StatusClient.GetAsync), "/status", "get", "status.json"),
        new(typeof(TimezoneClient), nameof(TimezoneClient.GetAsync), "/timezone", "get", "timezone.json"),
        new(typeof(SeasonsClient), nameof(SeasonsClient.GetAsync), "/seasons", "get", "seasons.json"),
        new(typeof(CategoriesClient), nameof(CategoriesClient.GetAsync), "/categories", "get", "categories.json"),
        new(typeof(TeamsClient), nameof(TeamsClient.GetAsync), "/teams", "get", "teams.json"),
        new(typeof(FightersClient), nameof(FightersClient.GetAsync), "/fighters", "get", "fighters/fighters.json"),
        new(typeof(FightersClient), nameof(FightersClient.GetRecordsAsync), "/fighters/records", "get", "fighters/records.json"),
        new(typeof(FightsClient), nameof(FightsClient.GetAsync), "/fights", "get", "fights/fights.json"),
        new(typeof(FightsClient), nameof(FightsClient.GetResultsAsync), "/fights/results", "get", "fights/results.json"),
        new(typeof(FightsClient), nameof(FightsClient.GetFighterStatisticsAsync), "/fights/statistics/fighters", "get", "fights/statistics/fighters.json"),
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
            typeof(MmaClient),
            typeof(StatusClient),
            typeof(TimezoneClient),
            typeof(SeasonsClient),
            typeof(CategoriesClient),
            typeof(TeamsClient),
            typeof(FightersClient),
            typeof(FightsClient),
            typeof(OddsClient),
        ];
    }
}

public readonly record struct MethodKey(Type ClientType, string MethodName);

public sealed record EndpointDefinition(Type ClientType, string MethodName, string Path, string HttpMethod, string SamplePath);
