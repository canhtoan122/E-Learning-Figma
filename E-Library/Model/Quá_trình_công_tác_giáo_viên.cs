using System.ComponentModel.DataAnnotations;

namespace E_Library.Model
{
    public class Quá_trình_công_tác_giáo_viên
    {
        [Key]
        public int Quá_trình_công_tác_giáo_viên_ID { get; set; }
        public string Giảng_viên { get; set; } = string.Empty;
        public string Cơ_quan_Đơn_vị { get; set; } = string.Empty;
        public string Chức_vụ { get; set; } = string.Empty;
        public DateTime Ngày_Bắt_Đầu { get; set; }
        public DateTime Ngày_Kêt_Thúc { get; set; }
        public ICollection<Tổ_Bộ_Môn> Tổ_Bộ_Môn { get; set; }
    }
}
