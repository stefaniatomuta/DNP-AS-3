using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using Models;

namespace FamilyManagerWebAPI.Data {
    public class UserFileContext {
        private string UsersFile = "Data/users.json";
        public List<User> users { get; set; }
        
        public UserFileContext() {
            if (!File.Exists(UsersFile)) {
                seed();
                WriteUsersToFile();
            }
            else {
                string content = File.ReadAllText(UsersFile);
                users = JsonSerializer.Deserialize<List<User>>(content);
            }
        }

        private void seed() {
            users = new List<User>();
            users.Add(new User() {
                Username = "Adriana",
                Password = "1234",
                Role = Role.Admin
            });
        }
        
        public void WriteUsersToFile() {
            string usersAsJson = JsonSerializer.Serialize(users, new JsonSerializerOptions() {
                WriteIndented = true
            });
            File.WriteAllText(UsersFile, usersAsJson);
        }
        
        
    }
}