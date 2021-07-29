using System.Collections.Generic;

namespace API_Football.SDK.V3
{
    public static class Countries
    {
        private const string BasePath = "countries";

        public static ApiResponse<List<Models.Country>> GetCountries(this Instance instance)
        {
            return instance.DoCall<List<Models.Country>>(BasePath);
        }
    }
}
