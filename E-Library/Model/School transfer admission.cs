using System.ComponentModel.DataAnnotations;

namespace E_Library.Model
{
    public class School_transfer_admission
    {
        [Key]
        public int School_transfer_admission_ID { get; set; }
        public string Student_name { get; set; } = string.Empty;
        public string Student_code { get; set; } = string.Empty;
        public string Date_of_birth { get; set; } = string.Empty;
        public string Sex { get; set; } = string.Empty;
        public string Transfer_date { get; set; } = string.Empty;
        public string Transfer_semester { get; set; } = string.Empty;
        public string Province_city { get; set; } = string.Empty;
        public string District { get; set; } = string.Empty;
        public string Transfer_from { get; set; } = string.Empty;
        public string Transfer_reason { get; set; } = string.Empty;
        public string Department { get; set; } = string.Empty;
    }
}
