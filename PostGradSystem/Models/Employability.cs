namespace PostGradSystem.Models
{
    public class Employability
    {
        public int EmployabilityId{ get; set; }
        public double Score { get; set; }
        public string Recommendation { get; set; }
        public Student Student { get; set; }
        public int StudentId { get; set; }
    }
}
