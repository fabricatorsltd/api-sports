using ApiSports.Sdk.Baseball.Clients;
using ApiSports.Sdk.Core;

namespace ApiSports.Sdk.Baseball;

public sealed class BaseballClient(ApiSportsHttpClient http)
{
    public StatusClient Status { get; } = new(http);
    public TimezoneClient Timezone { get; } = new(http);
    public SeasonsClient Seasons { get; } = new(http);
    public CountriesClient Countries { get; } = new(http);
    public LeaguesClient Leagues { get; } = new(http);
    public TeamsClient Teams { get; } = new(http);
    public StandingsClient Standings { get; } = new(http);
    public GamesClient Games { get; } = new(http);
    public OddsClient Odds { get; } = new(http);
}
