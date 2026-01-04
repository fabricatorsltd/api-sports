using ApiSports.Sdk.Abstractions;

namespace ApiSports.Sdk.Core;

public sealed class DefaultSportBaseUriResolver : ISportBaseUriResolver
{
    public Uri Resolve(ApiSportsSport sport)
    {
        return sport switch
        {
            ApiSportsSport.Afl => new Uri("https://v1.afl.api-sports.io/"),
            ApiSportsSport.Baseball => new Uri("https://v1.baseball.api-sports.io/"),
            ApiSportsSport.Basketball => new Uri("https://v1.basketball.api-sports.io/"),
            ApiSportsSport.Football => new Uri("https://v3.football.api-sports.io/"),
            ApiSportsSport.Formula1 => new Uri("https://v1.formula-1.api-sports.io/"),
            ApiSportsSport.Handball => new Uri("https://v1.handball.api-sports.io/"),
            ApiSportsSport.Hockey => new Uri("https://v1.hockey.api-sports.io/"),
            ApiSportsSport.Mma => new Uri("https://v1.mma.api-sports.io/"),
            ApiSportsSport.Nba => new Uri("https://v2.nba.api-sports.io/"),
            ApiSportsSport.AmericanFootball => new Uri("https://v1.american-football.api-sports.io/"),
            ApiSportsSport.Nfl => new Uri("https://v1.american-football.api-sports.io/"),
            ApiSportsSport.Rugby => new Uri("https://v1.rugby.api-sports.io/"),
            ApiSportsSport.Volleyball => new Uri("https://v1.volleyball.api-sports.io/"),
            _ => throw new ArgumentOutOfRangeException(nameof(sport), sport, "Unsupported sport.")
        };
    }
}
