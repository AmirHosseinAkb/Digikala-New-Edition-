using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UserManagement.Infrastructure.EfCore.Migrations
{
    public partial class RemoveTypeCode : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TypeCode",
                table: "TransactionTypes");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TypeCode",
                table: "TransactionTypes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "TransactionTypes",
                keyColumn: "TypeId",
                keyValue: 1L,
                column: "TypeCode",
                value: 1);

            migrationBuilder.UpdateData(
                table: "TransactionTypes",
                keyColumn: "TypeId",
                keyValue: 2L,
                column: "TypeCode",
                value: 2);
        }
    }
}
