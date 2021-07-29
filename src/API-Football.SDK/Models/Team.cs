
namespace API_Football.SDK.Models
{
    public class Team
    {
        public uint Id { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public ushort Founded { get; set; }
        public bool National { get; set; }
        public string Logo { get; set; }
    }
}
