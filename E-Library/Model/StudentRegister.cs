namespace E_Library.Model
{
    public class StudentRegister
    {
        public string student_username { get; set; } = string.Empty;
        public byte[] student_passwordHash { get; set; }
        public byte[] student_passwordSalt { get; set; }
    }
}
