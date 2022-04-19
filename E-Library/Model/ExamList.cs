using System.ComponentModel.DataAnnotations;

namespace E_Library.Model
{
    public class ExamList
    {
        [Key]
        public int ExamListID { get; set; }
        public string Topic { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string TeachingAssistant { get; set; } = string.Empty;
        public string ExamAmountOfTime { get; set; } = string.Empty;
        public string StartingDate { get; set; } = string.Empty;
        public string EndingDate { get; set; } = string.Empty;
        public string SecurityPassword { get; set; } = string.Empty;
        public string OtherSetting { get; set; } = string.Empty;
        public string SharedLink { get; set; } = string.Empty;
        public string Class { get; set; } = string.Empty;
        public string ExamContent { get; set; } = string.Empty;
        public string Subject { get; set; } = string.Empty;
        public string Department { get; set; } = string.Empty;
    }
}
