using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PostGradSystem.Migrations
{
    /// <inheritdoc />
    public partial class addReportProgress : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProgressReports_Supervisors_SupevisorId",
                table: "ProgressReports");

            migrationBuilder.RenameColumn(
                name: "SupevisorId",
                table: "ProgressReports",
                newName: "SupervisorId");

            migrationBuilder.RenameIndex(
                name: "IX_ProgressReports_SupevisorId",
                table: "ProgressReports",
                newName: "IX_ProgressReports_SupervisorId");

            migrationBuilder.AddColumn<string>(
                name: "Challenges",
                table: "ProgressReports",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "MitigationPlan",
                table: "ProgressReports",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ProgressSummary",
                table: "ProgressReports",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SupervisorRecommendation",
                table: "ProgressReports",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_ProgressReports_Supervisors_SupervisorId",
                table: "ProgressReports",
                column: "SupervisorId",
                principalTable: "Supervisors",
                principalColumn: "SupervisorId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProgressReports_Supervisors_SupervisorId",
                table: "ProgressReports");

            migrationBuilder.DropColumn(
                name: "Challenges",
                table: "ProgressReports");

            migrationBuilder.DropColumn(
                name: "MitigationPlan",
                table: "ProgressReports");

            migrationBuilder.DropColumn(
                name: "ProgressSummary",
                table: "ProgressReports");

            migrationBuilder.DropColumn(
                name: "SupervisorRecommendation",
                table: "ProgressReports");

            migrationBuilder.RenameColumn(
                name: "SupervisorId",
                table: "ProgressReports",
                newName: "SupevisorId");

            migrationBuilder.RenameIndex(
                name: "IX_ProgressReports_SupervisorId",
                table: "ProgressReports",
                newName: "IX_ProgressReports_SupevisorId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProgressReports_Supervisors_SupevisorId",
                table: "ProgressReports",
                column: "SupevisorId",
                principalTable: "Supervisors",
                principalColumn: "SupervisorId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
