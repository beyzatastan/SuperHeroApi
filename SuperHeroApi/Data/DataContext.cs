using Microsoft.EntityFrameworkCore;
using SuperHeroApi.Models;

namespace SuperHeroApi.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=localhost;Database=SuperHeroApi;User Id=sa;Password=YourStrong@Passw0rd;TrustServerCertificate=True;");
            }
        }
        public DbSet<SuperHero> SuperHeroes { get; set; }
    }
} 

