using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Digikala.Infrastructure.EfCore.ShopManagement.Migrations
{
    public partial class InitProductDetailsAndGroupDetails : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GroupDetails",
                columns: table => new
                {
                    DetailId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GroupId = table.Column<long>(type: "bigint", nullable: false),
                    DetailTitle = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupDetails", x => x.DetailId);
                    table.ForeignKey(
                        name: "FK_GroupDetails_ProductGroups_GroupId",
                        column: x => x.GroupId,
                        principalTable: "ProductGroups",
                        principalColumn: "GroupId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductDetails",
                columns: table => new
                {
                    PD_Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<long>(type: "bigint", nullable: false),
                    DetailId = table.Column<long>(type: "bigint", nullable: false),
                    DetailValue = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductDetails", x => x.PD_Id);
                    table.ForeignKey(
                        name: "FK_ProductDetails_GroupDetails_DetailId",
                        column: x => x.DetailId,
                        principalTable: "GroupDetails",
                        principalColumn: "DetailId");
                    table.ForeignKey(
                        name: "FK_ProductDetails_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_GroupDetails_GroupId",
                table: "GroupDetails",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductDetails_DetailId",
                table: "ProductDetails",
                column: "DetailId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductDetails_ProductId",
                table: "ProductDetails",
                column: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductDetails");

            migrationBuilder.DropTable(
                name: "GroupDetails");
        }
    }
}
