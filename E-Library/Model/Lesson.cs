using System.ComponentModel.DataAnnotations;

namespace E_Library.Model
{
    public class Lesson
    {
        [Key]
        public int Lesson_ID { get; set; }
        public string Lesson_topic { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Teaching_assistant { get; set; } = string.Empty;
        public string Lession_time { get; set; } = string.Empty;
        public string Starting_date { get; set; } = string.Empty;
        public string Ending_date { get; set; } = string.Empty;
        public string Security_password { get; set; } = string.Empty;
        public string Other_setting { get; set; } = string.Empty;
        public string Share_link { get; set; } = string.Empty;
    }
}
