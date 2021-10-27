using System.Collections.Generic;
using Models;

namespace FamilyManager2UI.Data {
    public interface IUserService {
        List<User> GetUserList();
        User ValidateUser(string username, string password);
        void AddUser(User user);
    }
}