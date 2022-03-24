using System.ComponentModel.DataAnnotations;

namespace E_Library.Model
{
    public class Hồ_sơ_bảo_lưu
    {
        [Key]
        public int Hồ_sơ_bảo_lưu_ID { get; set; }
        public string Mã_Học_Viên { get; set; } = string.Empty;
        public string Tên_Học_Viên { get; set; } = string.Empty;
        public string Ngày_sinh { get; set; } = string.Empty;
        public string Giới_tính { get; set; } = string.Empty;
        public string Lớp_bảo_Lưu { get; set; } = string.Empty;
        public string Ngày_bảo_Lưu { get; set; } = string.Empty;
        public string Thời_gian_bảo_Lưu { get; set; } = string.Empty;
        public string Lí_do { get; set; } = string.Empty;
    }
}
