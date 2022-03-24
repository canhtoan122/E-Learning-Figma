using System.ComponentModel.DataAnnotations;

namespace E_Library.Model
{
    public class Lớp_học
    {
        [Key]
        public int Lớp_Học_ID { get; set; }
        public string Mã_Lớp { get; set; } = string.Empty;
        public string Tên_Lớp { get; set; } = string.Empty;
        public string Giáo_Viên_Chủ_Nhiệm { get; set; } = string.Empty;
        public string Số_Lượng_Học_Viên { get; set; } = string.Empty;
        public string Phân_Loại_Lớp { get; set; } = string.Empty;
        public string Mô_Tả { get; set; } = string.Empty;
        public ICollection<Niên_Khoá> Niên_Khoá { get; set; }
        public ICollection<Môn_Học> Môn_Học { get; set; }
    }
}
