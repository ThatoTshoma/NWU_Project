namespace PostGradSystem.Models
{
    public class Module
    {
        public int ModuleId { get; set; }
        public string Name { get; set; } 
        public string Code { get; set; }
        public int Creits { get; set; }
        public Department Department { get; set; }
        public int DepartmentId { get; set; }
    }
}
