using System.ComponentModel.DataAnnotations;

namespace E_Library.Model
{
    public class Quản_lí_các_bậc_đào_tạo
    {
        [Key]
        public int Quản_lí_các_bậc_đào_tạo_ID { get; set; }
        public string Trình_độ_đào_tạo { get; set; } = string.Empty;
        public string Hình_thức_đào_tạo { get; set; } = string.Empty;
        public string Thời_gian_đào_tạo { get; set; } = string.Empty;
        public string Ghi_chú { get; set; } = string.Empty;
    }
}
