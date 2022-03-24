using System.ComponentModel.DataAnnotations;

namespace E_Library.Model
{
    public class Tổ_Bộ_Môn
    {
        [Key]
        public int Tổ_Bộ_Môn_ID { get; set; }
        public string Tên_Tổ_Bộ_Môn { get; set; } = string.Empty;
        public string Trưởng_Bộ_môn { get; set; } = string.Empty;
        public ICollection<Môn_Học> Môn_Học { get; set; }
    }
}
