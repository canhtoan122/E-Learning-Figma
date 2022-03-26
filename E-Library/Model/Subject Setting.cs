using System.ComponentModel.DataAnnotations;

namespace E_Library.Model
{
    public class Subject_setting
    {
        [Key]
        public int Subject_setting_ID { get; set; }
        public string Subject_type { get; set; } = string.Empty;
        public string Notification { get; set; } = string.Empty;
    }
}
