using System.ComponentModel.DataAnnotations;

namespace E_Library.Model
{
    public class Danh_sách_người_dùng
    {
        [Key]
        public int Danh_sách_người_dùng_ID { get; set; }
        public string Tên_người_dùng { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Nhóm_người_dùng { get; set; } = string.Empty;
    }
}
