using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GameDay.Migrations
{
    public partial class v6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Groups_UserData_UserOwnerUserId",
                table: "Groups");

            migrationBuilder.DropIndex(
                name: "IX_Groups_UserOwnerUserId",
                table: "Groups");

            migrationBuilder.DropColumn(
                name: "UserOwnerUserId",
                table: "Groups");

            migrationBuilder.CreateTable(
                name: "GroupOwner",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    GroupId = table.Column<int>(type: "int", nullable: false),
                    userOwnerUserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupOwner", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GroupOwner_Groups_GroupId",
                        column: x => x.GroupId,
                        principalTable: "Groups",
                        principalColumn: "GroupId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GroupOwner_UserData_userOwnerUserId",
                        column: x => x.userOwnerUserId,
                        principalTable: "UserData",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_GroupOwner_GroupId",
                table: "GroupOwner",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_GroupOwner_userOwnerUserId",
                table: "GroupOwner",
                column: "userOwnerUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GroupOwner");

            migrationBuilder.AddColumn<int>(
                name: "UserOwnerUserId",
                table: "Groups",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Groups_UserOwnerUserId",
                table: "Groups",
                column: "UserOwnerUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Groups_UserData_UserOwnerUserId",
                table: "Groups",
                column: "UserOwnerUserId",
                principalTable: "UserData",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
