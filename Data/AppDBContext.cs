using HeroAPI.Model;
using Microsoft.EntityFrameworkCore;

namespace HeroAPI.Data
{
    public class AppDBContext : DbContext
    {   
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {

        }

        public DbSet<Hero> Heroes { get; set; }
    }
}
