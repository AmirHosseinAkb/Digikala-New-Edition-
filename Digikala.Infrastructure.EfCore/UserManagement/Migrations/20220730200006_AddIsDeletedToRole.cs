using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Digikala.Infrastructure.EfCore.UserManagement.Migrations
{
    public partial class AddIsDeletedToRole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Roles",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Roles");
        }
    }
}
