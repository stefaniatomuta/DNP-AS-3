using System.Threading.Tasks;
using Models;

namespace FamilyManagerWebAPI.Repository {
    public interface IUserRepo {
        Task<User> get(string username, string password);
        Task<User> add(User user);
    }
}