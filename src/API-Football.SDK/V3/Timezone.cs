using System;
using System.Collections.Generic;
using System.Text;

namespace API_Football.SDK.V3
{
    public class Timezone
    {
        private const string BasePath = "timezone";
        private readonly Client _client = new Client();

        public ApiResponse<List<string>> Get()
        {
            return _client.Get<List<string>>(BasePath);
        }
    }
}
