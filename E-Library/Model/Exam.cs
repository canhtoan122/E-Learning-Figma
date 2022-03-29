using System.ComponentModel.DataAnnotations;

namespace E_Library.Model
{
    public class Exam
    {
        [Key]
        public int Exam_ID { get; set; }
        public string Exam_topic { get; set; } = string.Empty;
        public string Test_form { get; set; } = string.Empty;
        public string Grade { get; set; } = string.Empty;
        public string Exam_time { get; set; } = string.Empty;
        public string Exam_classify { get; set; } = string.Empty;
        public string Starting_date { get; set; } = string.Empty;
        public string Ending_date { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Other_setting { get; set; } = string.Empty;
    }
}
