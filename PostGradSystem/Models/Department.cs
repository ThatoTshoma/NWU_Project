namespace PostGradSystem.Models
{
    public class Department
    {
        public int DepartmentId { get; set; }
        public string Name { get; set; }
        public Faculty Faculty { get; set; }
        public int FacultyId { get; set; }
    }
}
