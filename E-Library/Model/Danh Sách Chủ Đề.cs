using System.ComponentModel.DataAnnotations;

namespace E_Library.Model
{
    public class Danh_Sách_Chủ_Đề
    {
        [Key]
        public int Chủ_Đề_ID { get; set; }
        public string Chủ_Đề { get; set; } = string.Empty;
        public string Miêu_tả { get; set; } = string.Empty;
        public string Ngày_Kết_Thúc { get; set; } = string.Empty;
    }
}
