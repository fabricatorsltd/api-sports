using System.Collections.Generic;

namespace API_Football.SDK.V3
{
    public static class Coachs
    {
        public static ApiResponse<List<Models.Coach>> GetCoachs(
            this Instance instance,
            uint coachId)
        {
            return instance.DoCall<List<Models.Coach>>($"coachs?id={coachId}");
        }
    }
}
