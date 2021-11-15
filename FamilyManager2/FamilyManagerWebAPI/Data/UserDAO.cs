using System;
using System.Threading.Tasks;
using FamilyManagerWebAPI.Persistance;
using Microsoft.EntityFrameworkCore;
using Models;

namespace FamilyManagerWebAPI.Data {
    public class UserDAO : IUserDAO {
        public async Task<User> AddAsync(User user) {
            using UserContext context = new UserContext();

            User existing = await context.Users.FirstOrDefaultAsync(u =>
                u.Username.Equals(user.Username));
            
            if (existing != null) throw new Exception("That username is already taken");
            
            await context.Users.AddAsync(user);
            await context.SaveChangesAsync();
            return user;
        }

        public async Task<User> ReadAsync(string username, string password) {
            using UserContext context = new UserContext();

            User user = await context.Users.FirstOrDefaultAsync(u =>
                u.Username.Equals(username) && u.Password.Equals(password));
            
            if (user == null) throw new NullReferenceException("No such user found");
            
            return user;
        }
    }
}