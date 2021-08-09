using System;
using System.Collections.Generic;
using System.Text;

namespace API_Football.SDK.V3
{
    public static class Players
    {
        public static ApiResponse<List<int>> GetPlayerSeasons(
            this Instance instance,
            uint playerId)
        {
            return instance.DoCall<List<int>>($"players/seasons?player={playerId}");
        }
        
        public static ApiResponse<List<Models.ApiPlayerResponse>> GetPlayer(
            this Instance instance,
            uint playerId,
            ushort season)
        {
            return instance.DoCall<List<Models.ApiPlayerResponse>>($"players?id={playerId}&season={season}");
        }
    }
}
