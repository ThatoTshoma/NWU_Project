using PostGradSystem.Data;

namespace PostGradSystem.Models
{
    public class SciComChair
    {
        public int SciComChairId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public ApplicationUser User { get; set; }
        public int UserId { get; set; }
    }
}
