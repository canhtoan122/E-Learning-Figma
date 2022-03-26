using System.ComponentModel.DataAnnotations;

namespace E_Library.Model
{
    public class Class
    {
        [Key]
        public int Class_ID { get; set; }
        public string Class_code { get; set; } = string.Empty;
        public string Class_name { get; set; } = string.Empty;
        public string Homeroom_teacher { get; set; } = string.Empty;
        public string Student_number { get; set; } = string.Empty;
        public string Class_classify { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public ICollection<School_year> School_year { get; set; }
        public ICollection<Subject> Subject { get; set; }
    }
}
