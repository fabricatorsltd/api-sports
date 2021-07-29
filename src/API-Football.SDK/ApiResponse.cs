using System.Collections.Generic;
using System.Net;

namespace API_Football.SDK
{
    public class ApiResponse<T>
    {
        public HttpStatusCode StatusCode { get; set; } = HttpStatusCode.OK;

        public string Message { get; set; } = "OK";

        public string Get { get; set; }
        public Dictionary<string, string> Parameters { get; set; }
        public Dictionary<string, string> Errors { get; set; }
        public uint Results { get; set; }
        public Models.Paging Paging { get; set; }
        public List<T> Response { get; set; }
    }
}