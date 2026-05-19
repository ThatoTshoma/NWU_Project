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
        public DbSet<Supervisor> Supervisors { get; set; }
        public DbSet<Supervision> Supervisions { get; set; }
        public DbSet<Programme> Programmes { get; set; }
        public DbSet<ProgressReport> ProgressReports { get; set; }
        public DbSet<Examiner> Examiners { get; set; }
        public DbSet<TitleRegistration> TitleRegistrations { get; set; }
        public DbSet<SciComChair> SciComChairs { get; set; }
        public DbSet<UniversityStudent> UniversityStudents { get; set; }
        public DbSet<ResearchProject> ResearchProjects { get; set; }
        public DbSet<MilestoneProgress> MilestoneProgresses { get; set; }
        public DbSet<Milestone> Milestones { get; set; }




        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);


            builder.Entity<ProgressReport>(e =>
            {

                e.HasOne(r => r.TitleRegistration)
                 .WithMany()  
                 .HasForeignKey(r => r.TitleRegistrationId)
                 .OnDelete(DeleteBehavior.Restrict);

                e.HasOne(r => r.Supervisor)
                 .WithMany()
                 .HasForeignKey(r => r.SupervisorId)
                 .OnDelete(DeleteBehavior.Restrict);
            });

            builder.Entity<MilestoneProgress>(e =>
            {
                e.HasOne(mp => mp.ProgressReport)
                 .WithMany(r => r.Milestones)
                 .HasForeignKey(mp => mp.ProgressReportId)
                 .OnDelete(DeleteBehavior.Cascade);

                e.HasOne(mp => mp.Milestone)
                 .WithMany()
                 .HasForeignKey(mp => mp.MilestoneId)
                 .OnDelete(DeleteBehavior.Restrict);

                e.HasIndex(mp => new { mp.ProgressReportId, mp.MilestoneId }).IsUnique();
            });

            builder.Entity<Milestone>().HasData(
                new Milestone { Id = 1, Name = "Coursework modules", DisplayOrder = 1 },
                new Milestone { Id = 2, Name = "Title registration approved by Higher Degrees Committee", DisplayOrder = 2 },
                new Milestone { Id = 3, Name = "Data analysis", DisplayOrder = 3 },
                new Milestone { Id = 4, Name = "Chapter 3", DisplayOrder = 4 },
                new Milestone { Id = 5, Name = "Chapter 6", DisplayOrder = 5 },
                new Milestone { Id = 6, Name = "Chapter 9", DisplayOrder = 6 },
                new Milestone { Id = 7, Name = "Resubmission process", DisplayOrder = 7 },
                new Milestone { Id = 8, Name = "Research proposal", DisplayOrder = 8 },
                new Milestone { Id = 9, Name = "Functionaries approved by Higher Degrees Committee", DisplayOrder = 9 },
                new Milestone { Id = 10, Name = "Chapter 1", DisplayOrder = 10 },
                new Milestone { Id = 11, Name = "Chapter 4", DisplayOrder = 11 },
                new Milestone { Id = 12, Name = "Chapter 7", DisplayOrder = 12 },
                new Milestone { Id = 13, Name = "Finalising", DisplayOrder = 13 },
                new Milestone { Id = 14, Name = "Proof of progress included", DisplayOrder = 14 },
                new Milestone { Id = 15, Name = "Ethics approval", DisplayOrder = 15 },
                new Milestone { Id = 16, Name = "Data collection", DisplayOrder = 16 },
                new Milestone { Id = 17, Name = "Chapter 2", DisplayOrder = 17 },
                new Milestone { Id = 18, Name = "Chapter 5", DisplayOrder = 18 },
                new Milestone { Id = 19, Name = "Chapter 8", DisplayOrder = 19 },
                new Milestone { Id = 20, Name = "Submitted", DisplayOrder = 20 }
            );
        }
    }
}
