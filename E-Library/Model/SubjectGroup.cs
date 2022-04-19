using System.ComponentModel.DataAnnotations;

namespace E_Library.Model
{
    public class SubjectGroup
    {
        [Key]
        public int SubjectGroupID { get; set; }
        public string SubjectGroupName { get; set; } = string.Empty;
        public string HeadOfDepartment { get; set; } = string.Empty;
        public Subject Subject { get; set; }
    }
}
