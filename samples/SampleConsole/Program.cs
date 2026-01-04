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
        var sdk = ApiSportsSdk.Create("API_KEY");
        ApiSportsHttpClient httpClient = sdk.ForSport(ApiSportsSport.Football);
        var football = new FootballClient(httpClient);

        var query = new FixturesQuery()
        {
            Date = new DateOnly(2026, 01, 08)
        };

        ApiResponse<FixtureResponse[]> result =
            await football.Fixtures.GetAsync(query, CancellationToken.None);
        
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
