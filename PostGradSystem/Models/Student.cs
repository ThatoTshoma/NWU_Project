using PostGradSystem.Data;

namespace PostGradSystem.Models
{
    public class Student
    {
        public int StudentId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Status { get; set; }
        public int StudentNumber { get; set; }
        public ApplicationUser User { get; set; }
        public int UserId { get; set; }
        public Programme Programme { get; set; }
        public int ProgrammeId { get; set; }
        public string DisplayText => $"{Name}  {Surname} ({StudentNumber})";

    }
}
