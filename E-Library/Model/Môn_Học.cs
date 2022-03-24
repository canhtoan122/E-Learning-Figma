using System.ComponentModel.DataAnnotations;

namespace E_Library.Model
{
    public class Môn_Học
    {
        [Key]
        public int Môn_Học_ID { get; set; }
        public string Mã_Môn_Học { get; set; } = string.Empty;
        public string Tên_Môn_Học { get; set; } = string.Empty;
        public string Loại_Môn { get; set; } = string.Empty;
        public string Số_Tiết_HK1 { get; set; } = string.Empty;
        public string Số_Tiết_HK2 { get; set; } = string.Empty;
    }
}
