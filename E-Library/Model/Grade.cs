using System.ComponentModel.DataAnnotations;

namespace E_Library.Model
{
    public class Grade
    {
        [Key]
        public int Grade_ID { get; set; }
        public string Grade_name { get; set; } = string.Empty;
        public string Score_factor { get; set; } = string.Empty;
        public string Minimum_number_of_columns_for_semester_1 { get; set; } = string.Empty;
        public string Minimum_number_of_columns_for_semester_2 { get; set; } = string.Empty;
    }
}
