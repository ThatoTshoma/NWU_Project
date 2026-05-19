using Microsoft.Identity.Client;
using PostGradSystem.Data;
using System.ComponentModel.DataAnnotations;

namespace PostGradSystem.Models
{
    public class ProgressReport
    {
        public int ProgressReportId { get; set; }

        public int TitleRegistrationId { get; set; }
        public TitleRegistration TitleRegistration { get; set; }
        public Supervisor Supervisor { get; set; }

        public int SupervisorId { get; set; }

        [Required, DataType(DataType.Date)]
        [Display(Name = "Period from")]
        public DateTime PeriodFrom { get; set; }

        [Required, DataType(DataType.Date)]
        [Display(Name = "Period to")]
        public DateTime PeriodTo { get; set; }

       
        [Display(Name = "Overall progress rating")]
        public string? OverallRating { get; set; }

        [Display(Name = "Reasons for lack of progress")]
        public string? LackOfProgressReasons { get; set; }

        [Display(Name = "Proposed mitigation / support")]
        public string? ProposedMitigation { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        [Display(Name = "Supervisor/promoter signature")]
        public string? SupervisorSignature { get; set; }

        [Display(Name = "Student signature")]
        public string? StudentSignature { get; set; }
        [Display(Name = "Decision/recommendation by the Scientific Committee")]
        public string? ScientificCommitteeDecision { get; set; }

        [Display(Name = "Chair: Scientific Committee signature")]
        public string? ChairSignature { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Date of decision")]
        public DateTime? DecisionDate { get; set; }
        [Display(Name = "Previous warning letter(s) issued")]
        public string? PreviousWarningLetters { get; set; }  

        [Display(Name = "Any other information for the Scientific Committee")]
        public string? OtherInformation { get; set; }

        [Display(Name = "Recommendation by the supervisor/promoter")]
        public string? SupervisorRecommendation { get; set; }

        public ICollection<MilestoneProgress> Milestones { get; set; } = new List<MilestoneProgress>();
    }
}

