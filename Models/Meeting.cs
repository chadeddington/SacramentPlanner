using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SacramentPlanner.Models
{
    public class Meeting
    {
        public int ID { get; set; }
        [DataType(DataType.Date)]
        [Required]
        public int Date { get; set; }
        [Required]
        public string Conductor { get; set; }
        [Range(1, 341)]
        [Display(Name = "Opening Hymn")]
        [Required]
        public string OpeningHymn { get; set; }

        [Display(Name = "Opening Prayer")]
        [Required]
        public string OpeningPrayer { get; set; }

        [Range(1, 341)]
        [Display(Name = "Sacrament Hymn")]
        [Required]
        public string SacramentHymn { get; set; }

        [Range(1, 341)]
        [Display(Name = "Intermediate Hymn/Musical Number")]
        public string IntermediateHymn { get; set; }

        [Display(Name = "Closing Hymn")]
        [Required]
        public string ClosingHymn { get; set; }
        [Display(Name = "Closing Prayer")]
        [Required]
        public string ClosingPrayer { get; set; }

        /*Navigation Property*/
        public List<Speaker> Speakers { get; set; }
    }
}
