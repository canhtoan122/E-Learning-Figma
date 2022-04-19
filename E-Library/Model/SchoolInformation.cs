using System.ComponentModel.DataAnnotations;

namespace E_Library.Model
{
    public class SchoolInformation
    {
        [Key]
        public int SchoolInformationID { get; set; }
        public string SchoolName { get; set; } = string.Empty;
        public string SchoolCode { get; set; } = string.Empty;
        public string ProvinceCity { get; set; } = string.Empty;
        public string Ward { get; set; } = string.Empty;
        public string District { get; set; } = string.Empty;
        public string Headquarter { get; set; } = string.Empty;
        public string SchoolType { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string Fax { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string FoundedDate { get; set; } = string.Empty;
        public string SchoolEstablishmentModel { get; set; } = string.Empty;
        public string Website { get; set; } = string.Empty;
        public string Principal { get; set; } = string.Empty;
        public string PrincipalPhoneNumber { get; set; } = string.Empty;
        public string FacilityName { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string SchoolPhoneNumber { get; set; } = string.Empty;
        public string PersonInCharge { get; set; } = string.Empty;
        public string CellphoneNumber { get; set; } = string.Empty;
    }
}
