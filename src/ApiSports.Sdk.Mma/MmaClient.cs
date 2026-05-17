using ApiSports.Sdk.Core;
using ApiSports.Sdk.Mma.Clients;

namespace ApiSports.Sdk.Mma;

public sealed class MmaClient(ApiSportsHttpClient http)
{
    public StatusClient Status { get; } = new(http);
    public TimezoneClient Timezone { get; } = new(http);
    public SeasonsClient Seasons { get; } = new(http);
    public CategoriesClient Categories { get; } = new(http);
    public TeamsClient Teams { get; } = new(http);
    public FightersClient Fighters { get; } = new(http);
    public FightsClient Fights { get; } = new(http);
    public OddsClient Odds { get; } = new(http);
}
