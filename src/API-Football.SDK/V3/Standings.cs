using System.Collections.Generic;

namespace API_Football.SDK.V3
{
    public static class Standings
    {
        public static ApiResponse<List<Models.Standing>> GetStandings(this Instance instance)
        {
            return instance.DoCall<List<Models.Standing>>("standings");
        }
    }
}