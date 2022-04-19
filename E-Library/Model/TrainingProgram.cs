using System.ComponentModel.DataAnnotations;

namespace E_Library.Model
{
    public class TrainingProgram
    {
        [Key]
        public int TrainingProgramID { get; set; }
        public string Teacher { get; set; } = string.Empty;
        public string TrainingFacilities { get; set; } = string.Empty;
        public string UniversityMajor { get; set; } = string.Empty;
        public DateTime StartingDate { get; set; }
        public DateTime EndingDate { get; set; }
        public string FormsOfTraining { get; set; } = string.Empty;
        public string DiplomasAndCertificates { get; set; } = string.Empty;   
    }
}
