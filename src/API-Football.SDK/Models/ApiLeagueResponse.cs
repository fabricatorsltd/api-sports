using System.Collections.Generic;

namespace API_Football.SDK.Models
{
    public class ApiLeagueResponse
    {
        public League League { get; set; }
        public Country Country { get; set; }
        public List<Season> Seasons { get; set; }
    }
}
