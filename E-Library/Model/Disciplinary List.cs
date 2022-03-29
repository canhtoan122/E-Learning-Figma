using System.ComponentModel.DataAnnotations;

namespace E_Library.Model
{
    public class Disciplinary_list
    {
        [Key]
        public int Disciplinary_list_ID { get; set; }
        public string Student_code { get; set; } = string.Empty;
        public string Student_name { get; set; } = string.Empty;
        public string Date_of_birth { get; set; } = string.Empty;
        public string Sex { get; set; } = string.Empty;
        public string Disciplinary_number { get; set; } = string.Empty;
        public string Disciplinary_date { get; set; } = string.Empty;
        public string Disciplinary_content { get; set; } = string.Empty;
        //public IEnumerable<Student> Student { get; set; }
        //public IEnumerable<Class> Class { get; set; }
    }
}
