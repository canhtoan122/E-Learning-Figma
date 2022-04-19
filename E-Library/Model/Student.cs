using System.ComponentModel.DataAnnotations;

namespace E_Library.Model
{
    public class Student
    {
        [Key]
        public int StudentID { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string StudentCode { get; set; } = string.Empty;
        public string DateOfAdmission { get; set; } = string.Empty;
        public string DateOfBirth { get; set; } = string.Empty;
        public string Sex { get; set; } = string.Empty;
        public string PlaceOfBirth { get; set; } = string.Empty;
        public string Ethnic { get; set; } = string.Empty;
        public string Religion { get; set; } = string.Empty;
        public string Class { get; set; } = string.Empty;
        public string GraduateForm { get; set; } = string.Empty;
        public string StudyStatus { get; set; } = string.Empty;
        public string ProvinceCity { get; set; } = string.Empty;
        public string District { get; set; } = string.Empty;
        public string Wards { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string FatherFullName { get; set; } = string.Empty;
        public string MotherFullName { get; set; } = string.Empty;
        public string GuardianFullName { get; set; } = string.Empty;
        public string FatherDateOfBirth { get; set; } = string.Empty;
        public string MotherDateOfBirth { get; set; } = string.Empty;
        public string GuardianDateOfBirth { get; set; } = string.Empty;
        public string FatherOccupation { get; set; } = string.Empty;
        public string MotherOccupation { get; set; } = string.Empty;
        public string GuardianOccupation { get; set; } = string.Empty;
        public string FatherPhoneNumber { get; set; } = string.Empty;
        public string MotherPhoneNumber { get; set; } = string.Empty;
        public string GuardianPhoneNumber { get; set; } = string.Empty;
        //public IEnumerable<School_year> School_year { get; set; }
        //public IEnumerable<Department> Department { get; set; }
        //public IEnumerable<Class> CLass { get; set; }
    }
}
