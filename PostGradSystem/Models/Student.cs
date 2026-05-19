using PostGradSystem.Data;
using static Org.BouncyCastle.Crypto.Engines.SM2Engine;

namespace PostGradSystem.Models
{
    public class Student
    {
        public int StudentId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Initials { get; set; }
        public string Title { get; set; }
        public string Status { get; set; }
        public int StudentNumber { get; set; }
        public string Email { get; set; }

        public ApplicationUser User { get; set; }
        public int UserId { get; set; }
        public Programme Programme { get; set; }
        public int ProgrammeId { get; set; }
        public string DisplayText => $"{Name}  {Surname} ({StudentNumber})";

    }
}
