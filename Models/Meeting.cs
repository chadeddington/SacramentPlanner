using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SacramentPlanner.Models
{
    public class Meeting
    {
        public int ID { get; set; }
        public int Date { get; set; }
        public string Conductor { get; set; }
        public string OpeningHymn { get; set; }
        public string OpeningPrayer { get; set; }
        public string SacramentHymn { get; set; }
        public string IntermediateHymn { get; set; }
        public string ClosingHymn { get; set; }
        public string ClosingPrayer { get; set; }
    }
}
