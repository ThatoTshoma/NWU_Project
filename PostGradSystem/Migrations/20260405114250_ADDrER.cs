using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PostGradSystem.Migrations
{
    /// <inheritdoc />
    public partial class ADDrER : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SupervisorRecommendation",
                table: "ProgressReports",
                newName: "SubmittedProgress");

            migrationBuilder.RenameColumn(
                name: "SubmissionDate",
                table: "ProgressReports",
                newName: "LastUpdated");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "ProgressReports",
                newName: "ResearchProposalProgress");

            migrationBuilder.RenameColumn(
                name: "ProgressSummary",
                table: "ProgressReports",
                newName: "ReasonsForLackOfProgress");

            migrationBuilder.RenameColumn(
                name: "MitigationPlan",
                table: "ProgressReports",
                newName: "ProposedMitigationSupport");

            migrationBuilder.RenameColumn(
                name: "Comments",
                table: "ProgressReports",
                newName: "FinalisingProgress");

            migrationBuilder.RenameColumn(
                name: "Challenges",
                table: "ProgressReports",
                newName: "EthicsApprovalProgress");

            migrationBuilder.AddColumn<string>(
                name: "Chapter1Progress",
                table: "ProgressReports",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Chapter2Progress",
                table: "ProgressReports",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Chapter3Progress",
                table: "ProgressReports",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Chapter4Progress",
                table: "ProgressReports",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Chapter5Progress",
                table: "ProgressReports",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Chapter6Progress",
                table: "ProgressReports",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Chapter7Progress",
                table: "ProgressReports",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Chapter8Progress",
                table: "ProgressReports",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CourseworkModulesProgress",
                table: "ProgressReports",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DataAnalysisProgress",
                table: "ProgressReports",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DataCollectionProgress",
                table: "ProgressReports",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "OverallProgressRating",
                table: "ProgressReports",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Milestone",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    DisplayOrder = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Milestone", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MilestoneProgresses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProgressReportId = table.Column<int>(type: "int", nullable: false),
                    MilestoneId = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MilestoneProgresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MilestoneProgresses_Milestone_MilestoneId",
                        column: x => x.MilestoneId,
                        principalTable: "Milestone",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MilestoneProgresses_ProgressReports_ProgressReportId",
                        column: x => x.ProgressReportId,
                        principalTable: "ProgressReports",
                        principalColumn: "ProgressReportId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MilestoneProgresses_MilestoneId",
                table: "MilestoneProgresses",
                column: "MilestoneId");

            migrationBuilder.CreateIndex(
                name: "IX_MilestoneProgresses_ProgressReportId",
                table: "MilestoneProgresses",
                column: "ProgressReportId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MilestoneProgresses");

            migrationBuilder.DropTable(
                name: "Milestone");

            migrationBuilder.DropColumn(
                name: "Chapter1Progress",
                table: "ProgressReports");

            migrationBuilder.DropColumn(
                name: "Chapter2Progress",
                table: "ProgressReports");

            migrationBuilder.DropColumn(
                name: "Chapter3Progress",
                table: "ProgressReports");

            migrationBuilder.DropColumn(
                name: "Chapter4Progress",
                table: "ProgressReports");

            migrationBuilder.DropColumn(
                name: "Chapter5Progress",
                table: "ProgressReports");

            migrationBuilder.DropColumn(
                name: "Chapter6Progress",
                table: "ProgressReports");

            migrationBuilder.DropColumn(
                name: "Chapter7Progress",
                table: "ProgressReports");

            migrationBuilder.DropColumn(
                name: "Chapter8Progress",
                table: "ProgressReports");

            migrationBuilder.DropColumn(
                name: "CourseworkModulesProgress",
                table: "ProgressReports");

            migrationBuilder.DropColumn(
                name: "DataAnalysisProgress",
                table: "ProgressReports");

            migrationBuilder.DropColumn(
                name: "DataCollectionProgress",
                table: "ProgressReports");

            migrationBuilder.DropColumn(
                name: "OverallProgressRating",
                table: "ProgressReports");

            migrationBuilder.RenameColumn(
                name: "SubmittedProgress",
                table: "ProgressReports",
                newName: "SupervisorRecommendation");

            migrationBuilder.RenameColumn(
                name: "ResearchProposalProgress",
                table: "ProgressReports",
                newName: "Status");

            migrationBuilder.RenameColumn(
                name: "ReasonsForLackOfProgress",
                table: "ProgressReports",
                newName: "ProgressSummary");

            migrationBuilder.RenameColumn(
                name: "ProposedMitigationSupport",
                table: "ProgressReports",
                newName: "MitigationPlan");

            migrationBuilder.RenameColumn(
                name: "LastUpdated",
                table: "ProgressReports",
                newName: "SubmissionDate");

            migrationBuilder.RenameColumn(
                name: "FinalisingProgress",
                table: "ProgressReports",
                newName: "Comments");

            migrationBuilder.RenameColumn(
                name: "EthicsApprovalProgress",
                table: "ProgressReports",
                newName: "Challenges");
        }
    }
}
