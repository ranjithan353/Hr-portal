// DTOs/RegisterRequest.cs
namespace HRPortal.DTOs
{
    public class RegisterRequest
    {
        public string Username { get; set; }
        public string MobileNumber { get; set; }
        public string Password { get; set; }
        public long RoleId { get; set; }
    }
}