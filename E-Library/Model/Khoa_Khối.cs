using System.ComponentModel.DataAnnotations;

namespace E_Library.Model
{
    public class Khoa_Khối
    {
        [Key]
        public int Khoa_Khối_ID { get; set; }
        public string Mã_Khoa_Khối { get; set; } = string.Empty;
        public string Tên_Khoa_Khối { get; set; } = string.Empty;
        public string Trưởng_Khoa_Khối { get; set; } = string.Empty;
        public ICollection<Lớp_học> Lớp_Học { get; set; }

    }
}
