using System;
using System.Collections.Generic;
using System.Text;

namespace API_Football.SDK.Models
{
    public class Season
    {
        public ushort Year { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public bool Current { get; set; }
        public Coverage Coverage { get; set; }
    }    
}
