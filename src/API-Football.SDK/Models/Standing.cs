using System;

namespace API_Football.SDK.Models
{
    public class Standing
    {
        public ushort Rank { get; set; }
        public Team Team { get; set; }
        public ushort Points { get; set; }
        public ushort GoalsDiff { get; set; }
        public string Group { get; set; }
        public string Form { get; set; }
        public string Status { get; set; }
        public string Description { get; set; }
        public StandingStatistics All { get; set; }
        public StandingStatistics Home { get; set; }
        public StandingStatistics Away { get; set; }

        public DateTime Update { get; set; }
    }
}