using System.ComponentModel.DataAnnotations;

namespace E_Library.Model
{
    public class Lesson
    {
        [Key]
        public int LessonID { get; set; }
        public string LessonTopic { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string TeachingAssistant { get; set; } = string.Empty;
        public string LessionTime { get; set; } = string.Empty;
        public string StartingDate { get; set; } = string.Empty;
        public string EndingDate { get; set; } = string.Empty;
        public string SecurityPassword { get; set; } = string.Empty;
        public string OtherSetting { get; set; } = string.Empty;
        public string ShareLink { get; set; } = string.Empty;
    }
}
