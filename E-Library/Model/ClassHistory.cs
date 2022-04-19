using System.ComponentModel.DataAnnotations;

namespace E_Library.Model
{
    public class ClassHistory
    {
        [Key]
        public int ClassHistoryID { get; set; }
        public string Teacher { get; internal set; }
        public string Subject { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Class { get; set; } = string.Empty;
        public string ClassSchedule { get; set; } = string.Empty;
        public string StartingDate { get; set; } = string.Empty;
        public string EndingDate { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public string ExamDate { get; set; } = string.Empty;
        public string CLassCode { get; set; } = string.Empty;
        public string SecurityPassword { get; set; } = string.Empty;
        public string OtherSetting { get; set; } = string.Empty;
        public string SharedLink { get; set; } = string.Empty;
    }
}
