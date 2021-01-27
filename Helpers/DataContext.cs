using Microsoft.EntityFrameworkCore;
using AssetB.Models;
using Microsoft.Extensions.Configuration;


namespace AssetB.Helpers
{
    public class DataContext : DbContext
    {
        protected readonly IConfiguration Configuration;

        public DataContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            // connect to sql server database
            options.UseSqlServer(Configuration.GetConnectionString("WebApiDatabase"));
        }

        public DbSet<User> Users { get; set; }
        public DbSet<AssetMaintain> AssetMaintains {get; set;}
        public DbSet<Asset_Kind1> Asset_Kinds {get; set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasKey(e => e.Id);
            modelBuilder.Entity<AssetMaintain>().HasKey(e => e.Asset_ID);
            modelBuilder.Entity<Asset_Kind1>().HasKey(e => e.kind);
        }
        
    }
}