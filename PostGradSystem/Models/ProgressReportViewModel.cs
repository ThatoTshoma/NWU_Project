using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;
using PostGradSystem.Models;

namespace PostGradSystem.Models
{
    public class ProgressReportViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please select a title registration.")]
        [Display(Name = "Title registration")]
        public int ProgressReportId { get; set; }
        public int TitleRegistrationId { get; set; }

        public SelectList? TitleRegistrationList { get; set; }

        public string? TitleRegistrationDisplayText { get; set; }

        [Required(ErrorMessage = "Period start date is required.")]
        [DataType(DataType.Date)]
        [Display(Name = "Period from")]
        public DateTime PeriodFrom { get; set; } = DateTime.Today;

        [Required(ErrorMessage = "Period end date is required.")]
        [DataType(DataType.Date)]
        [Display(Name = "Period to")]
        public DateTime PeriodTo { get; set; } = DateTime.Today;

        [Display(Name = "Overall progress rating")]
        public string? OverallRating { get; set; }

        [Display(Name = "Reasons for lack of progress")]
        public string? LackOfProgressReasons { get; set; }

        [Display(Name = "Proposed mitigation / support")]
        public string? ProposedMitigation { get; set; }

        [Display(Name = "Supervisor comments")]
        public string? SupervisorComments { get; set; }

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

        public List<MilestoneProgressViewModel> Milestones { get; set; } = new();
    }

    public class MilestoneProgressViewModel
    {
        public int MilestoneId { get; set; }
        public string MilestoneName { get; set; } = string.Empty;
        public int DisplayOrder { get; set; }
        public MilestoneStatus Status { get; set; } 

        [MaxLength(500)]
        public string? Notes { get; set; }
    }
}