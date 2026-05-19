using System.ComponentModel.DataAnnotations;

namespace PostGradSystem.Models
{
    public class Milestone
    {
        public int Id { get; set; }

        [Required, MaxLength(200)]
        public string Name { get; set; } = string.Empty;
        public int DisplayOrder { get; set; }
    }

    public class MilestoneProgress
    {
        public int Id { get; set; }
        public int ProgressReportId { get; set; }
        public ProgressReport ProgressReport { get; set; } = null!;

        public int MilestoneId { get; set; }
        public Milestone Milestone { get; set; } = null!;

        [Required]
        public MilestoneStatus Status { get; set; } = MilestoneStatus.NotStarted;

        [MaxLength(500)]
        public string? Notes { get; set; }
    }

    public enum MilestoneStatus
    {
        [Display(Name = "Not started")]
        NotStarted,

        [Display(Name = "In progress")]
        InProgress,

        [Display(Name = "Submitted to SciCom")]
        Submitted,

        [Display(Name = "Approved by SciCom")]
        Approved,

        [Display(Name = "Completed")]
        Completed,

        [Display(Name = "Yes")]
        Yes,

        [Display(Name = "No")]
        No,



    }
}