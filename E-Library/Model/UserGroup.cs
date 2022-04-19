using System.ComponentModel.DataAnnotations;

namespace E_Library.Model
{
    public class UserGroup
    {
        [Key]
        public int UserID { get; set; }
        public string GroupName { get; set; } = string.Empty;
        public string UserNumber { get; set; } = string.Empty;
        public string Notification { get; set; } = string.Empty;
        public bool Decentralization { get; set; }
        public bool DataDeclaration { get; set; }
        public bool StudentProfile { get; set; }
        public bool TeacherProfile { get; set; }
        public bool Examination { get; set; }
        public bool SystemUpdate { get; set; }
    }
}
