namespace PostGradSystem.Models
{
    public class Programme
    {
        public int ProgrammeId { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string Duration { get; set; }
        public string Level { get; set; }
        public Department Department { get; set; }
        public int DepartmentId { get; set; }
    }
}
