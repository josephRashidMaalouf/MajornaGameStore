using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MajornaGameStore.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedTablesRelatedToProduct : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Developer_Products_ProductId",
                table: "Developer");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Discounts_DiscountID",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_ProductTypes_ProductTypeID",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Publisher_Products_ProductId",
                table: "Publisher");

            migrationBuilder.DropForeignKey(
                name: "FK_Screenshot_Products_ProductId",
                table: "Screenshot");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Screenshot",
                table: "Screenshot");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Publisher",
                table: "Publisher");

            migrationBuilder.DropIndex(
                name: "IX_Publisher_ProductId",
                table: "Publisher");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Developer",
                table: "Developer");

            migrationBuilder.DropIndex(
                name: "IX_Developer_ProductId",
                table: "Developer");

            migrationBuilder.DropColumn(
                name: "MacRequirements",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "Publisher");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "Developer");

            migrationBuilder.RenameTable(
                name: "Screenshot",
                newName: "Screenshots");

            migrationBuilder.RenameTable(
                name: "Publisher",
                newName: "Publishers");

            migrationBuilder.RenameTable(
                name: "Developer",
                newName: "Developers");

            migrationBuilder.RenameColumn(
                name: "ProductTypeID",
                table: "Products",
                newName: "ProductTypeId");

            migrationBuilder.RenameColumn(
                name: "DiscountID",
                table: "Products",
                newName: "DiscountId");

            migrationBuilder.RenameIndex(
                name: "IX_Products_ProductTypeID",
                table: "Products",
                newName: "IX_Products_ProductTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_Products_DiscountID",
                table: "Products",
                newName: "IX_Products_DiscountId");

            migrationBuilder.RenameIndex(
                name: "IX_Screenshot_ProductId",
                table: "Screenshots",
                newName: "IX_Screenshots_ProductId");

            migrationBuilder.AlterColumn<int>(
                name: "ProductId",
                table: "Screenshots",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Screenshots",
                table: "Screenshots",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Publishers",
                table: "Publishers",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Developers",
                table: "Developers",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "DeveloperProduct",
                columns: table => new
                {
                    DevelopersId = table.Column<int>(type: "int", nullable: false),
                    ProductsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeveloperProduct", x => new { x.DevelopersId, x.ProductsId });
                    table.ForeignKey(
                        name: "FK_DeveloperProduct_Developers_DevelopersId",
                        column: x => x.DevelopersId,
                        principalTable: "Developers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DeveloperProduct_Products_ProductsId",
                        column: x => x.ProductsId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductPublisher",
                columns: table => new
                {
                    ProductsId = table.Column<int>(type: "int", nullable: false),
                    PublishersId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductPublisher", x => new { x.ProductsId, x.PublishersId });
                    table.ForeignKey(
                        name: "FK_ProductPublisher_Products_ProductsId",
                        column: x => x.ProductsId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductPublisher_Publishers_PublishersId",
                        column: x => x.PublishersId,
                        principalTable: "Publishers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DeveloperProduct_ProductsId",
                table: "DeveloperProduct",
                column: "ProductsId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductPublisher_PublishersId",
                table: "ProductPublisher",
                column: "PublishersId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Discounts_DiscountId",
                table: "Products",
                column: "DiscountId",
                principalTable: "Discounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_ProductTypes_ProductTypeId",
                table: "Products",
                column: "ProductTypeId",
                principalTable: "ProductTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Screenshots_Products_ProductId",
                table: "Screenshots",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Discounts_DiscountId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_ProductTypes_ProductTypeId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Screenshots_Products_ProductId",
                table: "Screenshots");

            migrationBuilder.DropTable(
                name: "DeveloperProduct");

            migrationBuilder.DropTable(
                name: "ProductPublisher");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Screenshots",
                table: "Screenshots");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Publishers",
                table: "Publishers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Developers",
                table: "Developers");

            migrationBuilder.RenameTable(
                name: "Screenshots",
                newName: "Screenshot");

            migrationBuilder.RenameTable(
                name: "Publishers",
                newName: "Publisher");

            migrationBuilder.RenameTable(
                name: "Developers",
                newName: "Developer");

            migrationBuilder.RenameColumn(
                name: "ProductTypeId",
                table: "Products",
                newName: "ProductTypeID");

            migrationBuilder.RenameColumn(
                name: "DiscountId",
                table: "Products",
                newName: "DiscountID");

            migrationBuilder.RenameIndex(
                name: "IX_Products_ProductTypeId",
                table: "Products",
                newName: "IX_Products_ProductTypeID");

            migrationBuilder.RenameIndex(
                name: "IX_Products_DiscountId",
                table: "Products",
                newName: "IX_Products_DiscountID");

            migrationBuilder.RenameIndex(
                name: "IX_Screenshots_ProductId",
                table: "Screenshot",
                newName: "IX_Screenshot_ProductId");

            migrationBuilder.AddColumn<string>(
                name: "MacRequirements",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<int>(
                name: "ProductId",
                table: "Screenshot",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "Publisher",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "Developer",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Screenshot",
                table: "Screenshot",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Publisher",
                table: "Publisher",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Developer",
                table: "Developer",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Publisher_ProductId",
                table: "Publisher",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Developer_ProductId",
                table: "Developer",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_Developer_Products_ProductId",
                table: "Developer",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Publisher_Products_ProductId",
                table: "Publisher",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Screenshot_Products_ProductId",
                table: "Screenshot",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id");
        }
    }
}
