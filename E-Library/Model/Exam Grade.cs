using System.ComponentModel.DataAnnotations;

namespace E_Library.Model
{
    public class Exam_Grade
    {
        [Key]
        public int Exam_Grade_ID { get; set; }
        public string Attendance_grade { get; set; } = string.Empty;
        public string Oral_test { get; set; } = string.Empty;
        public string A_quarter_hour_test { get; set; } = string.Empty;
        public string Half_hour_test { get; set; } = string.Empty;
        public string Mid_term_test { get; set; } = string.Empty;
        public string Final_test_test { get; set; } = string.Empty;
        public string Year_average_grade { get; set; } = string.Empty;
        public string Pass { get; set; } = string.Empty;
        public string Update_date { get; set; } = string.Empty;
    }
}
