using Microsoft.EntityFrameworkCore;
using Models;


namespace FamilyManagerWebAPI.Persistance {
    
    public class UserContext : DbContext{
        public DbSet<Family> Families { get; set; }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            optionsBuilder.UseSqlite("Data Source = Families.db");
        }
    }
}