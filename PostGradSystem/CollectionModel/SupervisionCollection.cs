using PostGradSystem.Models;

namespace PostGradSystem.CollectionModel
{
    public class SupervisionCollection
    {
        public Supervision Supervision { get; set; }
        public IEnumerable<Student> Students { get; set; }

    }
}
