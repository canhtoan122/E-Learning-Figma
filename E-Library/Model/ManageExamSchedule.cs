using System.ComponentModel.DataAnnotations;

namespace E_Library.Model
{
    public class ManageExamSchedule
    {
        [Key]
        public int ManageExamScheduleID { get; set; }
        public string Semester { get; set; } = string.Empty;
        public string ExamDate { get; set; } = string.Empty;
        public string Department { get; set; } = string.Empty;
        public string ExamSubject { get; set; } = string.Empty;
        public string ExamName { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public string ExamMarkingAssignment { get; set; } = string.Empty;
    }
}
