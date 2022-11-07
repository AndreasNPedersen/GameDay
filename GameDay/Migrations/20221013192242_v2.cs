using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GameDay.Migrations
{
    public partial class v2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserDataUserId",
                table: "GroupAttendees",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_GroupAttendees_UserDataUserId",
                table: "GroupAttendees",
                column: "UserDataUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_GroupAttendees_UserData_UserDataUserId",
                table: "GroupAttendees",
                column: "UserDataUserId",
                principalTable: "UserData",
                principalColumn: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GroupAttendees_UserData_UserDataUserId",
                table: "GroupAttendees");

            migrationBuilder.DropIndex(
                name: "IX_GroupAttendees_UserDataUserId",
                table: "GroupAttendees");

            migrationBuilder.DropColumn(
                name: "UserDataUserId",
                table: "GroupAttendees");
        }
    }
}
