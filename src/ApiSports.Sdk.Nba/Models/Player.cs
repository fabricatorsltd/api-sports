using System.Text.Json.Serialization;

namespace ApiSports.Sdk.Nba.Models;

public sealed class Player
{
    [JsonPropertyName("id")]
    public int? Id { get; init; }

    [JsonPropertyName("firstname")]
    public string? FirstName { get; init; }

    [JsonPropertyName("lastname")]
    public string? LastName { get; init; }

    [JsonPropertyName("birth")]
    public PlayerBirth? Birth { get; init; }

    [JsonPropertyName("nba")]
    public PlayerNba? Nba { get; init; }

    [JsonPropertyName("height")]
    public PlayerHeight? Height { get; init; }

    [JsonPropertyName("weight")]
    public PlayerWeight? Weight { get; init; }

    [JsonPropertyName("college")]
    public string? College { get; init; }

    [JsonPropertyName("affiliation")]
    public string? Affiliation { get; init; }

    [JsonPropertyName("leagues")]
    public PlayerLeagues? Leagues { get; init; }
}

public sealed class PlayerBirth
{
    [JsonPropertyName("date")]
    public string? Date { get; init; }

    [JsonPropertyName("country")]
    public string? Country { get; init; }
}

public sealed class PlayerNba
{
    [JsonPropertyName("start")]
    public int? Start { get; init; }

    [JsonPropertyName("pro")]
    public int? Pro { get; init; }
}

public sealed class PlayerHeight
{
    [JsonPropertyName("feets")]
    public string? Feet { get; init; }

    [JsonPropertyName("inches")]
    public string? Inches { get; init; }

    [JsonPropertyName("meters")]
    public string? Meters { get; init; }
}

public sealed class PlayerWeight
{
    [JsonPropertyName("pounds")]
    public string? Pounds { get; init; }

    [JsonPropertyName("kilograms")]
    public string? Kilograms { get; init; }
}

public sealed class PlayerLeagues
{
    [JsonPropertyName("standard")]
    public PlayerLeagueAffiliation? Standard { get; init; }

    [JsonPropertyName("africa")]
    public PlayerLeagueAffiliation? Africa { get; init; }

    [JsonPropertyName("orlando")]
    public PlayerLeagueAffiliation? Orlando { get; init; }

    [JsonPropertyName("sacramento")]
    public PlayerLeagueAffiliation? Sacramento { get; init; }

    [JsonPropertyName("utah")]
    public PlayerLeagueAffiliation? Utah { get; init; }

    [JsonPropertyName("vegas")]
    public PlayerLeagueAffiliation? Vegas { get; init; }
}

public sealed class PlayerLeagueAffiliation
{
    [JsonPropertyName("jersey")]
    public int? Jersey { get; init; }

    [JsonPropertyName("active")]
    public bool? Active { get; init; }

    [JsonPropertyName("pos")]
    public string? Position { get; init; }
}

public sealed class PlayerRef
{
    [JsonPropertyName("id")]
    public int? Id { get; init; }

    [JsonPropertyName("firstname")]
    public string? FirstName { get; init; }

    [JsonPropertyName("lastname")]
    public string? LastName { get; init; }
}
