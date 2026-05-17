using ApiSports.Sdk.Core;
using ApiSports.Sdk.Nba.Clients;

namespace ApiSports.Sdk.Nba;

public sealed class NbaClient(ApiSportsHttpClient http)
{
    public StatusClient Status { get; } = new(http);
    public SeasonsClient Seasons { get; } = new(http);
    public LeaguesClient Leagues { get; } = new(http);
    public TeamsClient Teams { get; } = new(http);
    public PlayersClient Players { get; } = new(http);
    public GamesClient Games { get; } = new(http);
    public StandingsClient Standings { get; } = new(http);
}
