using System;
using System.Collections.Generic;
using System.Text;

namespace API_Football.SDK.Models
{
    public class Coverage
    {
        public Fixtures Fixtures { get; set; }
        public bool Standings { get; set; }
        public bool Players { get; set; }
        public bool TopScores { get; set; }
        public bool TopAssists { get; set; }
        public bool TopCards { get; set; }
        public bool Injuries { get; set; }
        public bool Predictions { get; set; }
        public bool Odds { get; set; }

    }
}