using System.Collections.Generic;

namespace API_Football.SDK.V3
{
    public static class Venues
    {
        public static ApiResponse<List<Models.Venue>> GetVenues(this Instance instance)
        {
            return instance.DoCall<List<Models.Venue>>("venues");
        }
    }
}