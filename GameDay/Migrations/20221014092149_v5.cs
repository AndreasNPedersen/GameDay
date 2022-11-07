using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GameDay.Migrations
{
    public partial class v5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GroupAttendees_UserData_UserDataUserId",
                table: "GroupAttendees");

            migrationBuilder.DropForeignKey(
                name: "FK_Groups_UserData_UserDataUserId",
                table: "Groups");

            migrationBuilder.DropIndex(
                name: "IX_Groups_UserDataUserId",
                table: "Groups");

            migrationBuilder.DropIndex(
                name: "IX_GroupAttendees_UserDataUserId",
                table: "GroupAttendees");

            migrationBuilder.DropColumn(
                name: "UserDataUserId",
                table: "Groups");

            migrationBuilder.DropColumn(
                name: "UserDataUserId",
                table: "GroupAttendees");

            migrationBuilder.AddColumn<int>(
                name: "UserOwnerUserId",
                table: "Groups",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserAttendeenUserId",
                table: "GroupAttendees",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Groups_UserOwnerUserId",
                table: "Groups",
                column: "UserOwnerUserId");

            migrationBuilder.CreateIndex(
                name: "IX_GroupAttendees_UserAttendeenUserId",
                table: "GroupAttendees",
                column: "UserAttendeenUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_GroupAttendees_UserData_UserAttendeenUserId",
                table: "GroupAttendees",
                column: "UserAttendeenUserId",
                principalTable: "UserData",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Groups_UserData_UserOwnerUserId",
                table: "Groups",
                column: "UserOwnerUserId",
                principalTable: "UserData",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GroupAttendees_UserData_UserAttendeenUserId",
                table: "GroupAttendees");

            migrationBuilder.DropForeignKey(
                name: "FK_Groups_UserData_UserOwnerUserId",
                table: "Groups");

            migrationBuilder.DropIndex(
                name: "IX_Groups_UserOwnerUserId",
                table: "Groups");

            migrationBuilder.DropIndex(
                name: "IX_GroupAttendees_UserAttendeenUserId",
                table: "GroupAttendees");

            migrationBuilder.DropColumn(
                name: "UserOwnerUserId",
                table: "Groups");

            migrationBuilder.DropColumn(
                name: "UserAttendeenUserId",
                table: "GroupAttendees");

            migrationBuilder.AddColumn<int>(
                name: "UserDataUserId",
                table: "Groups",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserDataUserId",
                table: "GroupAttendees",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Groups_UserDataUserId",
                table: "Groups",
                column: "UserDataUserId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Groups_UserData_UserDataUserId",
                table: "Groups",
                column: "UserDataUserId",
                principalTable: "UserData",
                principalColumn: "UserId");
        }
    }
}
