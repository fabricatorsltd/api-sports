using System.Collections.Generic;
using API_Football.SDK.Models;

namespace API_Football.SDK.V3
{
    public static class Leagues
    {
        public static ApiResponse<List<Models.ApiLeagueResponse>> GetLeagues(this Instance instance)
        {
            return instance.DoCall<List<Models.ApiLeagueResponse>>("leagues");
        }
        public static ApiResponse<List<Models.ApiLeagueResponse>> GetLeagues(this Instance instance,
            ushort season)
        {
            return instance.DoCall<List<Models.ApiLeagueResponse>>($"leagues?season={season}");
        }
        public static ApiResponse<List<ushort>> GetLeagueSeasons(this Instance instance)
        {
            return instance.DoCall<List<ushort>>("leagues/seasons");
        }
        public static ApiResponse<List<ApiLeagueResponse>> GetCurrent(this Instance instance)
        {
            return instance.DoCall<List<ApiLeagueResponse>>("leagues?current=true");
        }
    }
}