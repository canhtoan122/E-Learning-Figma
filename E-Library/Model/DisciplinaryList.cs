using System.ComponentModel.DataAnnotations;

namespace E_Library.Model
{
    public class DisciplinaryList
    {
        [Key]
        public int DisciplinaryListID { get; set; }
        public string StudentCode { get; set; } = string.Empty;
        public string StudentName { get; set; } = string.Empty;
        public string DateOfBirth { get; set; } = string.Empty;
        public string Sex { get; set; } = string.Empty;
        public string DisciplinaryNumber { get; set; } = string.Empty;
        public string DisciplinaryDate { get; set; } = string.Empty;
        public string DisciplinaryContent { get; set; } = string.Empty;
        //public IEnumerable<Student> Student { get; set; }
        //public IEnumerable<Class> Class { get; set; }
    }
}
