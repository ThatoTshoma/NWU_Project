namespace PostGradSystem.Models
{
    public class Result
    {
        public int ResultId { get; set; }
        public Student Student { get; set; }
        public int StudentId { get; set; }
        public Assessment Assessment { get; set; }
        public double Mark { get; set; }
        public string Grade { get; set; }
    }
}
