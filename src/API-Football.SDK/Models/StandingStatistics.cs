namespace API_Football.SDK.Models
{
    public class StandingStatistics
    {
        public ushort Played { get; set; }
        public ushort Win { get; set; }
        public ushort Draw { get; set; }
        public ushort Lose { get; set; }
        public StandingGoals Goals { get; set; }
    }
}
