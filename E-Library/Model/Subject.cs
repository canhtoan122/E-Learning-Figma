using System.ComponentModel.DataAnnotations;

namespace E_Library.Model
{
    public class Subject
    {
        [Key]
        public int SubjectID { get; set; }
        public string SubjectCode { get; set; } = string.Empty;
        public string SubjectName { get; set; } = string.Empty;
        public string SubjectType { get; set; } = string.Empty;
        public string FirstSemesterLession { get; set; } = string.Empty;
        public string SecondSemesterLession { get; set; } = string.Empty;
    }
}
