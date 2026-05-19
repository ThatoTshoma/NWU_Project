namespace PostGradSystem.Models
{
    public class UserViewModel
    {
        public int UserId { get; set; }
        public int SupervisorId { get; set; } 
        public int SciComChairId { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string UserRole { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string FullName { get; set; }
        public string ContactNumber { get; set; }
        public string RegistrationNumber { get; set; }
    }
}
