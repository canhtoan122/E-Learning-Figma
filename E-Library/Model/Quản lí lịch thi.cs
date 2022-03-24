using System.ComponentModel.DataAnnotations;

namespace E_Library.Model
{
    public class Quản_lí_lịch_thi
    {
        [Key]
        public int Quản_lí_lịch_thi_ID { get; set; }
        public string Học_kì { get; set; } = string.Empty;
        public string Ngày_Làm_Bài { get; set; } = string.Empty;
        public string Khoa_Khối { get; set; } = string.Empty;
        public string Môn_Thi { get; set; } = string.Empty;
        public string Tên_Kì_Thi { get; set; } = string.Empty;
        public string Tình_Trạng { get; set; } = string.Empty;
        public string Phân_công_chấm_thi { get; set; } = string.Empty;
    }
}
