using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PostGradSystem.Data;
using PostGradSystem.Models;
using System.Security.Claims;

namespace PostGradSystem.Controllers
{
    [Authorize(Roles = "Student")]
    public class StudentController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly IWebHostEnvironment _env;
        private readonly UserManager<ApplicationUser> _userManager;

        public StudentController(ApplicationDbContext db, IWebHostEnvironment env, UserManager<ApplicationUser> userManager)
        {
            _db = db;
            _env = env;
            _userManager = userManager;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> RegisterTitle()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> RegisterTitle(TitleRegistrationViewModel model)
        {
            //if (!ModelState.IsValid)
            //    return View(model);

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var student = await _db.Students.SingleOrDefaultAsync(c => c.UserId.ToString() == userId);

            if (student == null)
            {
                TempData["error"] = "Student record not found.";
                return View(model);
            }

            var lastOcid = await _db.TitleRegistrations.OrderByDescending(t => t.TitleRegistrationId).Select(t => t.OcidId).FirstOrDefaultAsync();

            int newOcidId = (lastOcid == 0) ? 1001 : lastOcid + 1;

            var titleRegistration = new TitleRegistration
            {
                OcidId = newOcidId,
                Title1 = model.Title1,
                Title2 = null,
                Title3 = null,
                Status = "Pending",
                DateRegistered = DateTime.Now,
                StudentId = student.StudentId
            };

            await _db.TitleRegistrations.AddAsync(titleRegistration);
            await _db.SaveChangesAsync();

            TempData["success"] = "Title registered successfully!";
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> ListRegisterTitle(TitleRegistrationViewModel model)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var student = await _db.Students.SingleOrDefaultAsync(c => c.UserId.ToString() == userId);
            var titleRegistrations = await _db.TitleRegistrations.Where(t => t.StudentId == student.StudentId).ToListAsync();
            return View(titleRegistrations);

        }
        public async Task<IActionResult> ListAssignedSupervisor()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var student = await _db.Students.SingleOrDefaultAsync(c => c.UserId.ToString() == userId);
            var supervison = await _db.Supervisions.Include(b => b.Supervisor).Where(b => b.StudentId == student.StudentId).ToListAsync();
            return View(supervison);
        }
        [HttpGet]
        public IActionResult Upload(int titleId)
        {
            ViewBag.TitleId = titleId; 
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Upload(IFormFile file, int titleId)
        {
            if (file != null)
            {
                string folder = Path.Combine(_env.WebRootPath, "uploads");
                Directory.CreateDirectory(folder);

                string fileName = Guid.NewGuid() + Path.GetExtension(file.FileName);
                string path = Path.Combine(folder, fileName);

                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }

                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                var student = _db.Students.SingleOrDefault(c => c.UserId.ToString() == userId);

                var upload = new ResearchProject
                {
                    FilePath = "/uploads/" + fileName,
                    UploadDate = DateTime.Now,
                    StudentId = student.StudentId,
                    TitleRegistrationId = titleId
                };

                _db.ResearchProjects.Add(upload);
                await _db.SaveChangesAsync();
            }
            ViewBag.TitleId = titleId;
            return RedirectToAction("Upload");
        }
        public async Task<IActionResult> ListUpload(int titleId)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var student = await _db.Students.SingleOrDefaultAsync(c => c.UserId.ToString() == userId);
            var researchProjects = await _db.ResearchProjects.Include(b => b.TitleRegistration).Where(b => b.StudentId == student.StudentId && b.TitleRegistration.TitleRegistrationId == titleId).ToListAsync();
            return View(researchProjects);
        }
        public async Task<IActionResult> ListProgressReport(int? titleId)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var student = await _db.Students.SingleOrDefaultAsync(c => c.UserId.ToString() == userId);

            var query = _db.ProgressReports.Include(b => b.TitleRegistration).Where(b => b.TitleRegistration.Student.StudentId == student.StudentId);

            if (titleId.HasValue)
            {
                query = query.Where(b => b.TitleRegistration.TitleRegistrationId == titleId.Value);
            }

            var progressReport = await query.ToListAsync();

            return View(progressReport);
        }
        public async Task<IActionResult> ListReport(int? titleId)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var student = await _db.Students.SingleOrDefaultAsync(c => c.UserId.ToString() == userId);

            if (student == null) return NotFound();

            IQueryable<ProgressReport> query = _db.ProgressReports
                .Include(r => r.TitleRegistration)
                    .ThenInclude(t => t.Student)
                .Where(b => b.TitleRegistration.Student.StudentId == student.StudentId);

            if (titleId.HasValue)
            {
                var titleRegistration = await _db.TitleRegistrations
                    .Include(t => t.Student)
                    .FirstOrDefaultAsync(t => t.TitleRegistrationId == titleId.Value);

                if (titleRegistration == null) return NotFound();

                query = query.Where(r => r.TitleRegistrationId == titleId.Value);

                ViewBag.TitleId = titleId.Value;
                ViewBag.TitleRegistration = titleRegistration;
            }

            var reports = await query
                .OrderByDescending(r => r.UpdatedAt)
                .ToListAsync();

            return View(reports);
        }
        public async Task<IActionResult> Details(int id)
        {

            var report = await _db.ProgressReports
                .Include(r => r.TitleRegistration)
                    .ThenInclude(t => t.Student)
                        .ThenInclude(s => s.Programme)
                .Include(r => r.Supervisor)
                .Include(r => r.Milestones)
                    .ThenInclude(mp => mp.Milestone)
                .FirstOrDefaultAsync(r => r.ProgressReportId == id);

            if (report == null) return NotFound();

            return View(report);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var report = await _db.ProgressReports
                .Include(r => r.TitleRegistration)
                    .ThenInclude(t => t.Student)
                .Include(r => r.Milestones)
                    .ThenInclude(mp => mp.Milestone)
                .FirstOrDefaultAsync(r => r.ProgressReportId == id);

            if (report == null) return NotFound();

            var milestones = await _db.Milestones
                .OrderBy(m => m.DisplayOrder)
                .ToListAsync();

            var viewModel = new ProgressReportViewModel
            {
                TitleRegistrationId = report.TitleRegistrationId,
                PeriodFrom = report.PeriodFrom,
                PeriodTo = report.PeriodTo,
                OverallRating = report.OverallRating,
                LackOfProgressReasons = report.LackOfProgressReasons,
                ProposedMitigation = report.ProposedMitigation,
                PreviousWarningLetters = report.PreviousWarningLetters,
                OtherInformation = report.OtherInformation,
                SupervisorRecommendation = report.SupervisorRecommendation,
                SupervisorSignature = report.SupervisorSignature,
                StudentSignature = report.StudentSignature,
                ScientificCommitteeDecision = report.ScientificCommitteeDecision,
                ChairSignature = report.ChairSignature,
                DecisionDate = report.DecisionDate,

                Milestones = milestones.Select(m =>
                {
                    var existing = report.Milestones
                        .FirstOrDefault(x => x.MilestoneId == m.Id);

                    return new MilestoneProgressViewModel
                    {
                        MilestoneId = m.Id,
                        MilestoneName = m.Name,
                        Status = (MilestoneStatus)(existing?.Status),
                        Notes = existing?.Notes
                    };
                }).ToList()
            };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ProgressReportViewModel viewModel)
        {
            var report = await _db.ProgressReports
                .Include(r => r.Milestones)
                .FirstOrDefaultAsync(r => r.ProgressReportId == id);



            //if (!ModelState.IsValid)
            //{
            //    await ReloadMilestoneNames(viewModel);
            //    return View(viewModel);
            //}


            if (report == null)
            {
                report = new ProgressReport
                {
                    TitleRegistrationId = viewModel.TitleRegistrationId,
                    CreatedAt = DateTime.UtcNow
                };
                _db.ProgressReports.Add(report);
            }

            report.PeriodFrom = viewModel.PeriodFrom;
            report.PeriodTo = viewModel.PeriodTo;
            report.OverallRating = viewModel.OverallRating;
            report.LackOfProgressReasons = viewModel.LackOfProgressReasons;
            report.ProposedMitigation = viewModel.ProposedMitigation;
            report.UpdatedAt = DateTime.UtcNow;
            report.LackOfProgressReasons = viewModel.LackOfProgressReasons;
            report.ProposedMitigation = viewModel.ProposedMitigation;
            report.PreviousWarningLetters = viewModel.PreviousWarningLetters;
            report.OtherInformation = viewModel.OtherInformation;
            report.SupervisorRecommendation = viewModel.SupervisorRecommendation;
            report.SupervisorSignature = viewModel.SupervisorSignature;
            report.StudentSignature = viewModel.StudentSignature;
            report.ScientificCommitteeDecision = viewModel.ScientificCommitteeDecision;
            report.ChairSignature = viewModel.ChairSignature;
            report.DecisionDate = viewModel.DecisionDate;

            await _db.SaveChangesAsync();

            if (report.Milestones != null && report.Milestones.Any())
            {
                _db.MilestoneProgresses.RemoveRange(report.Milestones);
            }

            foreach (var m in viewModel.Milestones)
            {
                _db.MilestoneProgresses.Add(new MilestoneProgress
                {
                    ProgressReportId = report.ProgressReportId,
                    MilestoneId = m.MilestoneId,
                    Status = m.Status,
                    Notes = m.Notes
                });
            }

            await _db.SaveChangesAsync();

            TempData["Success"] = "Progress report saved successfully.";
            return RedirectToAction(nameof(Edit));
        }
    }
}
