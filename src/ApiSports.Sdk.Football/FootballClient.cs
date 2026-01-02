using ApiSports.Sdk.Core;
using ApiSports.Sdk.Football.Clients;

namespace ApiSports.Sdk.Football;

public sealed class FootballClient(ApiSportsHttpClient http)
{
    public TeamsClient Teams { get; } = new(http);
    public LeaguesClient Leagues { get; } = new(http);
    public FixturesClient Fixtures { get; } = new(http);
}
