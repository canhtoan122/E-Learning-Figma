using System.ComponentModel.DataAnnotations;

namespace E_Library.Model
{
    public class Course
    {
        [Key]
        public int CourseID { get; set; }
        public string CompletedCourse { get; set; } = string.Empty;
        public string UncompletedCourse { get; set; } = string.Empty;

    }
}
