using System.ComponentModel.DataAnnotations;

namespace E_Library.Model
{
    public class Teacher
    {
        [Key]
        public int TeacherID { get; set; }
        public string TeacherCode { get; set; } = string.Empty;
        public string FullName { get; set; } = string.Empty;
        public DateTime DateOfBirth { get; set; }
        public string Sex { get; set; } = string.Empty;
        public string SubjectGroup { get; set; } = string.Empty;
        public string Position { get; set; } = string.Empty;
        public string Ethnic { get; set; } = string.Empty;
        public DateTime StartingDate { get; set; }
        public string Nationality { get; set; } = string.Empty;
        public string Religion { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public string Aliases { get; set; } = string.Empty;
        public string ProvinceCity { get; set; } = string.Empty;
        public string Ward { get; set; } = string.Empty;
        public string District { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public bool UnionMembers { get; set; }
        public bool PartyMembers { get; set; }
        public DateTime DateOfJoiningTheUnion { get; set; }
        public DateTime DateOfJoiningTheParty { get; set; }
        //public IEnumerable<Subject_group> Subject_group { get; set; }
        //public IEnumerable<Subject> Subject { get; set; }
    }
}
