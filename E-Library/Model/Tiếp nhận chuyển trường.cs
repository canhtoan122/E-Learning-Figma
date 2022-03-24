using System.ComponentModel.DataAnnotations;

namespace E_Library.Model
{
    public class Tiếp_nhận_chuyển_trường
    {
        [Key]
        public int Tiếp_nhận_chuyển_trường_ID { get; set; }
        public string Tên_học_viên { get; set; } = string.Empty;
        public string Mã_học_viên { get; set; } = string.Empty;
        public string Ngày_chuyển_đến { get; set; } = string.Empty;
        public string Học_kì_chuyển { get; set; } = string.Empty;
        public string Tỉnh_Thành { get; set; } = string.Empty;
        public string Quận_huyện { get; set; } = string.Empty;
        public string Chuyển_từ { get; set; } = string.Empty;
        public string Lí_do { get; set; } = string.Empty;
    }
}
