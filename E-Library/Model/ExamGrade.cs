using System.ComponentModel.DataAnnotations;

namespace E_Library.Model
{
    public class ExamGrade
    {
        [Key]
        public int ExamGradeID { get; set; }
        public string AttendanceGrade { get; set; } = string.Empty;
        public string OralTest { get; set; } = string.Empty;
        public string AQuarterHourTest { get; set; } = string.Empty;
        public string HalfHourTest { get; set; } = string.Empty;
        public string MidTermTest { get; set; } = string.Empty;
        public string FinalTestTest { get; set; } = string.Empty;
        public string YearAverageGrade { get; set; } = string.Empty;
        public string Pass { get; set; } = string.Empty;
        public string UpdateDate { get; set; } = string.Empty;
    }
}
