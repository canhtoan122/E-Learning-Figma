using System.ComponentModel.DataAnnotations;

namespace E_Library.Model
{
    public class Grade
    {
        [Key]
        public int GradeID { get; set; }
        public string GradeName { get; set; } = string.Empty;
        public string ScoreFactor { get; set; } = string.Empty;
        public string MinimumNumberOfColumnsForSemester1 { get; set; } = string.Empty;
        public string MinimumNumberOfColumnsForSemester2 { get; set; } = string.Empty;
    }
}
