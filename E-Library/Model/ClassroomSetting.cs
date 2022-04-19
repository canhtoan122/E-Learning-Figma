using System.ComponentModel.DataAnnotations;

namespace E_Library.Model
{
    public class ClassroomSetting
    {
        [Key]
        public int ClassroomSettingID { get; set; }
        public string SubjectType { get; set; } = string.Empty;
        public string Notification { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
    }
}
