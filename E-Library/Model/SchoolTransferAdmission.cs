using System.ComponentModel.DataAnnotations;

namespace E_Library.Model
{
    public class SchoolTransferAdmission
    {
        [Key]
        public int SchoolTransferAdmissionID { get; set; }
        public string StudentName { get; set; } = string.Empty;
        public string StudentCode { get; set; } = string.Empty;
        public string DateOfBirth { get; set; } = string.Empty;
        public string Sex { get; set; } = string.Empty;
        public string TransferDate { get; set; } = string.Empty;
        public string TransferSemester { get; set; } = string.Empty;
        public string ProvinceCity { get; set; } = string.Empty;
        public string District { get; set; } = string.Empty;
        public string TransferFrom { get; set; } = string.Empty;
        public string TransferReason { get; set; } = string.Empty;
        public string Department { get; set; } = string.Empty;
    }
}
