using System.ComponentModel.DataAnnotations;

namespace E_Library.Model
{
    public class Reservation_Record
    {
        [Key]
        public int Reservation_Record_ID { get; set; }
        public string Student_code { get; set; } = string.Empty;
        public string Student_name { get; set; } = string.Empty;
        public string Date_of_birth { get; set; } = string.Empty;
        public string Sex { get; set; } = string.Empty;
        public string Reserve_class { get; set; } = string.Empty;
        public string Reserve_date { get; set; } = string.Empty;
        public string Reserve_period { get; set; } = string.Empty;
        public string Reserve_reason { get; set; } = string.Empty;
    }
}
