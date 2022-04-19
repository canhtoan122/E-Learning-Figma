using System.ComponentModel.DataAnnotations;

namespace E_Library.Model
{
    public class ListOfAward
    {
        [Key]
        public int ListOfAwardID { get; set; }
        public string StudentCode { get; set; } = string.Empty;
        public string StudentName { get; set; } = string.Empty;
        public string DateOfBirth { get; set; } = string.Empty;
        public string Sex { get; set; } = string.Empty;
        public string AwardNumber { get; set; } = string.Empty;
        public string AwardDate { get; set; } = string.Empty;
        public string AwardContent { get; set; } = string.Empty;
        //public IEnumerable<Student> Student { get; set; }
        //public IEnumerable<Class> Class { get; set; }
    }
}
