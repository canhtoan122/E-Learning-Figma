using System.ComponentModel.DataAnnotations;

namespace E_Library.Model
{
    public class ReservationRecord
    {
        [Key]
        public int ReservationRecordID { get; set; }
        public string StudentCode { get; set; } = string.Empty;
        public string StudentName { get; set; } = string.Empty;
        public string DateOfBirth { get; set; } = string.Empty;
        public string Sex { get; set; } = string.Empty;
        public string ReserveClass { get; set; } = string.Empty;
        public string ReserveDate { get; set; } = string.Empty;
        public string ReservePeriod { get; set; } = string.Empty;
        public string ReserveReason { get; set; } = string.Empty;
    }
}
