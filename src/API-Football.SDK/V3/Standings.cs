using System.Collections.Generic;

namespace API_Football.SDK.V3
{
    public static class Standings
    {
        public static ApiResponse<List<Models.ApiStandingsResponse>> GetStandingsByLeague(
            this Instance instance,
            ushort season,
            ushort league)
        {
            return instance.DoCall<List<Models.ApiStandingsResponse>>($"standings?season={season}&league={league}");
        }
        public static ApiResponse<List<Models.ApiStandingsResponse>> GetStandingsByTeam(
            this Instance instance,
            ushort season,
            ushort team)
        {
            return instance.DoCall<List<Models.ApiStandingsResponse>>($"standings?season={season}&team={team}");
        }
        public static ApiResponse<List<Models.ApiStandingsResponse>> GetStandings(
            this Instance instance,
            ushort season,
            ushort league,
            ushort team)
        {
            return instance.DoCall<List<Models.ApiStandingsResponse>>($"standings?season={season}&league={league}&team={team}");
        }
    }
}