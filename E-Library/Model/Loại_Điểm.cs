using System.ComponentModel.DataAnnotations;

namespace E_Library.Model
{
    public class Loại_Điểm
    {
        [Key]
        public int Loại_Điểm_ID { get; set; }
        public string Loại_Điểm_name { get; set; } = string.Empty;
        public string Hệ_Số { get; set; } = string.Empty;
        public string Số_cột_điểm_tối_thiểu_học_kì_1 { get; set; } = string.Empty;
        public string Số_cột_điểm_tối_thiểu_học_kì_2 { get; set; } = string.Empty;
    }
}
