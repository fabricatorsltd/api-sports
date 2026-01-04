using System.Text.Json.Serialization;

namespace ApiSports.Sdk.Football.Models
{
    public sealed class TeamStatisticsResponse
    {
        [JsonPropertyName("league")]
        public TeamStatisticsLeague League { get; set; }

        [JsonPropertyName("team")]
        public TeamStatisticsTeam Team { get; set; }

        [JsonPropertyName("form")]
        public string? Form { get; set; }

        [JsonPropertyName("fixtures")]
        public TeamStatisticsFixtures Fixtures { get; set; }

        [JsonPropertyName("goals")]
        public TeamStatisticsGoals Goals { get; set; }

        [JsonPropertyName("biggest")]
        public TeamStatisticsBiggest Biggest { get; set; }

        [JsonPropertyName("clean_sheet")]
        public TeamStatisticsHomeAwayTotal CleanSheet { get; set; }

        [JsonPropertyName("failed_to_score")]
        public TeamStatisticsHomeAwayTotal FailedToScore { get; set; }

        [JsonPropertyName("penalty")]
        public TeamStatisticsPenalty Penalty { get; set; }

        [JsonPropertyName("lineups")]
        public List<TeamStatisticsLineup> Lineups { get; set; }

        [JsonPropertyName("cards")]
        public TeamStatisticsCards Cards { get; set; }
    }

    public sealed class TeamStatisticsLeague
    {
        [JsonPropertyName("id")]
        public int? Id { get; set; }

        [JsonPropertyName("name")]
        public string? Name { get; set; }

        [JsonPropertyName("country")]
        public string? Country { get; set; }

        [JsonPropertyName("logo")]
        public string? Logo { get; set; }

        [JsonPropertyName("flag")]
        public string? Flag { get; set; }

        [JsonPropertyName("season")]
        public int? Season { get; set; }
    }

    public sealed class TeamStatisticsTeam
    {
        [JsonPropertyName("id")]
        public int? Id { get; set; }

        [JsonPropertyName("name")]
        public string? Name { get; set; }

        [JsonPropertyName("logo")]
        public string? Logo { get; set; }
    }

    public sealed class TeamStatisticsFixtures
    {
        [JsonPropertyName("played")]
        public TeamStatisticsFixtureTotals Played { get; set; }

        [JsonPropertyName("wins")]
        public TeamStatisticsFixtureTotals Wins { get; set; }

        [JsonPropertyName("draws")]
        public TeamStatisticsFixtureTotals Draws { get; set; }

        [JsonPropertyName("loses")]
        public TeamStatisticsFixtureTotals Loses { get; set; }
    }

    public sealed class TeamStatisticsFixtureTotals
    {
        [JsonPropertyName("home")]
        public int? Home { get; set; }

        [JsonPropertyName("away")]
        public int? Away { get; set; }

        [JsonPropertyName("total")]
        public int? Total { get; set; }
    }

    public sealed class TeamStatisticsGoals
    {
        [JsonPropertyName("for")]
        public TeamStatisticsGoalsForAgainst For { get; set; }

        [JsonPropertyName("against")]
        public TeamStatisticsGoalsForAgainst Against { get; set; }
    }

    public sealed class TeamStatisticsGoalsForAgainst
    {
        [JsonPropertyName("total")]
        public TeamStatisticsFixtureTotals Total { get; set; }

        [JsonPropertyName("average")]
        public TeamStatisticsGoalAverage Average { get; set; }

        [JsonPropertyName("minute")]
        public Dictionary<string, TeamStatisticsGoalMinute> Minute { get; set; }

        [JsonPropertyName("under_over")]
        public Dictionary<string, TeamStatisticsGoalOverUnder> UnderOver { get; set; }
    }

    public sealed class TeamStatisticsGoalAverage
    {
        [JsonPropertyName("home")]
        public string? Home { get; set; }

        [JsonPropertyName("away")]
        public string? Away { get; set; }

        [JsonPropertyName("total")]
        public string? Total { get; set; }
    }

    public sealed class TeamStatisticsGoalMinute
    {
        [JsonPropertyName("total")]
        public int? Total { get; set; }

        [JsonPropertyName("percentage")]
        public string? Percentage { get; set; }
    }

    public sealed class TeamStatisticsGoalOverUnder
    {
        [JsonPropertyName("over")]
        public int? Over { get; set; }

        [JsonPropertyName("under")]
        public int? Under { get; set; }
    }

    public sealed class TeamStatisticsBiggest
    {
        [JsonPropertyName("streak")]
        public TeamStatisticsStreak Streak { get; set; }

        [JsonPropertyName("wins")]
        public TeamStatisticsHomeAwayScore Wins { get; set; }

        [JsonPropertyName("loses")]
        public TeamStatisticsHomeAwayScore Loses { get; set; }

        [JsonPropertyName("goals")]
        public TeamStatisticsBiggestGoals Goals { get; set; }
    }

    public sealed class TeamStatisticsStreak
    {
        [JsonPropertyName("wins")]
        public int? Wins { get; set; }

        [JsonPropertyName("draws")]
        public int? Draws { get; set; }

        [JsonPropertyName("loses")]
        public int? Loses { get; set; }
    }

    public sealed class TeamStatisticsHomeAwayScore
    {
        [JsonPropertyName("home")]
        public string? Home { get; set; }

        [JsonPropertyName("away")]
        public string? Away { get; set; }
    }

    public sealed class TeamStatisticsBiggestGoals
    {
        [JsonPropertyName("for")]
        public TeamStatisticsGoalHomeAway For { get; set; }

        [JsonPropertyName("against")]
        public TeamStatisticsGoalHomeAway Against { get; set; }
    }

    public sealed class TeamStatisticsGoalHomeAway
    {
        [JsonPropertyName("home")]
        public int? Home { get; set; }

        [JsonPropertyName("away")]
        public int? Away { get; set; }
    }

    public sealed class TeamStatisticsHomeAwayTotal
    {
        [JsonPropertyName("home")]
        public int? Home { get; set; }

        [JsonPropertyName("away")]
        public int? Away { get; set; }

        [JsonPropertyName("total")]
        public int? Total { get; set; }
    }

    public sealed class TeamStatisticsPenalty
    {
        [JsonPropertyName("scored")]
        public TeamStatisticsPenaltyResult Scored { get; set; }

        [JsonPropertyName("missed")]
        public TeamStatisticsPenaltyResult Missed { get; set; }

        [JsonPropertyName("total")]
        public int? Total { get; set; }
    }

    public sealed class TeamStatisticsPenaltyResult
    {
        [JsonPropertyName("total")]
        public int? Total { get; set; }

        [JsonPropertyName("percentage")]
        public string? Percentage { get; set; }
    }

    public sealed class TeamStatisticsLineup
    {
        [JsonPropertyName("formation")]
        public string? Formation { get; set; }

        [JsonPropertyName("played")]
        public int? Played { get; set; }
    }

    public sealed class TeamStatisticsCards
    {
        [JsonPropertyName("yellow")]
        public Dictionary<string, TeamStatisticsCardRange> Yellow { get; set; }

        [JsonPropertyName("red")]
        public Dictionary<string, TeamStatisticsCardRange> Red { get; set; }
    }

    public sealed class TeamStatisticsCardRange
    {
        [JsonPropertyName("total")]
        public int? Total { get; set; }

        [JsonPropertyName("percentage")]
        public string? Percentage { get; set; }
    }
}
