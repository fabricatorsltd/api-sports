using System.Text.Json.Serialization;

namespace ApiSports.Sdk.Nfl.Models;

public sealed class League
{
    [JsonPropertyName("league")]
    public LeagueSummary? LeagueInfo { get; init; }

    [JsonPropertyName("country")]
    public Country? Country { get; init; }

    [JsonPropertyName("seasons")]
    public LeagueSeason[]? Seasons { get; init; }
}

public sealed class LeagueSummary
{
    [JsonPropertyName("id")]
    public int? Id { get; init; }

    [JsonPropertyName("name")]
    public string? Name { get; init; }

    [JsonPropertyName("logo")]
    public string? Logo { get; init; }
}

public sealed class LeagueSeason
{
    [JsonPropertyName("year")]
    public int? Year { get; init; }

    [JsonPropertyName("start")]
    public string? Start { get; init; }

    [JsonPropertyName("end")]
    public string? End { get; init; }

    [JsonPropertyName("current")]
    public bool? Current { get; init; }

    [JsonPropertyName("coverage")]
    public LeagueSeasonCoverage? Coverage { get; init; }
}

public sealed class LeagueSeasonCoverage
{
    [JsonPropertyName("games")]
    public LeagueSeasonGamesCoverage? Games { get; init; }

    [JsonPropertyName("statistics")]
    public LeagueSeasonStatisticsCoverage? Statistics { get; init; }

    [JsonPropertyName("players")]
    public bool? Players { get; init; }

    [JsonPropertyName("injuries")]
    public bool? Injuries { get; init; }

    [JsonPropertyName("standings")]
    public bool? Standings { get; init; }
}

public sealed class LeagueSeasonGamesCoverage
{
    [JsonPropertyName("events")]
    public bool? Events { get; init; }

    // Upstream field is misspelled ("statisitcs") — preserve to deserialize correctly.
    [JsonPropertyName("statisitcs")]
    public LeagueSeasonGamesStatisticsCoverage? Statistics { get; init; }
}

public sealed class LeagueSeasonGamesStatisticsCoverage
{
    [JsonPropertyName("teams")]
    public bool? Teams { get; init; }

    [JsonPropertyName("players")]
    public bool? Players { get; init; }
}

public sealed class LeagueSeasonStatisticsCoverage
{
    [JsonPropertyName("season")]
    public LeagueSeasonStatisticsSeasonCoverage? Season { get; init; }
}

public sealed class LeagueSeasonStatisticsSeasonCoverage
{
    [JsonPropertyName("players")]
    public bool? Players { get; init; }
}

public sealed class LeagueRef
{
    [JsonPropertyName("id")]
    public int? Id { get; init; }

    [JsonPropertyName("name")]
    public string? Name { get; init; }

    [JsonPropertyName("season")]
    public System.Text.Json.JsonElement? Season { get; init; }

    [JsonPropertyName("logo")]
    public string? Logo { get; init; }

    [JsonPropertyName("country")]
    public Country? Country { get; init; }
}
