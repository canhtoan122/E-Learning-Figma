using System.ComponentModel.DataAnnotations;

namespace E_Library.Model
{
    public class Teacher
    {
        [Key]
        public int Teacher_ID { get; set; }
        public string Teacher_code { get; set; } = string.Empty;
        public string Full_name { get; set; } = string.Empty;
        public DateTime Date_of_birth { get; set; }
        public string Sex { get; set; } = string.Empty;
        public string Ethnic { get; set; } = string.Empty;
        public DateTime Starting_date { get; set; }
        public string Nationality { get; set; } = string.Empty;
        public string Religion { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public string Aliases { get; set; } = string.Empty;
        public string Province_city { get; set; } = string.Empty;
        public string Ward { get; set; } = string.Empty;
        public string District { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Phone_number { get; set; } = string.Empty;
        public bool Union_members { get; set; }
        public bool Party_members { get; set; }
        public DateTime Date_of_joining_the_union { get; set; }
        public DateTime Date_of_joining_the_party { get; set; }
        //public IEnumerable<Subject_group> Subject_group { get; set; }
        //public IEnumerable<Subject> Subject { get; set; }
    }
}
