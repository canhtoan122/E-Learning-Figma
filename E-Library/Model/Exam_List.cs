using System.ComponentModel.DataAnnotations;

namespace E_Library.Model
{
    public class Exam_List
    {
        [Key]
        public int Exam_List_ID { get; set; }
        public string Topic { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Teaching_Assistant { get; set; } = string.Empty;
        public string Exam_amount_of_time { get; set; } = string.Empty;
        public string Starting_date { get; set; } = string.Empty;
        public string Ending_date { get; set; } = string.Empty;
        public string Security_password { get; set; } = string.Empty;
        public string Other_setting { get; set; } = string.Empty;
        public string Shared_link { get; set; } = string.Empty;
        public string Class { get; set; } = string.Empty;
        public string Exam_content { get; set; } = string.Empty;
        public string Subject { get; set; } = string.Empty;
        public string Department { get; set; } = string.Empty;
    }
}
