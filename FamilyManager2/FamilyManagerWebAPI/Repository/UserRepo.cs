using System.Threading.Tasks;
using FamilyManagerWebAPI.Data;
using Models;

namespace FamilyManagerWebAPI.Repository {
    public class UserRepo : IUserRepo {
        private IUserDAO userDao;

        public UserRepo() {
            userDao = new UserDAO();
        }

        public async Task<User> AddUserAsync(User user) {
            User created = await userDao.AddAsync(user);
            return created;
        }
        
        public async Task<User> GetUserAsync(string username, string password) {
            User user = await userDao.ReadAsync(username, password);
            return user;
        }
    }
}