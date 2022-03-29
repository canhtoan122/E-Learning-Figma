using System.ComponentModel.DataAnnotations;

namespace E_Library.Model
{
    public class Help
    {
        [Key]
        public int Help_ID { get; set; }
        public string Topic { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }
}
