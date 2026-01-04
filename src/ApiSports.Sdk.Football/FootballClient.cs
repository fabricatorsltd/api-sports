using ApiSports.Sdk.Core;
using ApiSports.Sdk.Football.Clients;

namespace ApiSports.Sdk.Football;

public sealed class FootballClient(ApiSportsHttpClient http)
{
    public TeamsClient Teams { get; } = new(http);
    public LeaguesClient Leagues { get; } = new(http);
    public FixturesClient Fixtures { get; } = new(http);
    public PlayersClient Players { get; } = new(http);
    public OddsClient Odds { get; } = new(http);
    public StandingsClient Standings { get; } = new(http);
    public InjuriesClient Injuries { get; } = new(http);
    public PredictionsClient Predictions { get; } = new(http);
    public CoachsClient Coachs { get; } = new(http);
    public TransfersClient Transfers { get; } = new(http);
    public TrophiesClient Trophies { get; } = new(http);
    public SidelinedClient Sidelined { get; } = new(http);
    public CountriesClient Countries { get; } = new(http);
    public VenuesClient Venues { get; } = new(http);
    public StatusClient Status { get; } = new(http);
    public TimezoneClient Timezone { get; } = new(http);
}
