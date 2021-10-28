﻿using System.Collections.Generic;

namespace API_Football.SDK.V3
{
    public static class Teams
    {
        #region " teams "
        public static ApiResponse<List<Models.ApiTeamResponse>> GetTeams(this Instance instance,
            string country)
        {
            return instance.DoCall<List<Models.ApiTeamResponse>>($"teams?country={country}");
        }
        public static ApiResponse<List<ushort>> GetTeamSeasons(this Instance instance,
            ushort teamId)
        {
            return instance.DoCall<List<ushort>>($"teams/seasons?team={teamId}");
        }
        public static ApiResponse<List<Models.ApiTeamResponse>> GetTeams(this Instance instance,
            ushort season,
            uint league)
        {
            return instance.DoCall<List<Models.ApiTeamResponse>>($"teams?season={season}&league={league}");
        }
        #endregion

        #region " teams/statistics "
        public static ApiResponse<List<object>> GetTeamStatistics(this Instance instance)
        {
            return instance.DoCall<List<object>>("teams/statistics");
        }
        public static ApiResponse<List<ushort>> GetTeamSeasons(this Instance instance)
        {
            return instance.DoCall<List<ushort>>("teams/seasons");
        }
        #endregion
    }
}