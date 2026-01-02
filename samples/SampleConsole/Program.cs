using ApiSports.Sdk.Abstractions;
using ApiSports.Sdk.Core;
using ApiSports.Sdk.Football;
using ApiSports.Sdk.Football.Models;
using ApiSports.Sdk.Football.QueryParams;

namespace SampleConsole;

internal class Program
{
    private static async Task Main(string[] args)
    {
        var sdk = ApiSportsSdk.Create("825ba3f22fef6291a0de773230e51b2a");
        ApiSportsHttpClient football = sdk.ForSport(ApiSportsSport.Football);
        var client = new FootballClient(football);

        var query = new FixturesQuery()
        {
            Date = new DateOnly(2026, 01, 08)
        };

        ApiResponse<FixtureResponse[]> result =
            await client.Fixtures.GetAsync(query, CancellationToken.None);
        
        foreach (FixtureResponse fixture in result.Response ?? [])
        {
            Console.WriteLine(
                $"{fixture.League?.Name} - " +
                $"{fixture.Teams?.Home?.Name} vs {fixture.Teams?.Away?.Name}");
        }

        Console.WriteLine("=== Press Enter to exit ===");
        Console.ReadLine();
    }
}
