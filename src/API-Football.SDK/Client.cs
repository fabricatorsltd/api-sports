using Newtonsoft.Json;
using System;
using System.Net;

namespace API_Football.SDK
{
    internal class Client
    {
        public Client(string apiKey)
        {
            Globals.ApiKey = apiKey;
        }
        public Client(string apiKey, string timezone)
        {
            Globals.ApiKey = apiKey;
            Globals.Timezone = timezone;
        }

        public ApiResponse<T> Get<T>(string endpoint)
        {
            using var client = new WebClient();
            if (!string.IsNullOrWhiteSpace(Globals.ApiKey))
                client.Headers.Set("x-apisports-key", Globals.ApiKey);
            if (!string.IsNullOrWhiteSpace(Globals.Timezone))
                endpoint += $"&timezone={Globals.Timezone}";

            try
            {
                var json = client.DownloadString(Globals.BaseUrlV3 + endpoint);
                if (client.ResponseHeaders.Get("X-RateLimit-Limit") != null)
                {
                    Globals.CurrentLimits.RateLimit = uint.Parse(client.ResponseHeaders.Get("X-RateLimit-Limit"));
                    Globals.CurrentLimits.RateLimitRemaining = uint.Parse(client.ResponseHeaders.Get("X-RateLimit-Remaining"));
                    Globals.CurrentLimits.DailyLimit = uint.Parse(client.ResponseHeaders.Get("x-ratelimit-requests-limit"));
                    Globals.CurrentLimits.DailyLimitRemaining = uint.Parse(client.ResponseHeaders.Get("x-ratelimit-requests-remaining"));
                    Globals.CurrentLimits.LastRatesUpdate = DateTime.UtcNow;
                }
                return JsonConvert.DeserializeObject<ApiResponse<T>>(json);
            }
            catch(WebException webEx)
            {
                HttpWebResponse res = (HttpWebResponse)webEx.Response;

                return new ApiResponse<T>()
                {
                    StatusCode = res.StatusCode,
                    Message = webEx.Message
                };
            }
            catch (Exception ex)
            {
                return new ApiResponse<T>()
                {
                    StatusCode = HttpStatusCode.BadRequest,
                    Message = ex.Message
                };
            }
        }
    }
}
