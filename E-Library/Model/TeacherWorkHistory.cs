using System.ComponentModel.DataAnnotations;

namespace E_Library.Model
{
    public class TeacherWordHistory
    {
        [Key]
        public int TeacherWordHistoryID { get; set; }
        public string Teacher { get; set; } = string.Empty;
        public string Agency { get; set; } = string.Empty;
        public string Position { get; set; } = string.Empty;
        public DateTime StartingDate { get; set; }
        public DateTime EndingDate { get; set; }
        //public IEnumerable<Subject_group> Subject_group { get; set; }
    }
}
