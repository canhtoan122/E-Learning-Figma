using System.ComponentModel.DataAnnotations;

namespace E_Library.Model
{
    public class Thiết_lập_môn_học
    {
        [Key]
        public int Thiết_lập_môn_học_ID { get; set; }
        public string Loại_môn_học { get; set; } = string.Empty;
        public string Ghi_chú { get; set; } = string.Empty;
    }
}
