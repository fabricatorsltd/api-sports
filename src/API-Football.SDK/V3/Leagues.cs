using System.Collections.Generic;

namespace API_Football.SDK.V3
{
    public static class Leagues
    {
        public static ApiResponse<List<(Models.League league, 
            Models.Country country, 
            List<Models.Season> seasons)>> GetLeagues(this Instance instance)
        {
            return instance.DoCall<List<(Models.League league, 
                Models.Country country, 
                List<Models.Season> seasons)>> ("leagues");
        }
        public static ApiResponse<List<ushort>> GetLeagueSeasons(this Instance instance)
        {
            return instance.DoCall<List<ushort>>("leagues/seasons");
        }
    }
}