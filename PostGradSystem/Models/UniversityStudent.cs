using PostGradSystem.Data;

namespace PostGradSystem.Models
{
    public class UniversityStudent
    {
        public int UniversityStudentId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Initials { get; set; }
        public string Title { get; set; }
        public int StudentId { get; set; }  
        public string Status { get; set; }
        public string Email { get; set; }
        public Programme Programme { get; set; }
        public int ProgrammeId { get; set; }

    }
}
