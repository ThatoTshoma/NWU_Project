namespace PostGradSystem.Models
{
    public class Attendance
    {
        public int AttendanceId { get; set; }
        public Student Student { get; set; } 
        public int StudentId { get; set; }
        public Module Module { get; set; }
        public int ModuleId { get; set; }
        public string Status { get; set; }
        public double AttendancePercentage { get; set; }
    }
}
