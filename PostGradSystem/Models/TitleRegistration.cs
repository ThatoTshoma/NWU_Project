namespace PostGradSystem.Models
{
    public class TitleRegistration
    {
        public int TitleRegistrationId { get; set; }
        public int OcidId { get; set; }
        public string Title1 { get; set; }
        public string? Title2 { get; set; }
        public string? Title3 { get; set; }
        public string Status { get; set; }
        public DateTime DateRegistered { get; set; }
        public Student Student { get; set; }
        public int StudentId { get; set; }
    }
}
