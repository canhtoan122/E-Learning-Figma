using System.ComponentModel.DataAnnotations;

namespace E_Library.Model
{
    public class Manage_Exam_Schedule
    {
        [Key]
        public int Manage_Exam_Schedule_ID { get; set; }
        public string Semester { get; set; } = string.Empty;
        public string Exam_date { get; set; } = string.Empty;
        public string Department { get; set; } = string.Empty;
        public string Exam_subject { get; set; } = string.Empty;
        public string Exam_name { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public string Exam_marking_assignment { get; set; } = string.Empty;
    }
}
