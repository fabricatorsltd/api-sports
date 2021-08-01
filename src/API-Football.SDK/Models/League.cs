namespace API_Football.SDK.Models
{
    public class League
    {
        public ushort Id { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public string Type { get; set; }
        public string Logo { get; set; }
        public string Flag { get; set; }
        public ushort Season { get; set; }
        public string Round { get; set; }
    }
}