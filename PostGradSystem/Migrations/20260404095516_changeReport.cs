using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PostGradSystem.Migrations
{
    /// <inheritdoc />
    public partial class changeReport : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProgressReports_Students_StudentId",
                table: "ProgressReports");

            migrationBuilder.RenameColumn(
                name: "StudentId",
                table: "ProgressReports",
                newName: "TitleRegistrationId");

            migrationBuilder.RenameIndex(
                name: "IX_ProgressReports_StudentId",
                table: "ProgressReports",
                newName: "IX_ProgressReports_TitleRegistrationId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProgressReports_TitleRegistrations_TitleRegistrationId",
                table: "ProgressReports",
                column: "TitleRegistrationId",
                principalTable: "TitleRegistrations",
                principalColumn: "TitleRegistrationId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProgressReports_TitleRegistrations_TitleRegistrationId",
                table: "ProgressReports");

            migrationBuilder.RenameColumn(
                name: "TitleRegistrationId",
                table: "ProgressReports",
                newName: "StudentId");

            migrationBuilder.RenameIndex(
                name: "IX_ProgressReports_TitleRegistrationId",
                table: "ProgressReports",
                newName: "IX_ProgressReports_StudentId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProgressReports_Students_StudentId",
                table: "ProgressReports",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "StudentId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
