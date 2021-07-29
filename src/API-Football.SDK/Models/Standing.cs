using System;
using System.Collections.Generic;
using System.Text;

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

    public class StandingStatistics
    {
        public ushort Played { get; set; }
        public ushort Win { get; set; }
        public ushort Draw { get; set; }
        public ushort Lose { get; set; }
        public StandingGoals Goals { get; set; }
    }

    public class StandingGoals
    {
        public ushort For { get; set; }
        public ushort Agains { get; set; }
    }
}
