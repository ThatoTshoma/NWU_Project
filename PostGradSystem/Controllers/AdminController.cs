using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.Scripting;
using Microsoft.EntityFrameworkCore;
using PostGradSystem.Data;
using PostGradSystem.Models;
using PostGradSystem.Services;
using System.Collections.Concurrent;
using System.Security.Claims;
using System.Security.Cryptography;

namespace PostGradSystem.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private ApplicationDbContext _db;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IMyEmailSender _myEmailSender;

        public AdminController(ApplicationDbContext db, UserManager<ApplicationUser> userManager, IMyEmailSender myEmailSender)
        {
            _db = db;
            _myEmailSender = myEmailSender;
            _userManager = userManager;
        }
        public IActionResult Index()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddStudent(int id)
        {


            if (!ModelState.IsValid)
            {
            
            }
            var universityStudent = await _db.UniversityStudents.FindAsync(id);
            if (universityStudent == null)
            {
                TempData["error"] = "Student not found.";
                return RedirectToAction("ListStudent");
            }

            var existingUser = await _userManager.FindByEmailAsync(universityStudent.Email);
            if (existingUser != null)
            {
                TempData["error"] = "A user account for this student already exists.";
                return View();
            }

            var alreadyImported = await _db.Students.AnyAsync(x => x.StudentId == universityStudent.StudentId);
            if (alreadyImported)
            {
                TempData["error"] = "Student already imported to the Information System.";
                return View();

            }

            var generatedPassword = GenerateRandomPassword();
            var user = new ApplicationUser
            {
                UserName = universityStudent.StudentId.ToString(),
                Email = universityStudent.Email,
                UserRole = "Student"
            };

            var result = await _userManager.CreateAsync(user, generatedPassword);
            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, user.UserRole);

             

                var student = new Student
                {
                    Name = universityStudent.Name,
                    Surname = universityStudent.Surname,
                    StudentNumber = universityStudent.StudentId,
                    Status = "Active",
                    UserId = user.Id,
                    ProgrammeId = universityStudent.ProgrammeId,
                    Email = universityStudent.Email
                };
                _db.Students.Add(student);

                await _db.SaveChangesAsync();

                _myEmailSender.SendEmail(
                    universityStudent.Email,
                            "Your Student Portal Credentials",
                            $@"
                        <p>Dear {universityStudent.Name},</p>
                        <p>Welcome to Postgraduate! Your account has been activated.
                           Below are your login credentials:</p>
                        <ul>
                            <li><strong>Username:</strong> {universityStudent.StudentId}</li>
                            <li><strong>Password:</strong> {generatedPassword}</li>
                        </ul>
                        <p>Please log in and change your password immediately.</p>
                        <p>If you encounter any issues, contact us at mycode1997@gmail.com.</p>
                        <p>Kind regards,</p>
                        <p>Admin</p>"
                );

                TempData["success"] = $"Student imported to Information System and credentials sent to {universityStudent.Email}.";
            }
            else
            {
                TempData["error"] = string.Join(", ", result.Errors.Select(e => e.Description));
            }

            return RedirectToAction("ListStudent");
        }

        private string GenerateRandomPassword(int length)
        {
            const string chars = "ABCDEFGHJKLMNPQRSTUVWXYZabcdefghijkmnpqrstuvwxyz23456789@#!";
            var rng = RandomNumberGenerator.Create();
            var bytes = new byte[length];
            rng.GetBytes(bytes);
            return new string(bytes.Select(b => chars[b % chars.Length]).ToArray());
        }
        public async Task<IActionResult> ListStudent()
        {
            var student = await _db.UniversityStudents.ToListAsync();
            return View(student);
        }
        public async Task<IActionResult> ListFacultyStudent()
        {
            var student = await _db.Students.ToListAsync();
            return View(student);
        }
        //public IActionResult AddUser()
        //{
        //    var userCollection = new UserCollection();
        //    return View(userCollection);
        //}
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> AddUser(UserCollection model)
        //{
        //    var existingUser = await _userManager.FindByEmailAsync(model.ApplicationUser.Email);
        //    if (existingUser != null)
        //    {
        //        TempData["error"] = "A user with this email already exists.";
        //        return View(model);
        //    }
        //    var generatedPassword = GenerateRandomPassword();

        //    var user = new ApplicationUser
        //    {
        //        UserName = GenerateUserName(model.ApplicationUser.Email),
        //        Email = model.ApplicationUser.Email,
        //        UserRole = model.ApplicationUser.UserRole
        //    };

        //    var result = await _userManager.CreateAsync(user, generatedPassword);
        //    string userFirstName;

        //    if (model.ApplicationUser.UserRole == "Supervisor")
        //        userFirstName = model.Supervisor.Name + " " + model.Supervisor.Surname;
        //    else if (model.ApplicationUser.UserRole == "SciComChair")
        //        userFirstName = model.SciComChair.Name + " " + model.SciComChair.Surname;
        //    else
        //        userFirstName = "User";


        //    if (result.Succeeded)
        //    {
        //        await _userManager.AddToRoleAsync(user, user.UserRole);

        //        _myEmailSender.SendEmail(user.Email,
        //                    "Portal Credentials",
        //                    $@"
        //                    <p>Dear {userFirstName},</p>
        //                    <p>Welcome! We are excited to have you on board. Below are your login credentials:</p>
        //                    <ul>
        //                        <li><strong>Username:</strong> {user.UserName}</li>
        //                        <li><strong>Password:</strong> {generatedPassword}</li>
        //                    </ul>
        //                    <p>If you encounter any issues, feel free to reach out to our support team at mycode1997@gmail.com.</p>
        //                    <p>Kind regards,</p>
        //                    <p>The E-Prescribing Admin</p>"

        //        );

        //        if (user.UserRole == "Supervisor")
        //        {
        //            var supervisor = new Supervisor
        //            {
        //                Name = model.Supervisor.Name,
        //                Surname = model.Supervisor.Surname,
        //                Email = model.ApplicationUser.Email,
        //                UserId = user.Id,
        //            };
        //            _db.Supervisors.Add(supervisor);
        //        }
        //        else if (user.UserRole == "SciComChair")
        //        {
        //            var sciComChair = new SciComChair
        //            {
        //                Name = model.SciComChair.Name,
        //                Surname = model.SciComChair.Surname,
        //                Email = model.ApplicationUser.Email,
        //                UserId = user.Id,
        //            };
        //            _db.SciComChairs.Add(sciComChair);
        //        }
        //        await _db.SaveChangesAsync();

        //        if (user.UserRole == "Supervisor")
        //        {
        //            return RedirectToAction("ListSupervisor");
        //        }
        //        else if (user.UserRole == "SciComChair")
        //        {
        //            return RedirectToAction("ListSciComChair");
        //        }
        //        else
        //        {
        //            View(model);
        //        }

        //    }
        //    return View(model);
        //}
        //public async Task<IActionResult> ListSupervisor()
        //{
        //    var users = await _userManager.Users.ToListAsync();

        //    var userList = new List<UserViewModel>();

        //    foreach (var user in users)
        //    {
        //        var userRole = (await _userManager.GetRolesAsync(user)).FirstOrDefault();

        //        if (userRole == "Supervisor")
        //        {
        //            var supervisor = await _db.Supervisors.FirstOrDefaultAsync(n => n.UserId == user.Id);
        //            if (supervisor != null)
        //            {
        //                userList.Add(new UserViewModel
        //                {
        //                    UserName = user.UserName,
        //                    Email = user.Email,
        //                    UserRole = userRole,
        //                    Name = supervisor.Name,
        //                    Surname = supervisor.Surname,
        //                    SupervisorId = supervisor.SupervisorId  


        //                });
        //            }
        //        }
        //    }

        //    return View(userList);
        //}
        //public async Task<IActionResult> ListSciComChair()
        //{
        //    var users = await _userManager.Users.ToListAsync();

        //    var userList = new List<UserViewModel>();

        //    foreach (var user in users)
        //    {
        //        var userRole = (await _userManager.GetRolesAsync(user)).FirstOrDefault();

        //        if (userRole == "SciComChair")
        //        {
        //            var sciComChair = await _db.SciComChairs.FirstOrDefaultAsync(n => n.UserId == user.Id);
        //            if (sciComChair != null)
        //            {
        //                userList.Add(new UserViewModel
        //                {
        //                    UserName = user.UserName,
        //                    Email = user.Email,
        //                    UserRole = userRole,
        //                    Name = sciComChair.Name,
        //                    Surname = sciComChair.Surname,
        //                    SupervisorId = sciComChair.SciComChairId


        //                });
        //            }
        //        }
        //    }

        //    return View(userList);
        //}



        public static string GenerateRandomPassword(PasswordOptions opts = null)
        {
            if (opts == null) opts = new PasswordOptions()
            {
                RequiredLength = 8,
                RequiredUniqueChars = 4,
                RequireDigit = true,
                RequireLowercase = true,
                RequireNonAlphanumeric = true,
                RequireUppercase = true
            };

            string[] randomChars = new[] { "ABCDEFGHJKLMNOPQRSTUVWXYZ", "abcdefghijkmnopqrstuvwxyz", "0123456789", "!@$?_-" };

            Random rand = new Random(Environment.TickCount);
            List<char> chars = new List<char>();

            if (opts.RequireUppercase)
                chars.Insert(rand.Next(0, chars.Count),
                    randomChars[0][rand.Next(0, randomChars[0].Length)]);

            if (opts.RequireLowercase)
                chars.Insert(rand.Next(0, chars.Count),
                    randomChars[1][rand.Next(0, randomChars[1].Length)]);

            if (opts.RequireDigit)
                chars.Insert(rand.Next(0, chars.Count),
                    randomChars[2][rand.Next(0, randomChars[2].Length)]);

            if (opts.RequireNonAlphanumeric)
                chars.Insert(rand.Next(0, chars.Count),
                    randomChars[3][rand.Next(0, randomChars[3].Length)]);

            for (int i = chars.Count; i < opts.RequiredLength
                || chars.Distinct().Count() < opts.RequiredUniqueChars; i++)
            {
                string rcs = randomChars[rand.Next(0, randomChars.Length)];
                chars.Insert(rand.Next(0, chars.Count),
                    rcs[rand.Next(0, rcs.Length)]);
            }

            return new string(chars.ToArray());
        }
        private string GenerateUserName(string email)
        {

            return email.Split('@')[0];
        }
    }
}
