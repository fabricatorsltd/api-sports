using ApiSports.Sdk.Core;
using ApiSports.Sdk.Nfl.Clients;

namespace ApiSports.Sdk.Nfl;

public sealed class NflClient(ApiSportsHttpClient http)
{
    public StatusClient Status { get; } = new(http);
    public TimezoneClient Timezone { get; } = new(http);
    public SeasonsClient Seasons { get; } = new(http);
    public LeaguesClient Leagues { get; } = new(http);
    public TeamsClient Teams { get; } = new(http);
    public PlayersClient Players { get; } = new(http);
    public InjuriesClient Injuries { get; } = new(http);
    public GamesClient Games { get; } = new(http);
    public StandingsClient Standings { get; } = new(http);
    public OddsClient Odds { get; } = new(http);
}
