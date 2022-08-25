using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Digikala.Infrastructure.EfCore.UserManagement.Migrations
{
    public partial class AddParentCodeToPermission : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "ParentCode",
                table: "Permissions",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_Permissions_ParentCode",
                table: "Permissions",
                column: "ParentCode");

            migrationBuilder.AddForeignKey(
                name: "FK_Permissions_Permissions_ParentCode",
                table: "Permissions",
                column: "ParentCode",
                principalTable: "Permissions",
                principalColumn: "PermissionId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Permissions_Permissions_ParentCode",
                table: "Permissions");

            migrationBuilder.DropIndex(
                name: "IX_Permissions_ParentCode",
                table: "Permissions");

            migrationBuilder.DropColumn(
                name: "ParentCode",
                table: "Permissions");
        }
    }
}
