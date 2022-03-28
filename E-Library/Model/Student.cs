using System.ComponentModel.DataAnnotations;

namespace E_Library.Model
{
    public class Student
    {
        [Key]
        public int Student_ID { get; set; }
        public string Full_name { get; set; } = string.Empty;
        public string Student_code { get; set; } = string.Empty;
        public string Date_of_admission { get; set; } = string.Empty;
        public string Date_of_birth { get; set; } = string.Empty;
        public string Sex { get; set; } = string.Empty;
        public string Place_of_birth { get; set; } = string.Empty;
        public string Ethnic { get; set; } = string.Empty;
        public string Religion { get; set; } = string.Empty;
        public string Class { get; set; } = string.Empty;
        public string Graduate_form { get; set; } = string.Empty;
        public string Study_Status { get; set; } = string.Empty;
        public string Province_city { get; set; } = string.Empty;
        public string District { get; set; } = string.Empty;
        public string Wards { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Phone_number { get; set; } = string.Empty;
        public string Father_full_name { get; set; } = string.Empty;
        public string Mother_full_name { get; set; } = string.Empty;
        public string Guardian_full_name { get; set; } = string.Empty;
        public string Father_date_of_birth { get; set; } = string.Empty;
        public string Mother_date_of_birth { get; set; } = string.Empty;
        public string Guardian_date_of_birth { get; set; } = string.Empty;
        public string Father_occupation { get; set; } = string.Empty;
        public string Mother_occupation { get; set; } = string.Empty;
        public string Guardian_occupation { get; set; } = string.Empty;
        public string Father_phone_number { get; set; } = string.Empty;
        public string Mother_phone_number { get; set; } = string.Empty;
        public string Guardian_phone_number { get; set; } = string.Empty;
        //public IEnumerable<School_year> School_year { get; set; }
        //public IEnumerable<Department> Department { get; set; }
        //public IEnumerable<Class> CLass { get; set; }
    }
}
