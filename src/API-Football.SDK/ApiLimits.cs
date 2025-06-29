using System;

namespace API_Football.SDK
{
    public sealed class ApiLimits
    {
        public uint RateLimit { get; set; }

        public uint RateLimitRemaining { get; set; }

        public uint DailyLimit { get; set; }

        public uint DailyLimitRemaining { get; set; }

        public DateTime LastRatesUpdate { get; set; }
    }
}