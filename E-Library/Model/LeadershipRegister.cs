namespace E_Library.Model
{
    public class LeadershipRegister
    {
        public string leadership_username { get; set; } = string.Empty;
        public byte[] leadership_passwordHash { get; set; }
        public byte[] leadership_passwordSalt { get; set; }
    }
}
