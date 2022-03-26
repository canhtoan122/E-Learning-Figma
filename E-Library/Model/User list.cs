using System.ComponentModel.DataAnnotations;

namespace E_Library.Model
{
    public class User_list
    {
        [Key]
        public int User_list_ID { get; set; }
        public string Username { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string User_group { get; set; } = string.Empty;
    }
}
