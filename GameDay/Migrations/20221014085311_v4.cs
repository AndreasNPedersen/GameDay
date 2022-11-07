using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GameDay.Migrations
{
    public partial class v4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserData_UserData_UserDataUserId",
                table: "UserData");

            migrationBuilder.DropIndex(
                name: "IX_UserData_UserDataUserId",
                table: "UserData");

            migrationBuilder.DropColumn(
                name: "UserDataUserId",
                table: "UserData");

            migrationBuilder.AddColumn<int>(
                name: "UserDataUserId",
                table: "Groups",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Groups_UserDataUserId",
                table: "Groups",
                column: "UserDataUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Groups_UserData_UserDataUserId",
                table: "Groups",
                column: "UserDataUserId",
                principalTable: "UserData",
                principalColumn: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Groups_UserData_UserDataUserId",
                table: "Groups");

            migrationBuilder.DropIndex(
                name: "IX_Groups_UserDataUserId",
                table: "Groups");

            migrationBuilder.DropColumn(
                name: "UserDataUserId",
                table: "Groups");

            migrationBuilder.AddColumn<int>(
                name: "UserDataUserId",
                table: "UserData",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserData_UserDataUserId",
                table: "UserData",
                column: "UserDataUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserData_UserData_UserDataUserId",
                table: "UserData",
                column: "UserDataUserId",
                principalTable: "UserData",
                principalColumn: "UserId");
        }
    }
}
