using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PostGradSystem.Migrations
{
    /// <inheritdoc />
    public partial class ADDa : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StudentId",
                table: "BackroundChecks",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_BackroundChecks_StudentId",
                table: "BackroundChecks",
                column: "StudentId");

            migrationBuilder.AddForeignKey(
                name: "FK_BackroundChecks_Students_StudentId",
                table: "BackroundChecks",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "StudentId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BackroundChecks_Students_StudentId",
                table: "BackroundChecks");

            migrationBuilder.DropIndex(
                name: "IX_BackroundChecks_StudentId",
                table: "BackroundChecks");

            migrationBuilder.DropColumn(
                name: "StudentId",
                table: "BackroundChecks");
        }
    }
}
