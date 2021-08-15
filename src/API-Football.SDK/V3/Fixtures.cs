using System.Collections.Generic;

namespace API_Football.SDK.V3
{
    public static class Fixtures
    {
        public static ApiResponse<List<Models.ApiFixtureResponse>> GetFixtures(
            this Instance instance,
            string matches = "all")
        {
            return instance.DoCall<List<Models.ApiFixtureResponse>>($"fixtures?live={matches}");
        }
        
        public static ApiResponse<List<Models.ApiFixtureResponse>> GetFixtures(
            this Instance instance,
            ushort leagueId,
            ushort season)
        {
            return instance.DoCall<List<Models.ApiFixtureResponse>>($"fixtures?league={leagueId}&season={season}");
        }

        public static ApiResponse<List<Models.ApiFixtureResponse>> GetFixture(
            this Instance instance,
            int id)
        {
            return instance.DoCall<List<Models.ApiFixtureResponse>>($"fixtures?id={id}");
        }
    }
}
