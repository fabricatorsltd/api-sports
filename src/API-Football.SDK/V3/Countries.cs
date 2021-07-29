using System;
using System.Collections.Generic;
using System.Text;

namespace API_Football.SDK.V3
{
    public class Countries
    {
        private const string BasePath = "countries";
        private readonly Client _client = new Client();

        public ApiResponse<List<Models.Country>> Get()
        {
            return _client.Get<List<Models.Country>>(BasePath);
        }
    }
}
