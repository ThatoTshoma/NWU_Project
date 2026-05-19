using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PostGradSystem.Migrations
{
    /// <inheritdoc />
    public partial class MAE : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InformationSystems_AspNetUsers_ApplicationUserId",
                table: "InformationSystems");

            migrationBuilder.DropForeignKey(
                name: "FK_InformationSystems_Students_StudentId",
                table: "InformationSystems");

            migrationBuilder.DropIndex(
                name: "IX_InformationSystems_ApplicationUserId",
                table: "InformationSystems");

            migrationBuilder.DropIndex(
                name: "IX_InformationSystems_StudentId",
                table: "InformationSystems");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "InformationSystems");

            migrationBuilder.CreateIndex(
                name: "IX_InformationSystems_UserId",
                table: "InformationSystems",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_InformationSystems_AspNetUsers_UserId",
                table: "InformationSystems",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InformationSystems_AspNetUsers_UserId",
                table: "InformationSystems");

            migrationBuilder.DropIndex(
                name: "IX_InformationSystems_UserId",
                table: "InformationSystems");

            migrationBuilder.AddColumn<int>(
                name: "ApplicationUserId",
                table: "InformationSystems",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_InformationSystems_ApplicationUserId",
                table: "InformationSystems",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_InformationSystems_StudentId",
                table: "InformationSystems",
                column: "StudentId");

            migrationBuilder.AddForeignKey(
                name: "FK_InformationSystems_AspNetUsers_ApplicationUserId",
                table: "InformationSystems",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_InformationSystems_Students_StudentId",
                table: "InformationSystems",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "StudentId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
