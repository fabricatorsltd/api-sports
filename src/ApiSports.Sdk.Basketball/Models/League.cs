using System.Text.Json.Serialization;

namespace ApiSports.Sdk.Basketball.Models;

public sealed class League
{
    [JsonPropertyName("id")]
    public int? Id { get; init; }

    [JsonPropertyName("name")]
    public string? Name { get; init; }

    [JsonPropertyName("type")]
    public string? Type { get; init; }

    [JsonPropertyName("logo")]
    public string? Logo { get; init; }

    [JsonPropertyName("country")]
    public Country? Country { get; init; }

    [JsonPropertyName("seasons")]
    public LeagueSeason[]? Seasons { get; init; }
}

public sealed class LeagueSeason
{
    [JsonPropertyName("season")]
    public System.Text.Json.JsonElement? Season { get; init; }

    [JsonPropertyName("start")]
    public string? Start { get; init; }

    [JsonPropertyName("end")]
    public string? End { get; init; }

    [JsonPropertyName("coverage")]
    public LeagueSeasonCoverage? Coverage { get; init; }
}

public sealed class LeagueSeasonCoverage
{
    [JsonPropertyName("games")]
    public LeagueSeasonGamesCoverage? Games { get; init; }

    [JsonPropertyName("standings")]
    public bool? Standings { get; init; }

    [JsonPropertyName("players")]
    public bool? Players { get; init; }

    [JsonPropertyName("odds")]
    public bool? Odds { get; init; }
}

public sealed class LeagueSeasonGamesCoverage
{
    [JsonPropertyName("statistics")]
    public LeagueSeasonGamesStatisticsCoverage? Statistics { get; init; }
}

public sealed class LeagueSeasonGamesStatisticsCoverage
{
    [JsonPropertyName("teams")]
    public bool? Teams { get; init; }

    [JsonPropertyName("players")]
    public bool? Players { get; init; }
}

public sealed class LeagueRef
{
    [JsonPropertyName("id")]
    public int? Id { get; init; }

    [JsonPropertyName("name")]
    public string? Name { get; init; }

    [JsonPropertyName("type")]
    public string? Type { get; init; }

    [JsonPropertyName("logo")]
    public string? Logo { get; init; }

    [JsonPropertyName("season")]
    public System.Text.Json.JsonElement? Season { get; init; }
}
