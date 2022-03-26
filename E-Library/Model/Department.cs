using System.ComponentModel.DataAnnotations;

namespace E_Library.Model
{
    public class Department
    {
        [Key]
        public int Department_ID { get; set; }
        public string Department_code { get; set; } = string.Empty;
        public string Department_name { get; set; } = string.Empty;
        public string Dean { get; set; } = string.Empty;
        public IEnumerable<Class> Class { get; set; }

    }
}
