using System;
using System.Threading.Tasks;
using FamilyManagerWebAPI.Persistance;
using Microsoft.EntityFrameworkCore;
using Models;

namespace FamilyManagerWebAPI.Data {
    public class UserDAO : IUserDAO {
        public async Task<User> AddUserAsync(User user) {
            using UserContext context = new UserContext();

            User existing = await context.Set<User>().FirstOrDefaultAsync(u =>
                u.Username.Equals(user.Username));
            
            if (existing != null) throw new Exception("That username is already taken");
            
            await context.Set<User>().AddAsync(user);
            await context.SaveChangesAsync();
            return user;
        }

        public async Task<User> GetUserAsync(string username, string password) {
            using UserContext context = new UserContext();

            User user = await context.Set<User>().FirstOrDefaultAsync(u =>
                u.Username.Equals(username) && u.Password.Equals(password));
            
            if (user == null) throw new NullReferenceException("No such user found");
            
            return user;
        }
    }
}