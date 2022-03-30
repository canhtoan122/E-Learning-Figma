using System.ComponentModel.DataAnnotations;

namespace E_Library.Model
{
    public class Course
    {
        [Key]
        public int Course_ID { get; set; }
        public string Completed_course { get; set; } = string.Empty;
        public string Uncompleted_course { get; set; } = string.Empty;

    }
}
