using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PostGradSystem.Data;
using PostGradSystem.Models;

namespace PostGradSystem.Controllers
{
    public class DashboardController : Controller
    {
        private ApplicationDbContext _db;
        public DashboardController(ApplicationDbContext db)
        {
            _db = db;

        }

        public async Task<IActionResult> Index()
        {
            var vm = new DashboardViewModel();

            // ── KPI 1: Total Students ──────────────────────────────────────
            vm.TotalStudents = await _db.Database
               .SqlQueryRaw<int>("SELECT COUNT(*) AS \"Value\" FROM students")
               .FirstOrDefaultAsync();

            // ── KPI 2: Active Students ─────────────────────────────────────
            vm.ActiveStudents = await _db.Database
                .SqlQueryRaw<int>("""
                    SELECT COUNT(*) AS "Value" 
                    FROM students
                    WHERE LOWER(status) = 'active'
                """)
                .FirstOrDefaultAsync();

            // ── KPI 3: Students with Outstanding Fees ─────────────────────
            vm.StudentsWithOutstandingFees = await _db.Database
                .SqlQueryRaw<int>("""
                    SELECT COUNT(DISTINCT StudentId) AS "Value"
                    FROM payments
                    WHERE OutstandingBalance > 0
                """)
                .FirstOrDefaultAsync();

            // ── KPI 4: Flagged (Criminal Record) ──────────────────────────
            vm.FlaggedStudents = await _db.Database
                .SqlQueryRaw<int>("""
                    SELECT COUNT(*) AS "Value"
                    FROM BackroundChecks
                    WHERE HasCriminalRecord = NULL 
                """)
                .FirstOrDefaultAsync();

            // ── KPI 5: Total Outstanding Fees Amount ──────────────────────
            vm.TotalOutstandingFees = await _db.Database
                .SqlQueryRaw<decimal>("""
                    SELECT COALESCE(SUM(OutstandingBalance), 0) AS "Value"
                    FROM payments
                """)
                .FirstOrDefaultAsync();

            // ── KPI 6: Average Attendance % ───────────────────────────────
            vm.AvgAttendance = await _db.Database
                .SqlQueryRaw<double>("""
                    SELECT COALESCE(AVG(AttendancePercentage), 0) AS "Value"
                    FROM attendances
                """)
                .FirstOrDefaultAsync();

            // ── KPI 7: Average Employability Score ────────────────────────
            vm.AvgEmployabilityScore = await _db.Database
                .SqlQueryRaw<double>("""
                    SELECT COALESCE(AVG(score), 0) AS "Value"
                    FROM Employabilities
                """)
                .FirstOrDefaultAsync();

            // ── STUDENT SUMMARIES TABLE ───────────────────────────────────
            vm.StudentSummaries = await _db.Database
                .SqlQueryRaw<StudentSummary>(@"
        WITH ModeCTE AS (
            SELECT 
                StudentId,
                grade,
                ROW_NUMBER() OVER (PARTITION BY StudentId ORDER BY COUNT(*) DESC) AS rn
            FROM results
            GROUP BY StudentId, grade
        )
        SELECT
            s.StudentId                                   AS StudentId,
            CONCAT(s.name, ' ', s.surname)                 AS FullName,
            COALESCE(s.status, 'Unknown')                  AS Status,
            COALESCE(AVG(CAST(r.mark AS FLOAT)), 0) AS AvgMarks,
            COALESCE(MAX(m.grade), 'N/A')                  AS TopGrade,   -- or use m.grade where rn=1
            COALESCE(SUM(p.OutstandingBalance), 0)         AS OutstandingBalance,
            COALESCE(AVG(CAST(a.AttendancePercentage AS FLOAT)), 0) AS AttendancePct,
            COALESCE(bc.HasCriminalRecord, 0)              AS HasCriminalRecord,
            COALESCE(AVG(CAST(e.score AS FLOAT)), 0)       AS EmployabilityScore
        FROM students s
        LEFT JOIN results r          ON s.StudentId = r.StudentId
        LEFT JOIN payments p         ON s.StudentId = p.StudentId
        LEFT JOIN attendances a      ON s.StudentId = a.StudentId
        LEFT JOIN BackroundChecks bc ON s.StudentId = bc.StudentId
        LEFT JOIN employabilities e  ON s.StudentId = e.StudentId
        LEFT JOIN ModeCTE m          ON s.StudentId = m.StudentId AND m.rn = 1
        GROUP BY
            s.StudentId, s.name, s.surname,
            s.status, bc.HasCriminalRecord
        ORDER BY s.StudentId
        OFFSET 0 ROWS FETCH NEXT 50 ROWS ONLY
    ")
                .ToListAsync();

            // ── CHART 1: Student Status Distribution ──────────────────────
            vm.StatusDistribution = await _db.Database
                .SqlQueryRaw<ChartData>(@"
        SELECT COALESCE(status, 'Unknown') AS Label,
               COUNT(*) AS Value
        FROM students
        GROUP BY status
        ORDER BY Value DESC
    ")
                .ToListAsync();

            // ── CHART 2: Grade Distribution from Results ──────────────────
            vm.GradeDistribution = await _db.Database
                .SqlQueryRaw<ChartData>(@"
        SELECT COALESCE(grade, 'N/A') AS Label,
               COUNT(*) AS Value
        FROM results
        GROUP BY grade
        ORDER BY Label
    ")
                .ToListAsync();

            // ── CHART 3: Attendance Status Breakdown ──────────────────────
            vm.AttendanceDistribution = await _db.Database
                .SqlQueryRaw<ChartData>(@"
        SELECT COALESCE(status, 'Unknown') AS Label,
               COUNT(*) AS Value
        FROM attendances
        GROUP BY status
        ORDER BY Value DESC
    ")
                .ToListAsync();

            // ── CHART 4: Payment Status (Paid vs Outstanding) ─────────────
            // Fixed: repeated CASE in GROUP BY, no alias used in GROUP BY
            vm.PaymentDistribution = await _db.Database
                .SqlQueryRaw<ChartData>(@"
        SELECT
            CASE
                WHEN OutstandingBalance <= 0 THEN 'Fully Paid'
                WHEN OutstandingBalance > 0 AND amountpaid > 0 THEN 'Partial'
                ELSE 'Not Paid'
            END AS Label,
            COUNT(*) AS Value
        FROM payments
        GROUP BY
            CASE
                WHEN OutstandingBalance <= 0 THEN 'Fully Paid'
                WHEN OutstandingBalance > 0 AND amountpaid > 0 THEN 'Partial'
                ELSE 'Not Paid'
            END
        ORDER BY Value DESC
    ")
                .ToListAsync();

            // ── CHART 5: Enrollment by Program ────────────────────────────
            // Fixed: removed LIMIT, used TOP 10, removed incorrect "int" type annotation
            vm.EnrollmentByProgram = await _db.Database
                .SqlQueryRaw<ChartData>(@"
        SELECT TOP 10
            pr.name AS Label,
            COUNT(*) AS Value
        FROM enrollments en
        JOIN modules m ON en.moduleid = m.moduleid
        JOIN departments d ON m.departmentid = d.departmentid
        JOIN programmes pr ON pr.departmentid = d.departmentid
        GROUP BY pr.name
        ORDER BY Value DESC
    ")
                .ToListAsync();

            return View(vm);
        }
    }
}
