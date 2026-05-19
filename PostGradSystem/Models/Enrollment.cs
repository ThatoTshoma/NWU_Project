namespace PostGradSystem.Models
{
    public class Enrollment
    { public int EnrollmentId { get; set; }
        public Student Student { get; set; }
        public int StudentId { get; set; }
        public Module Module { get; set; }
        public int ModuleId { get; set; }
        public int Semester { get; set; }
        public int Year { get; set; }
        public DateTime Date { get; set; }
    }
}
