using System.ComponentModel.DataAnnotations;

namespace E_Library.Model
{
    public class Subject_group
    {
        [Key]
        public int Subject_group_ID { get; set; }
        public string Subject_group_name { get; set; } = string.Empty;
        public string Head_of_department { get; set; } = string.Empty;
        public Subject Subject { get; set; }
    }
}
