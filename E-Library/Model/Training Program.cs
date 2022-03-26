using System.ComponentModel.DataAnnotations;

namespace E_Library.Model
{
    public class Training_Program
    {
        [Key]
        public int Training_Program_ID { get; set; }
        public string Teacher { get; set; } = string.Empty;
        public string Training_facilities { get; set; } = string.Empty;
        public string University_Major { get; set; } = string.Empty;
        public DateTime Starting_date { get; set; }
        public DateTime Ending_date { get; set; }
        public string Forms_of_training { get; set; } = string.Empty;
        public string Diplomas_and_certificates { get; set; } = string.Empty;   
    }
}
