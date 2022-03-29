using System.ComponentModel.DataAnnotations;

namespace E_Library.Model
{
    public class Class_History
    {
        [Key]
        public int Class_History_ID { get; set; }
        public string Teacher { get; internal set; }
        public string Subject { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Class { get; set; } = string.Empty;
        public string Class_schedule { get; set; } = string.Empty;
        public string Starting_date { get; set; } = string.Empty;
        public string Ending_date { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public string Exam_date { get; set; } = string.Empty;
        public string CLass_code { get; set; } = string.Empty;
        public string Security_password { get; set; } = string.Empty;
        public string Other_setting { get; set; } = string.Empty;
        public string Shared_link { get; set; } = string.Empty;
    }
}
