using System.ComponentModel.DataAnnotations.Schema;

namespace PostGradSystem.Models
{
    public class Supervision
    {
        public int SupervisionId { get; set; }
        public Student Student { get; set; }
        public int StudentId { get; set; }
        public Supervisor Supervisor { get; set; }
        public int SupervisorId { get; set; }
        [NotMapped]
        public List<int> SelectedStudents { get; set; }
    }
}
