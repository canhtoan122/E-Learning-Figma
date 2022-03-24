using System.ComponentModel.DataAnnotations;

namespace E_Library.Model
{
    public class Niên_Khoá
    {
        [Key]
        public int Niên_Khoá_ID { get; set; }
        public string Niên_Khoá_time { get; set; } = string.Empty;
        public string Thời_Gian_Bắt_Đầu { get; set; } = string.Empty;
        public string Thời_Gian_Kết_Thúc { get; set; } = string.Empty;
        public string Tên_Học_Kì { get; set; } = string.Empty;
        public string Bắt_Đầu_Học_Kì { get; set; } = string.Empty;
        public string Kết_Thúc_Học_Kì { get; set; } = string.Empty;
    }
}
