using System.Threading.Tasks;
using FamilyManagerWebAPI.Data;
using Models;

namespace FamilyManagerWebAPI.Repository {
    public class UserRepo : IUserRepo {
        private IUserDAO userDao;

        public UserRepo() {
            userDao = new UserDAO();
        }
        
        public async Task<User> get(string username, string password) {
            throw new System.NotImplementedException();
        }

        public async Task<User> add(User user) {
            throw new System.NotImplementedException();
        }
    }
}