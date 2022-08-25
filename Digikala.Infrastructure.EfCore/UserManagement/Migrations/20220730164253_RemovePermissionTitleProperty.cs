using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Digikala.Infrastructure.EfCore.UserManagement.Migrations
{
    public partial class RemovePermissionTitleProperty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PermissionTitle",
                table: "Permissions");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PermissionTitle",
                table: "Permissions",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "");
        }
    }
}
