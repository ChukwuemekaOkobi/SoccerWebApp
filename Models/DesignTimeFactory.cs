using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace SoccerWebApp.Models
{

public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<SoccerWebAppContext>
    {
        public SoccerWebAppContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var builder = new DbContextOptionsBuilder<SoccerWebAppContext>();

            var connectionString = configuration.GetConnectionString("SoccerWebAppContext");

            builder.UseSqlServer(connectionString);

            return new SoccerWebAppContext(builder.Options);
        }
    }
}
