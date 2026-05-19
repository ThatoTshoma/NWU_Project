namespace PostGradSystem.Models
{
    public class Examiner
    {
        public int ExaminerId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public int Type { get; set; } 
        public Programme Programme { get; set; }
        public int ProgrammeId { get; set; }
    }
}
