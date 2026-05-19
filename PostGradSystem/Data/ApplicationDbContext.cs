using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PostGradSystem.Models;

namespace PostGradSystem.Data
{
    public class ApplicationUser : IdentityUser<int>
    {
        public string UserRole { get; set; }

    }
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, IdentityRole<int>, int>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Student> Students { get; set; }
        public DbSet<Assessment> Assessments { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Programme> Programmes { get; set; }
        public DbSet<Employability> Employabilities { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Faculty> Faculties { get; set; }
        public DbSet<Graduation> Graduations { get; set; }
        public DbSet<UniversityStudent> UniversityStudents { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Result> Results { get; set; }
        public DbSet<Module> Modules { get; set; }
        public DbSet<BackroundCheck> BackroundChecks { get; set; }
        public DbSet<Attendance> Attendances { get; set; }


    }
}

