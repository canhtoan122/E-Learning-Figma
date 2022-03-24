using System.ComponentModel.DataAnnotations;

namespace E_Library.Model
{
    public class Giảng_Viên
    {
        [Key]
        public int Giảng_Viên_ID { get; set; }
        public string Mã_Giảng_Viên { get; set; } = string.Empty;
        public string Họ_và_Tên { get; set; } = string.Empty;
        public DateTime Ngày_sinh { get; set; }
        public string Giới_Tính { get; set; } = string.Empty;
        public string Dân_Tộc { get; set; } = string.Empty;
        public DateTime Ngày_Vào_trường { get; set; }
        public string Quốc_tịch { get; set; } = string.Empty;
        public string Tôn_Giáo { get; set; } = string.Empty;
        public string Trạng_thái { get; set; } = string.Empty;
        public string Bí_danh { get; set; } = string.Empty;
        public string Tỉnh_Thành { get; set; } = string.Empty;
        public string Xã_Phường { get; set; } = string.Empty;
        public string Quận_Huyện { get; set; } = string.Empty;
        public string Địa_chỉ { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string SĐT { get; set; } = string.Empty;
        public bool Đoàn_Viên { get; set; }
        public bool Đảng_Viên { get; set; }
        public DateTime Ngày_Vào_Đoàn { get; set; }
        public DateTime Ngày_Vào_Đảng { get; set; }
        public ICollection<Tổ_Bộ_Môn> Tổ_Bộ_Môn { get; set; }
        public ICollection<Môn_Học> Môn_Học { get; set; }
    }
}
