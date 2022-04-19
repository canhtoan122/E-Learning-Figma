using System.ComponentModel.DataAnnotations;

namespace E_Library.Model
{
    public class Class
    {
        [Key]
        public int ClassID { get; set; }
        public string ClassCode { get; set; } = string.Empty;
        public string ClassDate { get; set; } = string.Empty;
        public string ClassName { get; set; } = string.Empty;
        public string HomeroomTeacher { get; set; } = string.Empty;
        public string StudentNumber { get; set; } = string.Empty;
        public string ClassClassify { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public SchoolYear SchoolYear { get; set; }
        public List<Department> Department { get; set; } = new List<Department>();
    }
}
