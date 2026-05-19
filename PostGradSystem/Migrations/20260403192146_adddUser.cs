using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PostGradSystem.Migrations
{
    /// <inheritdoc />
    public partial class adddUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProgrammeId",
                table: "UniversityStudents",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "StudentId",
                table: "TitleRegistrations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ProgrammeId",
                table: "Students",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_UniversityStudents_ProgrammeId",
                table: "UniversityStudents",
                column: "ProgrammeId");

            migrationBuilder.CreateIndex(
                name: "IX_TitleRegistrations_StudentId",
                table: "TitleRegistrations",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_ProgrammeId",
                table: "Students",
                column: "ProgrammeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Programmes_ProgrammeId",
                table: "Students",
                column: "ProgrammeId",
                principalTable: "Programmes",
                principalColumn: "ProgrammeId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TitleRegistrations_Students_StudentId",
                table: "TitleRegistrations",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "StudentId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UniversityStudents_Programmes_ProgrammeId",
                table: "UniversityStudents",
                column: "ProgrammeId",
                principalTable: "Programmes",
                principalColumn: "ProgrammeId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_Programmes_ProgrammeId",
                table: "Students");

            migrationBuilder.DropForeignKey(
                name: "FK_TitleRegistrations_Students_StudentId",
                table: "TitleRegistrations");

            migrationBuilder.DropForeignKey(
                name: "FK_UniversityStudents_Programmes_ProgrammeId",
                table: "UniversityStudents");

            migrationBuilder.DropIndex(
                name: "IX_UniversityStudents_ProgrammeId",
                table: "UniversityStudents");

            migrationBuilder.DropIndex(
                name: "IX_TitleRegistrations_StudentId",
                table: "TitleRegistrations");

            migrationBuilder.DropIndex(
                name: "IX_Students_ProgrammeId",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "ProgrammeId",
                table: "UniversityStudents");

            migrationBuilder.DropColumn(
                name: "StudentId",
                table: "TitleRegistrations");

            migrationBuilder.DropColumn(
                name: "ProgrammeId",
                table: "Students");
        }
    }
}
