using System.ComponentModel.DataAnnotations;

namespace E_Library.Model
{
    public class Nhóm_người_dùng
    {
        [Key]
        public int Người_dùng_hệ_thống_ID { get; set; }
        public string Tên_Nhóm { get; set; } = string.Empty;
        public string Ghi_chú { get; set; } = string.Empty;
        public bool Phân_quyền { get; set; }
        public bool Khai_báo_dữ_liệu { get; set; }
        public bool Hồ_sơ_học_viên { get; set; }
        public bool Hồ_sơ_giảng_viên { get; set; }
        public bool Thi_cử { get; set; }
        public bool Cập_nhật_hệ_thống { get; set; }
    }
}
