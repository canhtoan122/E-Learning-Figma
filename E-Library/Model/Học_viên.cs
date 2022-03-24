using System.ComponentModel.DataAnnotations;

namespace E_Library.Model
{
    public class Học_viên
    {
        [Key]
        public int Học_viên_ID { get; set; }
        public string Họ_và_tên { get; set; } = string.Empty;
        public string Mã_Học_viên { get; set; } = string.Empty;
        public string Ngày_Nhập_Học { get; set; } = string.Empty;
        public string Tên_Học_viên { get; set; } = string.Empty;
        public string Ngày_sinh { get; set; } = string.Empty;
        public string Giới_Tính { get; set; } = string.Empty;
        public string Nơi_Sinh { get; set; } = string.Empty;
        public string Dân_Tộc { get; set; } = string.Empty;
        public string Tôn_Giáo { get; set; } = string.Empty;
        public string Lớp { get; set; } = string.Empty;
        public string Hình_Thức { get; set; } = string.Empty;
        public string Tình_Trạng { get; set; } = string.Empty;
        public string Tỉnh_Thành_Phố { get; set; } = string.Empty;
        public string Quận_Huyện { get; set; } = string.Empty;
        public string Xã_Phường { get; set; } = string.Empty;
        public string Địa_Chỉ { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Điện_Thoại { get; set; } = string.Empty;
        public string Họ_Tên_Bố { get; set; } = string.Empty;
        public string Họ_Tên_Mẹ { get; set; } = string.Empty;
        public string Họ_Tên_Giám_Hộ { get; set; } = string.Empty;
        public string Năm_Sinh_Bố { get; set; } = string.Empty;
        public string Năm_Sinh_Mẹ { get; set; } = string.Empty;
        public string Năm_Sinh_GH { get; set; } = string.Empty;
        public string Nghề_Nghiệp_Bố { get; set; } = string.Empty;
        public string Nghề_Nghiệp_Mẹ { get; set; } = string.Empty;
        public string Nghề_Nghiệp_GH { get; set; } = string.Empty;
        public string Điện_Thoại_Bố { get; set; } = string.Empty;
        public string Điện_Thoại_Mẹ { get; set; } = string.Empty;
        public string Điện_Thoại_GH { get; set; } = string.Empty;
        public ICollection<Niên_Khoá> Niên_Khoá { get; set; }
        public ICollection<Khoa_Khối> Khoa_Khối { get; set; }
        public ICollection<Lớp_học> Lớp_học { get; set; }
    }
}
