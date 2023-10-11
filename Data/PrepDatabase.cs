using System;
using System.Data;
using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using PlatformService.Models;

namespace PlatformService.Data
{
    public static class PrepDatabase
    {
        public static void PrepPopulation(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                SeedData(serviceScope.ServiceProvider.GetService<AppDatabaseContext>());
            }
        }

        private static void SeedData(AppDatabaseContext context)
        {
            if (!context.Platforms.Any())
            {
                Console.WriteLine("Seeding Data into Database...");

                context.Platforms.AddRange(
                    new Platform() { Name = "Dot Net", Publisher = "Microsoft", Cost = "5000.00" },
                    new Platform() { Name = "SQL Server Express", Publisher = "Microsoft", Cost = "500.00" }
                );

                context.SaveChanges();
            }
            else
            {
                Console.WriteLine("Data already exists!");
            }
        }
    }
}