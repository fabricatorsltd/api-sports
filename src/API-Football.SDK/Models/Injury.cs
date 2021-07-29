namespace API_Football.SDK.Models
{
    public class Injury
    {
        public Player Player { get; set; }
        public Team Team { get; set; }
        public Fixture Fixture { get; set; }
        public League League { get; set; }
    }
}