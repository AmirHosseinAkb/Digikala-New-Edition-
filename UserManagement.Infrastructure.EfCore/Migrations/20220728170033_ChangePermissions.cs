using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UserManagement.Infrastructure.EfCore.Migrations
{
    public partial class ChangePermissions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Permissions_Permissions_ParentCode",
                table: "Permissions");

            migrationBuilder.DropIndex(
                name: "IX_Permissions_ParentCode",
                table: "Permissions");

            migrationBuilder.AlterColumn<int>(
                name: "ParentCode",
                table: "Permissions",
                type: "int",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "ParentCode",
                table: "Permissions",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

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
    }
}
