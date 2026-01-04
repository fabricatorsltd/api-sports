using System.Reflection;
using ApiSports.Sdk.Formula1.Clients;

namespace ApiSports.Sdk.Formula1.Tests;

public static class Formula1EndpointCatalog
{
    public static IReadOnlyList<EndpointDefinition> Endpoints { get; } = new List<EndpointDefinition>
    {
        new(typeof(TimezoneClient), nameof(TimezoneClient.GetAsync), "/timezone", "get", "timezone.json"),
        new(typeof(SeasonsClient), nameof(SeasonsClient.GetAsync), "/seasons", "get", "seasons.json"),
        new(typeof(CompetitionsClient), nameof(CompetitionsClient.GetAsync), "/competitions", "get", "competitions.json"),
        new(typeof(CircuitsClient), nameof(CircuitsClient.GetAsync), "/circuits", "get", "circuits.json"),
        new(typeof(TeamsClient), nameof(TeamsClient.GetAsync), "/teams", "get", "teams.json"),
        new(typeof(DriversClient), nameof(DriversClient.GetAsync), "/drivers", "get", "drivers.json"),
        new(typeof(RacesClient), nameof(RacesClient.GetAsync), "/races", "get", "races.json"),
        new(typeof(RankingsClient), nameof(RankingsClient.GetTeamsAsync), "/rankings/teams", "get", "rankings/teams.json"),
        new(typeof(RankingsClient), nameof(RankingsClient.GetDriversAsync), "/rankings/drivers", "get", "rankings/drivers.json"),
        new(typeof(RankingsClient), nameof(RankingsClient.GetRacesAsync), "/rankings/races", "get", "rankings/races.json"),
        new(typeof(RankingsClient), nameof(RankingsClient.GetFastestLapsAsync), "/rankings/fastestlaps", "get", "rankings/fastestlaps.json"),
        new(typeof(RankingsClient), nameof(RankingsClient.GetStartingGridAsync), "/rankings/startinggrid", "get", "rankings/startinggrid.json"),
        new(typeof(PitStopsClient), nameof(PitStopsClient.GetAsync), "/pitstops", "get", "pitstops.json")
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
            typeof(Formula1Client),
            typeof(TimezoneClient),
            typeof(SeasonsClient),
            typeof(CompetitionsClient),
            typeof(CircuitsClient),
            typeof(TeamsClient),
            typeof(DriversClient),
            typeof(RacesClient),
            typeof(RankingsClient),
            typeof(PitStopsClient)
        ];
    }
}

public readonly record struct MethodKey(Type ClientType, string MethodName);

public sealed record EndpointDefinition(Type ClientType, string MethodName, string Path, string HttpMethod, string SamplePath);
