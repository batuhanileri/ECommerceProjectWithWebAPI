using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class deleterole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Admins_RoleAdmins_RoleAdminRoleId",
                table: "Admins");

            migrationBuilder.DropIndex(
                name: "IX_Admins_RoleAdminRoleId",
                table: "Admins");

            migrationBuilder.DropColumn(
                name: "RoleAdminRoleId",
                table: "Admins");

            migrationBuilder.DropColumn(
                name: "RoleId",
                table: "Admins");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RoleAdminRoleId",
                table: "Admins",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RoleId",
                table: "Admins",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Admins_RoleAdminRoleId",
                table: "Admins",
                column: "RoleAdminRoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Admins_RoleAdmins_RoleAdminRoleId",
                table: "Admins",
                column: "RoleAdminRoleId",
                principalTable: "RoleAdmins",
                principalColumn: "RoleId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
