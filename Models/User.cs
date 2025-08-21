namespace HRPortal.Models
{
    public class User
    {
        public long UserId { get; set; }
        public string Username { get; set; }
        public string MobileNumber { get; set; }
        public string PasswordHash { get; set; }

        public long RoleId { get; set; }
        public Role Role { get; set; }
    }
}