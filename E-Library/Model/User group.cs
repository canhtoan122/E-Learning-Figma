using System.ComponentModel.DataAnnotations;

namespace E_Library.Model
{
    public class User_group
    {
        [Key]
        public int User_ID { get; set; }
        public string Group_name { get; set; } = string.Empty;
        public string Notification { get; set; } = string.Empty;
        public bool Decentralization { get; set; }
        public bool Data_declaration { get; set; }
        public bool Student_profile { get; set; }
        public bool Teacher_profile { get; set; }
        public bool Examination { get; set; }
        public bool System_update { get; set; }
    }
}
