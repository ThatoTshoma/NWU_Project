namespace PostGradSystem.Models
{
    public class Graduation
    {
        public int GraduationId { get; set; }
        public int ExpectedYear { get; set; }
        public int CreditCompleted { get; set; }
        public int CreditsRequired { get; set; }
        public string Status { get; set; }
    }
}
