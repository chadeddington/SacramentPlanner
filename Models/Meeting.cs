using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        public DateTime Date { get; set; }

        [Required]
        public string Conductor { get; set; }

        [Range(1, 341)]
        [Display(Name = "Opening Hymn")]
        [Required]
        public int OpeningHymn { get; set; }

        [Display(Name = "Opening Prayer")]
        [Required]
        public string OpeningPrayer { get; set; }

        [Range(1, 341)]
        [Display(Name = "Sacrament Hymn")]
        [Required]
        public int SacramentHymn { get; set; }

        
        [Display(Name = "Intermediate Hymn")]
        public string IntermediateHymn { get; set; }

        [Display(Name = "Musical Number")]
        public string MusicalNumber { get; set; }

        [Display(Name = "Closing Hymn")]
        [Required]
        public int ClosingHymn { get; set; }

        [Display(Name = "Closing Prayer")]
        [Required]
        public string ClosingPrayer { get; set; }

        /*Navigation Property*/
        public List<Speaker> Speakers { get; set; }
    }
}
