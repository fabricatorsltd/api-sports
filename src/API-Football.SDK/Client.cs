using Newtonsoft.Json;
using System;
using System.Net;

namespace API_Football.SDK
{
    internal class Client
    {
        public ApiResponse<T> Get<T>(string endpoint)
        {
            using var client = new WebClient();
            if (!string.IsNullOrWhiteSpace(Globals.ApiKey))
                client.Headers.Set("x-apisports-key", Globals.ApiKey);

            try
            {
                var json = client.DownloadString(Globals.BaseUrlV3 + endpoint);
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
