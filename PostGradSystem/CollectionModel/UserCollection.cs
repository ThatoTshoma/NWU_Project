using PostGradSystem.Data;
using PostGradSystem.Models;
using static PostGradSystem.Areas.Identity.Pages.Account.RegisterModel;

namespace PostGradSystem.CollectionModel
{
    public class UserCollection
    {
        public InputModel ApplicationUser { get; set; }
        public ApplicationUser ApplicationUsers { get; set; }
        public Student Student { get; set; }
        public Supervisor Supervisor { get; set; }
        public SciComChair SciComChair { get; set; }
        public string ReturnUrl { get; set; }
    }
}
