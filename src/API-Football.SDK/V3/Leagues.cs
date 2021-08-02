using System.Collections.Generic;

namespace API_Football.SDK.V3
{
    public static class Leagues
    {
        public static ApiResponse<List<Models.ApiLeagueResponse>> GetLeagues(this Instance instance)
        {
            return instance.DoCall<List<Models.ApiLeagueResponse>>("leagues");
        }
        public static ApiResponse<List<ushort>> GetLeagueSeasons(this Instance instance)
        {
            return instance.DoCall<List<ushort>>("leagues/seasons");
        }
    }
}