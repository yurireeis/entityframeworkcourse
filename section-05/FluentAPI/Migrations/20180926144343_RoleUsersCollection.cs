using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAnnotations.Migrations
{
    public partial class RoleUsersCollection : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RoleID",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RoleID1",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserID",
                table: "Permission",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleID",
                table: "Users",
                column: "RoleID");

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleID1",
                table: "Users",
                column: "RoleID1");

            migrationBuilder.CreateIndex(
                name: "IX_Permission_UserID",
                table: "Permission",
                column: "UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_Permission_Users_UserID",
                table: "Permission",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Role_RoleID",
                table: "Users",
                column: "RoleID",
                principalTable: "Role",
                principalColumn: "RoleID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Role_RoleID1",
                table: "Users",
                column: "RoleID1",
                principalTable: "Role",
                principalColumn: "RoleID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Permission_Users_UserID",
                table: "Permission");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Role_RoleID",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Role_RoleID1",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_RoleID",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_RoleID1",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Permission_UserID",
                table: "Permission");

            migrationBuilder.DropColumn(
                name: "RoleID",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "RoleID1",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "UserID",
                table: "Permission");
        }
    }
}
