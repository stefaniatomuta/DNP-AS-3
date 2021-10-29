using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Models;

namespace FamilyManagerWebAPI.Data {
    public class UserDAO : IUserDAO {
        private UserFileContext fileContext;

        public UserDAO() {
            fileContext = new UserFileContext();
        }

        public async Task<User> GetUserAsync(string username, string password) {
            User user = fileContext.users.FirstOrDefault(
                u => u.Username.Equals(username) && u.Password.Equals(password));
            if (user == null)
                throw new NullReferenceException("No user found");
            return user;
        }

        public async Task<User> AddUserAsync(User user) {
            User first = fileContext.users.FirstOrDefault(u => u.Username.Equals(user.Username, StringComparison.CurrentCultureIgnoreCase));
            if (first!=null && first.Equals(user))
                throw new Exception("User already exists");
            fileContext.users.Add(user);
            fileContext.WriteUsersToFile();
            return first;
        }
    }
}