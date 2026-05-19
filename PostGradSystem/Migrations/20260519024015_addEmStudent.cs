using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PostGradSystem.Migrations
{
    /// <inheritdoc />
    public partial class addEmStudent : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StudentId",
                table: "Employabilities",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Employabilities_StudentId",
                table: "Employabilities",
                column: "StudentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employabilities_Students_StudentId",
                table: "Employabilities",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "StudentId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employabilities_Students_StudentId",
                table: "Employabilities");

            migrationBuilder.DropIndex(
                name: "IX_Employabilities_StudentId",
                table: "Employabilities");

            migrationBuilder.DropColumn(
                name: "StudentId",
                table: "Employabilities");
        }
    }
}
