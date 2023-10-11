using Microsoft.EntityFrameworkCore;
using PlatformService.Models;

namespace PlatformService.Data
{
    public class AppDatabaseContext : DbContext
    {
        public AppDatabaseContext(DbContextOptions<AppDatabaseContext> opt) : base(opt)
        {
        }

        public DbSet<Platform> Platforms { get; set; }
    }
}