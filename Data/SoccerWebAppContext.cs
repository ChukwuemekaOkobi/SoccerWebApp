using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SoccerWebApp.Models;

namespace SoccerWebApp.Models
{
    public class SoccerWebAppContext : DbContext
    {
        public SoccerWebAppContext (DbContextOptions<SoccerWebAppContext> options)
            : base(options)
        {
        }

        public DbSet<SoccerWebApp.Models.Tipster> Tipster { get; set; }

        public DbSet<SoccerWebApp.Models.Match> Match { get; set; }

        public DbSet<SoccerWebApp.Models.PredictionData> PredictionDatas { get; set; }

        public DbSet<Bank> Banks { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
       //     modelBuilder.Entity<PredictionData>().ToTable("Predictions");
        }
    }
}
