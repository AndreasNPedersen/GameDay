using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GameDay.Migrations
{
    public partial class v3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Groups_UserData_UserGroupOwnedUserId",
                table: "Groups");

            migrationBuilder.DropIndex(
                name: "IX_Groups_UserGroupOwnedUserId",
                table: "Groups");

            migrationBuilder.DropColumn(
                name: "UserGroupOwnedUserId",
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

        protected override void Down(MigrationBuilder migrationBuilder)
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
                name: "UserGroupOwnedUserId",
                table: "Groups",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Groups_UserGroupOwnedUserId",
                table: "Groups",
                column: "UserGroupOwnedUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Groups_UserData_UserGroupOwnedUserId",
                table: "Groups",
                column: "UserGroupOwnedUserId",
                principalTable: "UserData",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
