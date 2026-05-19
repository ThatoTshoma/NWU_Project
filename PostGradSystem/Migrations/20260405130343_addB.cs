using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PostGradSystem.Migrations
{
    /// <inheritdoc />
    public partial class addB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MilestoneProgresses_Milestone_MilestoneId",
                table: "MilestoneProgresses");

            migrationBuilder.DropForeignKey(
                name: "FK_ProgressReports_Supervisors_SupervisorId",
                table: "ProgressReports");

            migrationBuilder.DropForeignKey(
                name: "FK_ProgressReports_TitleRegistrations_TitleRegistrationId",
                table: "ProgressReports");

            migrationBuilder.DropIndex(
                name: "IX_MilestoneProgresses_ProgressReportId",
                table: "MilestoneProgresses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Milestone",
                table: "Milestone");

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
                name: "EthicsApprovalProgress",
                table: "ProgressReports");

            migrationBuilder.DropColumn(
                name: "FinalisingProgress",
                table: "ProgressReports");

            migrationBuilder.DropColumn(
                name: "ProposedMitigationSupport",
                table: "ProgressReports");

            migrationBuilder.DropColumn(
                name: "ReasonsForLackOfProgress",
                table: "ProgressReports");

            migrationBuilder.DropColumn(
                name: "ResearchProposalProgress",
                table: "ProgressReports");

            migrationBuilder.DropColumn(
                name: "SubmittedProgress",
                table: "ProgressReports");

            migrationBuilder.RenameTable(
                name: "Milestone",
                newName: "Milestones");

            migrationBuilder.RenameColumn(
                name: "OverallProgressRating",
                table: "ProgressReports",
                newName: "OverallRating");

            migrationBuilder.RenameColumn(
                name: "LastUpdated",
                table: "ProgressReports",
                newName: "UpdatedAt");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "ProgressReports",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "LackOfProgressReasons",
                table: "ProgressReports",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "NextMeetingDate",
                table: "ProgressReports",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "PeriodFrom",
                table: "ProgressReports",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "PeriodTo",
                table: "ProgressReports",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "ProposedMitigation",
                table: "ProgressReports",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SupervisorComments",
                table: "ProgressReports",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Milestones",
                table: "Milestones",
                column: "Id");

            migrationBuilder.InsertData(
                table: "Milestones",
                columns: new[] { "Id", "DisplayOrder", "Name" },
                values: new object[,]
                {
                    { 1, 1, "Coursework modules" },
                    { 2, 2, "Title registration approved by Higher Degrees Committee" },
                    { 3, 3, "Data analysis" },
                    { 4, 4, "Chapter 3" },
                    { 5, 5, "Chapter 6" },
                    { 6, 6, "Chapter 9" },
                    { 7, 7, "Resubmission process" },
                    { 8, 8, "Research proposal" },
                    { 9, 9, "Functionaries approved by Higher Degrees Committee" },
                    { 10, 10, "Chapter 1" },
                    { 11, 11, "Chapter 4" },
                    { 12, 12, "Chapter 7" },
                    { 13, 13, "Finalising" },
                    { 14, 14, "Proof of progress included" },
                    { 15, 15, "Ethics approval" },
                    { 16, 16, "Data collection" },
                    { 17, 17, "Chapter 2" },
                    { 18, 18, "Chapter 5" },
                    { 19, 19, "Chapter 8" },
                    { 20, 20, "Submitted" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_MilestoneProgresses_ProgressReportId_MilestoneId",
                table: "MilestoneProgresses",
                columns: new[] { "ProgressReportId", "MilestoneId" },
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_MilestoneProgresses_Milestones_MilestoneId",
                table: "MilestoneProgresses",
                column: "MilestoneId",
                principalTable: "Milestones",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProgressReports_Supervisors_SupervisorId",
                table: "ProgressReports",
                column: "SupervisorId",
                principalTable: "Supervisors",
                principalColumn: "SupervisorId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProgressReports_TitleRegistrations_TitleRegistrationId",
                table: "ProgressReports",
                column: "TitleRegistrationId",
                principalTable: "TitleRegistrations",
                principalColumn: "TitleRegistrationId",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MilestoneProgresses_Milestones_MilestoneId",
                table: "MilestoneProgresses");

            migrationBuilder.DropForeignKey(
                name: "FK_ProgressReports_Supervisors_SupervisorId",
                table: "ProgressReports");

            migrationBuilder.DropForeignKey(
                name: "FK_ProgressReports_TitleRegistrations_TitleRegistrationId",
                table: "ProgressReports");

            migrationBuilder.DropIndex(
                name: "IX_MilestoneProgresses_ProgressReportId_MilestoneId",
                table: "MilestoneProgresses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Milestones",
                table: "Milestones");

            migrationBuilder.DeleteData(
                table: "Milestones",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Milestones",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Milestones",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Milestones",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Milestones",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Milestones",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Milestones",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Milestones",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Milestones",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Milestones",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Milestones",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Milestones",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Milestones",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Milestones",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Milestones",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Milestones",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Milestones",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Milestones",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Milestones",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Milestones",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "ProgressReports");

            migrationBuilder.DropColumn(
                name: "LackOfProgressReasons",
                table: "ProgressReports");

            migrationBuilder.DropColumn(
                name: "NextMeetingDate",
                table: "ProgressReports");

            migrationBuilder.DropColumn(
                name: "PeriodFrom",
                table: "ProgressReports");

            migrationBuilder.DropColumn(
                name: "PeriodTo",
                table: "ProgressReports");

            migrationBuilder.DropColumn(
                name: "ProposedMitigation",
                table: "ProgressReports");

            migrationBuilder.DropColumn(
                name: "SupervisorComments",
                table: "ProgressReports");

            migrationBuilder.RenameTable(
                name: "Milestones",
                newName: "Milestone");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "ProgressReports",
                newName: "LastUpdated");

            migrationBuilder.RenameColumn(
                name: "OverallRating",
                table: "ProgressReports",
                newName: "OverallProgressRating");

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

            migrationBuilder.AddColumn<string>(
                name: "EthicsApprovalProgress",
                table: "ProgressReports",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FinalisingProgress",
                table: "ProgressReports",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ProposedMitigationSupport",
                table: "ProgressReports",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ReasonsForLackOfProgress",
                table: "ProgressReports",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ResearchProposalProgress",
                table: "ProgressReports",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SubmittedProgress",
                table: "ProgressReports",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Milestone",
                table: "Milestone",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_MilestoneProgresses_ProgressReportId",
                table: "MilestoneProgresses",
                column: "ProgressReportId");

            migrationBuilder.AddForeignKey(
                name: "FK_MilestoneProgresses_Milestone_MilestoneId",
                table: "MilestoneProgresses",
                column: "MilestoneId",
                principalTable: "Milestone",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProgressReports_Supervisors_SupervisorId",
                table: "ProgressReports",
                column: "SupervisorId",
                principalTable: "Supervisors",
                principalColumn: "SupervisorId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProgressReports_TitleRegistrations_TitleRegistrationId",
                table: "ProgressReports",
                column: "TitleRegistrationId",
                principalTable: "TitleRegistrations",
                principalColumn: "TitleRegistrationId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
