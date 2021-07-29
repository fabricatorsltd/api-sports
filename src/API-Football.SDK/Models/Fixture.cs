using System;
using System.Collections.Generic;
using System.Text;

namespace API_Football.SDK.Models
{
    public class Fixture
    {
        public ushort Id { get; set; }
        public string Timezone { get; set; }
        public DateTime Date { get; set; }
        public int Timestamp { get; set; }
    }
}
