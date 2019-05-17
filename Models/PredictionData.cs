using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SoccerWebApp.Models
{
    public class PredictionData
    {
      [Key]
      public int PredictionID {get;set;}
      public int TipsterID { get; set; }
      public int MatchID { get; set; }
      
    [DataType(DataType.DateTime)]
    [DisplayFormat(DataFormatString ="{0:dd/MM/yyyy}")]
    [Display(Name = "Prediction Date")]
      public DateTime predictionDate { get; set; }
      [Display(Name = " Match Outcome")]
      public Outcome? matchOutcome { get; set; }

      public virtual Tipster Tipster { get; set; }
      public virtual Match Match { get; set; }
    }

    public enum Outcome
    {
        One = 1, 
        Two = 2, 
        GG, 
        Ov1_5
    }
}
