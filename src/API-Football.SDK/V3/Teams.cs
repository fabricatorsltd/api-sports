using System.Collections.Generic;

namespace API_Football.SDK.V3
{
    public static class Teams
    {
        public static ApiResponse<List<(Models.Team team, Models.Venue venue)>> GetTeams(this Instance instance)
        {
            return instance.DoCall<List<(Models.Team team, Models.Venue venue)>>("teams");
        }
        public static ApiResponse<List<object>> GetTeamStatistics(this Instance instance)
        {
            return instance.DoCall<List<object>>("teams/statistics");
        }
        public static ApiResponse<List<ushort>> GetTeamSeasons(this Instance instance)
        {
            return instance.DoCall<List<ushort>>("teams/seasons");
        }
    }
}