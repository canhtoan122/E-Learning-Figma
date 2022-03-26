using System.ComponentModel.DataAnnotations;

namespace E_Library.Model
{
    public class School_year
    {
        [Key]
        public int School_year_ID { get; set; }
        public string School_year_time { get; set; } = string.Empty;
        public string Starting_date { get; set; } = string.Empty;
        public string Ending_date { get; set; } = string.Empty;
        public string Semester_name { get; set; } = string.Empty;
        public string Semester_start_date { get; set; } = string.Empty;
        public string Semester_end_date { get; set; } = string.Empty;
    }
}
