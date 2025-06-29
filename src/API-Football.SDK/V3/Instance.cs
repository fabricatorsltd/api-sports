using System;
using System.Collections.Generic;
using API_Football.SDK.Models;

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

        public ApiResponse<Status> GetStatus()
        {
            return _client.Get<Models.Status>(BasePath);
        }

        public ApiResponse<List<string>> GetTimezone()
        {
            return _client.Get<List<string>>(BasePath);
        }
        
        public ApiLimits GetLimits()
        {
            if (Globals.CurrentLimits.RateLimit > 0U)
                return Globals.CurrentLimits;
            ApiResponse<Status> status = this.GetStatus();
            Globals.CurrentLimits.RateLimit = status.Response.Requests.Current;
            Globals.CurrentLimits.RateLimitRemaining = status.Response.Requests.Current;
            Globals.CurrentLimits.DailyLimit = status.Response.Requests.LimitDay;
            Globals.CurrentLimits.DailyLimitRemaining = status.Response.Requests.LimitDay;
            Globals.CurrentLimits.LastRatesUpdate = DateTime.UtcNow;
            return Globals.CurrentLimits;
        }
    }
}