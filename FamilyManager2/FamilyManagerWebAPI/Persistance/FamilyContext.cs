using Microsoft.EntityFrameworkCore;
using Models;

namespace FamilyManagerWebAPI.Persistance {
    public class FamilyContext : DbContext {
        public DbSet<Family> Families { get; set; }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            optionsBuilder.UseSqlite("Data Source = Families.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.Entity<Family>().HasKey(c => new {
                c.HouseNumber, c.StreetName
            });
            modelBuilder.Entity<Job>().HasKey(c => new {
                c.Salary, c.JobTitle
            });
            modelBuilder.Entity<Interest>().HasKey(c => new {
                c.Description, c.Type
            });
        }
    }
}