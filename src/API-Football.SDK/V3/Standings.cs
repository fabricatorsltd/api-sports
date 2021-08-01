using System.Collections.Generic;

namespace API_Football.SDK.V3
{
    public static class Standings
    {
        public static ApiResponse<List<Models.Standing>> GetStandingsByLeague(
            this Instance instance,
            ushort season,
            ushort league)
        {
            return instance.DoCall<List<Models.Standing>>($"standings?season={season}&league={league}");
        }
        public static ApiResponse<List<Models.Standing>> GetStandingsByTeam(
            this Instance instance,
            ushort season,
            ushort team)
        {
            return instance.DoCall<List<Models.Standing>>($"standings?season={season}&team={team}");
        }
        public static ApiResponse<List<Models.Standing>> GetStandings(
            this Instance instance,
            ushort season,
            ushort league,
            ushort team)
        {
            return instance.DoCall<List<Models.Standing>>($"standings?season={season}&league={league}&team={team}");
        }
    }
}