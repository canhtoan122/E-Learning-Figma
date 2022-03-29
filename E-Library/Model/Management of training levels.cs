using System.ComponentModel.DataAnnotations;

namespace E_Library.Model
{
    public class Management_of_training_levels
    {
        [Key]
        public int Management_of_training_levels_ID { get; set; }
        public string Degree_training { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public string Form_of_training { get; set; } = string.Empty;
        public string Training_time { get; set; } = string.Empty;
        public string Notification { get; set; } = string.Empty;
    }
}
