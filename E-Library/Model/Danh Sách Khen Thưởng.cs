using System.ComponentModel.DataAnnotations;

namespace E_Library.Model
{
    public class Danh_Sách_Khen_Thưởng
    {
        [Key]
        public int Danh_Sách_Khen_Thưởng_ID { get; set; }
        public string Ngày_khen_thưởng { get; set; } = string.Empty;
        public string Nội_dung { get; set; } = string.Empty;
        public ICollection<Học_viên> Học_viên { get; set; }
        public ICollection<Lớp_học> Lớp_học { get; set; }
    }
}
