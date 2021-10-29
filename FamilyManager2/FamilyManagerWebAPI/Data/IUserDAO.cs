using System.Collections.Generic;
using System.Threading.Tasks;
using Models;

namespace FamilyManagerWebAPI.Data {
    public interface IUserDAO {
        Task<User> AddUserAsync(User user);
        Task<User> GetUserAsync(string username, string password);
    }
}