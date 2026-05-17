using ApiSports.Sdk.Core;
using ApiSports.Sdk.Volleyball.Clients;

namespace ApiSports.Sdk.Volleyball;

public sealed class VolleyballClient(ApiSportsHttpClient http)
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
