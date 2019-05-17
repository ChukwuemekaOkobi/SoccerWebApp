using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SoccerWebApp.Models;

namespace SoccerWebApp.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
        }
            //    using (var context = new SoccerWebAppContext(
            //        serviceProvider.GetRequiredService<DbContextOptions<SoccerWebAppContext>>()))
            //    {
            //       // context.Database.EnsureCreated();
            //        // Look for any movies.
            //        if (context.Tipster.Any())
            //        {
            //            return;
            //        }
            //        context.Tipster.AddRange(
            //            new Tipster { Name = "Daniel", Email = "Daniel@gmail.com", PhoneNumber = "08125724524" },
            //            new Tipster { Name = "Jude", Email = "jude@gmail.com", PhoneNumber = "08095724320" },
            //            new Tipster { Name = "Michael", Email = "Michael@gmail.com", PhoneNumber = "07012572590" }
            //            );
            //        context.SaveChanges();
            //        context.Match.AddRange(
            //            new Match {  MatchName = "Man Utd vs Arsenal"},
            //            new Match {  MatchName = "Chelsea vs Man City"},
            //            new Match {  MatchName = "StokeCity vs Swansea"}
            //            );
            //        context.SaveChanges();
            //        context.Prediction.AddRange(
            //            new Prediction { TipsterID = 1, MatchID = 1 , predictionDate = DateTime.Parse("2018-03-01"),matchOutcome= Outcome.GG },
            //            new Prediction { TipsterID = 1, MatchID = 2, predictionDate = DateTime.Parse("2018-04-01"), matchOutcome = Outcome.Two },
            //            new Prediction { TipsterID = 1, MatchID = 3, predictionDate = DateTime.Parse("2018-03-11"), matchOutcome = Outcome.One },
            //            new Prediction { TipsterID = 2, MatchID = 1, predictionDate = DateTime.Parse("2018-05-01"), matchOutcome = Outcome.Ov1_5 },
            //            new Prediction { TipsterID = 2, MatchID = 3, predictionDate = DateTime.Parse("2018-06-11"), matchOutcome = Outcome.Ov1_5 },
            //            new Prediction { TipsterID = 2, MatchID = 2, predictionDate = DateTime.Parse("2018-05-12"), matchOutcome = Outcome.GG },
            //            new Prediction { TipsterID = 3, MatchID = 1, predictionDate = DateTime.Parse("2018-08-25"), matchOutcome = Outcome.One },
            //            new Prediction { TipsterID = 3, MatchID = 3, predictionDate = DateTime.Parse("2018-09-21"), matchOutcome = Outcome.Two }

            //        );
            //        context.SaveChanges();
            //    }
            //}

        }
}
