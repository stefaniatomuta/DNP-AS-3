using System.Threading.Tasks;
using Models;

namespace FamilyManagerWebAPI.Repository {
    public interface IUserRepo {
        Task<User> GetUserAsync(string username, string password);
        Task<User> AddUserAsync(User user);
    }
}