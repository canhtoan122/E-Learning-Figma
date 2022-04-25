using System.ComponentModel.DataAnnotations;

namespace E_Library.Model
{
    public class Department
    {
        [Key]
        public int DepartmentID { get; set; }
        public string DepartmentCode { get; set; } = string.Empty;
        public string DepartmentName { get; set; } = string.Empty;
        public string Dean { get; set; } = string.Empty;

    }
}
