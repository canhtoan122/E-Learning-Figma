using System.ComponentModel.DataAnnotations;

namespace E_Library.Model
{
    public class Teaching_Assignment
    {
        [Key]
        public int Teaching_Assignment_ID { get; set; }
        public string Classroom { get; set; } = string.Empty;
        public string Starting_date { get; set; } = string.Empty;
        public string Ending_date { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        //public IEnumerable<Subject> Subject { get; set; }
        //public IEnumerable<Teacher> Teacher { get; set; }

    }
}
