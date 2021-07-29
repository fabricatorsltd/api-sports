using System;
using System.Collections.Generic;
using System.Text;

namespace API_Football.SDK.V3
{
    public class Status
    {
        private const string BasePath = "status";
        private readonly Client _client = new Client();

        public ApiResponse<Models.Status> Get()
        {
            return _client.Get<Models.Status>(BasePath);
        }
    }
}
