using System.Collections.Generic;

namespace API_Football.SDK.V3
{
    public static class Injuries
    {
        public static ApiResponse<List<Models.Injury>> GetInjuries(this Instance instance)
        {
            return instance.DoCall<List<Models.Injury>>("injuries");
        }
    }
}
