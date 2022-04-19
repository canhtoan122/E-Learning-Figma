using System.ComponentModel.DataAnnotations;

namespace E_Library.Model
{
    public class SchoolYear
    {
        [Key]
        public int SchoolYearID { get; set; }
        public string Serial { get; set; } = string.Empty;
        public string SchoolYearTime { get; set; } = string.Empty;
        public string StartingDate { get; set; } = string.Empty;
        public string EndingDate { get; set; } = string.Empty;
        public string SemesterName { get; set; } = string.Empty;
        public string SemesterStartDate { get; set; } = string.Empty;
        public string SemesterEndDate { get; set; } = string.Empty;
    }
}
