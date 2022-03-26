using System.ComponentModel.DataAnnotations;

namespace E_Library.Model
{
    public class Disciplinary_list
    {
        [Key]
        public int Disciplinary_list_ID { get; set; }
        public string Disciplinary_date { get; set; } = string.Empty;
        public string Disciplinary_content { get; set; } = string.Empty;
        public IEnumerable<Student> Student { get; set; }
        public IEnumerable<Class> Class { get; set; }
    }
}
