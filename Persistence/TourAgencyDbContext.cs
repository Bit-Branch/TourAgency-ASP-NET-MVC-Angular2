using Microsoft.EntityFrameworkCore;
using TourAgency.Core.Models;

namespace TourAgency.Persistence
{
    public class TourAgencyDbContext : DbContext
    {
        public DbSet<Country> Countries { get; set; }
        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Person> People { get; set; }
        public DbSet<Sale> Sales { get; set; }
        public DbSet<Tour> Tours { get; set; }

        public TourAgencyDbContext(DbContextOptions<TourAgencyDbContext> options) 
          : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {
            
        }
    }
}