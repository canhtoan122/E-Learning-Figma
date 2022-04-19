using System.ComponentModel.DataAnnotations;

namespace E_Library.Model
{
    public class ManagementOfTrainingLevels
    {
        [Key]
        public int ManagementOfTrainingLevelsID { get; set; }
        public string DegreeTraining { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public string FormOfTraining { get; set; } = string.Empty;
        public string TrainingTime { get; set; } = string.Empty;
        public string Notification { get; set; } = string.Empty;
    }
}
