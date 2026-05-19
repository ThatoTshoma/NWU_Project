namespace PostGradSystem.Models
{
    public class Assessment
    {
        public int AssessmentId { get; set; }
        public string Type { get; set; }
        public double Weight { get; set; }
        public DateTime DueDate { get; set; }
        public Module Module { get; set; }
        public int ModuleId { get; set; }
    }
}
