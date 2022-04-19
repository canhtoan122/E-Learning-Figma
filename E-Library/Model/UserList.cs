using System.ComponentModel.DataAnnotations;

namespace E_Library.Model
{
    public class UserList
    {
        [Key]
        public int UserListID { get; set; }
        public string Username { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string UserGroup { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
    }
}
