using Microsoft.EntityFrameworkCore;
using Models;


namespace FamilyManagerWebAPI.Persistance {
    
    public class UserContext : DbContext {
        public DbSet<User> Users { get; set; }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            optionsBuilder.UseSqlite("Data Source = Users.db");
        }
    }
}