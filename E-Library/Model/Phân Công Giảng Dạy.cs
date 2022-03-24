using System.ComponentModel.DataAnnotations;

namespace E_Library.Model
{
    public class Phân_Công_Giảng_Dạy
    {
        [Key]
        public int Phân_Công_Giảng_Dạy_ID { get; set; }
        public string Lớp_học { get; set; } = string.Empty;
        public string Ngày_bắt_đầu { get; set; } = string.Empty;
        public string Ngày_kết_thúc { get; set; } = string.Empty;
        public string Mô_tả { get; set; } = string.Empty;
        public ICollection<Môn_Học> Môn_Học { get; set; }
        public ICollection<Giảng_Viên> Giảng_Viên { get; set; }

    }
}
