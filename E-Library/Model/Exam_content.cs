using System.ComponentModel.DataAnnotations;

namespace E_Library.Model
{
    public class Exam_content
    {
        [Key]
        public int Class_History_ID { get; set; }
        public string Subject { get; set; } = string.Empty;
        public string Class { get; set; } = string.Empty;
        public string Exam_number { get; set; } = string.Empty;
        public string Starting_date { get; set; } = string.Empty;
        public string Exam_amount_of_time { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Other_setting { get; set; } = string.Empty;
    }
}
