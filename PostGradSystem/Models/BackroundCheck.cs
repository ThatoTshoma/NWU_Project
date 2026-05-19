namespace PostGradSystem.Models
{
    public class BackroundCheck
    {
        public int BackroundCheckId { get; set; }
        public bool HasCriminalRecord { get; set; }
        public string? Details { get; set; }
        public Student Student { get; set; }
        public int StudentId { get; set; }

    }
}
