using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SoccerWebApp.Models
{
    public class Tipster
    {
        public int TipsterId { get; set; }
        [Required]
        public string Name { get; set; }

        public string Nickname { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }


        [Phone]
        [Required]
        [Display(Name = "Phone Number")]
        public string Mobile { get; set; }

        [Phone]
        [Required]
        [Display(Name = "Office Number")]
        public string Office { get; set; }

        public virtual ICollection<PredictionData> Predictions { get; set; }
    }
}
