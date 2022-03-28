using System.ComponentModel.DataAnnotations;

namespace E_Library.Model
{
    public class Teacher_word_history
    {
        [Key]
        public int Teacher_word_history_ID { get; set; }
        public string Teacher { get; set; } = string.Empty;
        public string Agency { get; set; } = string.Empty;
        public string Position { get; set; } = string.Empty;
        public DateTime Starting_date { get; set; }
        public DateTime Ending_date { get; set; }
        //public IEnumerable<Subject_group> Subject_group { get; set; }
    }
}
