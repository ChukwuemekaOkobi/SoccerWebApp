using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SoccerWebApp.Models
{
    public class Match
    {
       public int MatchID { get; set; }
        [Required]
       public string MatchName { get; set; }

       public virtual ICollection<PredictionData> predictions { get; set; }
    }
}
