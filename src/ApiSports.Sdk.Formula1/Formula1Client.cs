using ApiSports.Sdk.Core;
using ApiSports.Sdk.Formula1.Clients;

namespace ApiSports.Sdk.Formula1;

public sealed class Formula1Client(ApiSportsHttpClient http)
{
    public TimezoneClient Timezone { get; } = new(http);
    public SeasonsClient Seasons { get; } = new(http);
    public CompetitionsClient Competitions { get; } = new(http);
    public CircuitsClient Circuits { get; } = new(http);
    public TeamsClient Teams { get; } = new(http);
    public DriversClient Drivers { get; } = new(http);
    public RacesClient Races { get; } = new(http);
    public RankingsClient Rankings { get; } = new(http);
    public PitStopsClient PitStops { get; } = new(http);
}
