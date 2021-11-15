using System.ComponentModel.DataAnnotations;

namespace Models {
    public class User {
        [Key]
        public string Username { get; set; }
        public string Password { get; set; }
        public Role Role { get; set; }
    }
}