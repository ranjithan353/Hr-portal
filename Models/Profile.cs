namespace HRPortal.Models
{
    public class Profile
    {
        public long ProfileId { get; set; }
        public long UserId { get; set; }
        public string FullName { get; set; }
        public string Address { get; set; }
        public string EmergencyContact { get; set; }
        public decimal Salary { get; set; }
        public long ReportingManagerId { get; set; }
    }
}