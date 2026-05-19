namespace PostGradSystem.Models
{
    public class ResearchProject
    {
        public int ResearchProjectId { get; set; }
        public string FilePath { get; set; }
        public DateTime UploadDate { get; set; }
        public Student Student { get; set; }
        public int StudentId { get; set; }
        public TitleRegistration TitleRegistration { get; set; }
        public int TitleRegistrationId { get; set; }
        
    }
}
