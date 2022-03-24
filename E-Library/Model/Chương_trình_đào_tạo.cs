using System.ComponentModel.DataAnnotations;

namespace E_Library.Model
{
    public class Chương_trình_đào_tạo
    {
        [Key]
        public int Chương_trình_đào_tạo_ID { get; set; }
        public string Giảng_viên { get; set; } = string.Empty;
        public string Cơ_sở_đào_tạo { get; set; } = string.Empty;
        public string Chuyên_ngành { get; set; } = string.Empty;
        public DateTime Ngày_Bắt_Đàu { get; set; }
        public DateTime Ngày_Kết_Thúc { get; set; }
        public string Hình_thức { get; set; } = string.Empty;
        public string Văn_Bằng_Chứng_Chỉ { get; set; } = string.Empty;   
    }
}
