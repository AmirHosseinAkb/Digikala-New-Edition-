using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Digikala.Infrastructure.EfCore.UserManagement.Migrations
{
    public partial class RemoveParentCodeFromPermission : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ParentCode",
                table: "Permissions");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ParentCode",
                table: "Permissions",
                type: "int",
                nullable: true);
        }
    }
}
