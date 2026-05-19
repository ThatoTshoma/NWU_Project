namespace PostGradSystem.Models
{
    public class Examination
    {
        public int ExamId { get; set; }
        public Student Student { get; set; }
        public int StudentId { get; set; }
        public Supervisor Supervisor { get; set; }
        public int SupervisorId { get; set; }
        public string Type { get; set; }
        public DateTime Date { get; set; }
        public int Outcome { get; set; }
        public string Status { get; }
    }
}
