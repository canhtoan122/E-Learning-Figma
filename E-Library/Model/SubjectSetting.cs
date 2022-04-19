using System.ComponentModel.DataAnnotations;

namespace E_Library.Model
{
    public class SubjectSetting
    {
        [Key]
        public int SubjectSettingID { get; set; }
        public string SubjectType { get; set; } = string.Empty;
        public string Notification { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
    }
}
