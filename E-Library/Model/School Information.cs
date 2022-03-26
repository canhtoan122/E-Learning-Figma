using System.ComponentModel.DataAnnotations;

namespace E_Library.Model
{
    public class School_Information
    {
        [Key]
        public int School_Information_ID { get; set; }
        public string School_name { get; set; } = string.Empty;
        public string School_code { get; set; } = string.Empty;
        public string Province_city { get; set; } = string.Empty;
        public string Ward { get; set; } = string.Empty;
        public string District { get; set; } = string.Empty;
        public string Headquarter { get; set; } = string.Empty;
        public string School_type { get; set; } = string.Empty;
        public string Phone_number { get; set; } = string.Empty;
        public string Fax { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Founded_date { get; set; } = string.Empty;
        public string School_establishment_model { get; set; } = string.Empty;
        public string Website { get; set; } = string.Empty;
        public string Principal { get; set; } = string.Empty;
        public string Principal_phone_number { get; set; } = string.Empty;
        public string Facility_name { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string School_phone_number { get; set; } = string.Empty;
        public string Person_in_charge { get; set; } = string.Empty;
        public string Cellphone_number { get; set; } = string.Empty;
    }
}
