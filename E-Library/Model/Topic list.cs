using System.ComponentModel.DataAnnotations;

namespace E_Library.Model
{
    public class Topic_list
    {
        [Key]
        public int Topic_list_ID { get; set; }
        public string Topic { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Ending_date { get; set; } = string.Empty;
    }
}
