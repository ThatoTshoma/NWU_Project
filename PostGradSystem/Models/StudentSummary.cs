namespace PostGradSystem.Models
{
    public class StudentSummary
    {
        public int StudentId { get; set; }
        public string FullName { get; set; }
        public string Status { get; set; }
        public double AvgMarks { get; set; }
        public string TopGrade { get; set; }
        public decimal OutstandingBalance { get; set; }
        public double AttendancePct { get; set; }
        public bool HasCriminalRecord { get; set; }
        public double EmployabilityScore { get; set; }
    }

    public class ChartData
    {
        public string Label { get; set; }
        public int Value { get; set; }
    }

    public class DashboardViewModel
    {
        public int TotalStudents { get; set; }
        public int ActiveStudents { get; set; }
        public int StudentsWithOutstandingFees { get; set; }
        public int FlaggedStudents { get; set; }
        public decimal TotalOutstandingFees { get; set; }
        public double AvgAttendance { get; set; }
        public double AvgEmployabilityScore { get; set; }

        public List<StudentSummary> StudentSummaries { get; set; }
        public List<ChartData> StatusDistribution { get; set; }
        public List<ChartData> GradeDistribution { get; set; }
        public List<ChartData> AttendanceDistribution { get; set; }
        public List<ChartData> PaymentDistribution { get; set; }
        public List<ChartData> EnrollmentByProgram { get; set; }
    }
}
