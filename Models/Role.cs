namespace HRPortal.Models
{
    public class Role
    {
        public long RoleId { get; set; }
        public string RoleName { get; set; }

        public ICollection<User> Users { get; set; }
    }
}