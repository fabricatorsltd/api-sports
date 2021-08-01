using System.Collections.Generic;

namespace API_Football.SDK.V3
{
    public class Instance
    {
        private const string BasePath = "status";
        private readonly Client _client;

        public Instance(string apiKey)
        {
            _client = new Client(apiKey);
        }
        public Instance(string apiKey, string timezone)
        {
            _client = new Client(apiKey, timezone);
        }

        internal ApiResponse<T> DoCall<T>(string path)
        {
            return _client.Get<T>(path);
        }

        public ApiResponse<Models.Status> GetStatus()
        {
            return _client.Get<Models.Status>(BasePath);
        }

        public ApiResponse<List<string>> GetTimezone()
        {
            return _client.Get<List<string>>(BasePath);
        }
    }
}