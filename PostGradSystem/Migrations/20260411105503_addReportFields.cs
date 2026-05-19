using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PostGradSystem.Migrations
{
    /// <inheritdoc />
    public partial class addReportFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ChairSignature",
                table: "ProgressReports",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DecisionDate",
                table: "ProgressReports",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PreviousWarningLetters",
                table: "ProgressReports",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ScientificCommitteeDecision",
                table: "ProgressReports",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StudentSignature",
                table: "ProgressReports",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SupervisorSignature",
                table: "ProgressReports",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ChairSignature",
                table: "ProgressReports");

            migrationBuilder.DropColumn(
                name: "DecisionDate",
                table: "ProgressReports");

            migrationBuilder.DropColumn(
                name: "PreviousWarningLetters",
                table: "ProgressReports");

            migrationBuilder.DropColumn(
                name: "ScientificCommitteeDecision",
                table: "ProgressReports");

            migrationBuilder.DropColumn(
                name: "StudentSignature",
                table: "ProgressReports");

            migrationBuilder.DropColumn(
                name: "SupervisorSignature",
                table: "ProgressReports");
        }
    }
}
