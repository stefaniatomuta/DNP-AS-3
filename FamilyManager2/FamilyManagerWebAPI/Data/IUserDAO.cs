using System.Collections.Generic;
using System.Threading.Tasks;
using Models;

namespace FamilyManagerWebAPI.Data {
    public interface IUserDAO {
        Task<User> AddAsync(User user);
        Task<User> ReadAsync(string username, string password);
    }
}