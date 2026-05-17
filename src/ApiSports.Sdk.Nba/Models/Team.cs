using System.Text.Json.Serialization;

namespace ApiSports.Sdk.Nba.Models;

public sealed class Team
{
    [JsonPropertyName("id")]
    public int? Id { get; init; }

    [JsonPropertyName("name")]
    public string? Name { get; init; }

    [JsonPropertyName("nickname")]
    public string? Nickname { get; init; }

    [JsonPropertyName("code")]
    public string? Code { get; init; }

    [JsonPropertyName("city")]
    public string? City { get; init; }

    [JsonPropertyName("logo")]
    public string? Logo { get; init; }

    [JsonPropertyName("allStar")]
    public bool? AllStar { get; init; }

    [JsonPropertyName("nbaFranchise")]
    public bool? NbaFranchise { get; init; }

    [JsonPropertyName("leagues")]
    public TeamLeagues? Leagues { get; init; }
}

public sealed class TeamLeagues
{
    [JsonPropertyName("standard")]
    public TeamLeagueAffiliation? Standard { get; init; }

    [JsonPropertyName("africa")]
    public TeamLeagueAffiliation? Africa { get; init; }

    [JsonPropertyName("orlando")]
    public TeamLeagueAffiliation? Orlando { get; init; }

    [JsonPropertyName("sacramento")]
    public TeamLeagueAffiliation? Sacramento { get; init; }

    [JsonPropertyName("utah")]
    public TeamLeagueAffiliation? Utah { get; init; }

    [JsonPropertyName("vegas")]
    public TeamLeagueAffiliation? Vegas { get; init; }
}

public sealed class TeamLeagueAffiliation
{
    [JsonPropertyName("conference")]
    public string? Conference { get; init; }

    [JsonPropertyName("division")]
    public string? Division { get; init; }
}

public sealed class TeamRef
{
    [JsonPropertyName("id")]
    public int? Id { get; init; }

    [JsonPropertyName("name")]
    public string? Name { get; init; }

    [JsonPropertyName("nickname")]
    public string? Nickname { get; init; }

    [JsonPropertyName("code")]
    public string? Code { get; init; }

    [JsonPropertyName("logo")]
    public string? Logo { get; init; }
}
