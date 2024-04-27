using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MajornaGameStore.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class Fifth : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Products_DiscountID",
                table: "Products",
                column: "DiscountID");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProductTypeID",
                table: "Products",
                column: "ProductTypeID");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Discounts_DiscountID",
                table: "Products",
                column: "DiscountID",
                principalTable: "Discounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_ProductTypes_ProductTypeID",
                table: "Products",
                column: "ProductTypeID",
                principalTable: "ProductTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Discounts_DiscountID",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_ProductTypes_ProductTypeID",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_DiscountID",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_ProductTypeID",
                table: "Products");
        }
    }
}
