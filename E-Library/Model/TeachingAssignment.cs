using System.ComponentModel.DataAnnotations;

namespace E_Library.Model
{
    public class TeachingAssignment
    {
        [Key]
        public int TeachingAssignmentID { get; set; }
        public string Classroom { get; set; } = string.Empty;
        public string StartingDate { get; set; } = string.Empty;
        public string EndingDate { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        //public IEnumerable<Subject> Subject { get; set; }
        //public IEnumerable<Teacher> Teacher { get; set; }

    }
}
