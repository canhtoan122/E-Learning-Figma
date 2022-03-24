using System.ComponentModel.DataAnnotations;

namespace E_Library.Model
{
    public class Thông_tin_trường
    {
        [Key]
        public int Thông_tin_trường_ID { get; set; }
        public string Tên_trường { get; set; } = string.Empty;
        public string Mã_chuẩn { get; set; } = string.Empty;
        public string Tỉnh_Thành_phố { get; set; } = string.Empty;
        public string Xã_Phường { get; set; } = string.Empty;
        public string Quận_Huyện { get; set; } = string.Empty;
        public string Trụ_sở_chính { get; set; } = string.Empty;
        public string Loại_trường { get; set; } = string.Empty;
        public string Số_điện_thoại { get; set; } = string.Empty;
        public string Fax { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Ngày_thành_lập { get; set; } = string.Empty;
        public string Mô_hình_thành_lập { get; set; } = string.Empty;
        public string Website { get; set; } = string.Empty;
        public string Hiệu_trưởng { get; set; } = string.Empty;
        public string SĐT_Hiệu_Trưởng { get; set; } = string.Empty;
        public string Tên_cơ_sở { get; set; } = string.Empty;
        public string Địa_chỉ { get; set; } = string.Empty;
        public string SĐT_Trường { get; set; } = string.Empty;
        public string Người_Phụ_Trách { get; set; } = string.Empty;
        public string Di_Động { get; set; } = string.Empty;
    }
}
