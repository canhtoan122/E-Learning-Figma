using System.ComponentModel.DataAnnotations;

namespace E_Library.Model
{
    public class TopicList
    {
        [Key]
        public int TopicListID { get; set; }
        public string Topic { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string EndingDate { get; set; } = string.Empty;
    }
}
