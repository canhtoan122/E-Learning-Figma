using System.ComponentModel.DataAnnotations;

namespace E_Library.Model
{
    public class Subject
    {
        [Key]
        public int Subject_ID { get; set; }
        public string Subject_code { get; set; } = string.Empty;
        public string Subject_name { get; set; } = string.Empty;
        public string Subject_type { get; set; } = string.Empty;
        public string First_semester_lession { get; set; } = string.Empty;
        public string Second_semester_lession { get; set; } = string.Empty;
    }
}
