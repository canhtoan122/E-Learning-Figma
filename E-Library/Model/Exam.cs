using System.ComponentModel.DataAnnotations;

namespace E_Library.Model
{
    public class Exam
    {
        [Key]
        public int ExamID { get; set; }
        public string ExamTopic { get; set; } = string.Empty;
        public string TestForm { get; set; } = string.Empty;
        public string Grade { get; set; } = string.Empty;
        public string ExamTime { get; set; } = string.Empty;
        public string ExamClassify { get; set; } = string.Empty;
        public string StartingDate { get; set; } = string.Empty;
        public string EndingDate { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string OtherSetting { get; set; } = string.Empty;
        public SubjectGroup SubjectGroup { get; set; }
        //public List<Subject> Subject { get; set; } = new List<Subject>();
    }
}
