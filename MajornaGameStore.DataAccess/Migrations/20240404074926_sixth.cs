using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MajornaGameStore.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class sixth : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductTag_Products_TagsId",
                table: "ProductTag");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductTag_Tags_TagsId1",
                table: "ProductTag");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductTag",
                table: "ProductTag");

            migrationBuilder.DropIndex(
                name: "IX_ProductTag_TagsId1",
                table: "ProductTag");

            migrationBuilder.RenameColumn(
                name: "TagsId1",
                table: "ProductTag",
                newName: "ProductsId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductTag",
                table: "ProductTag",
                columns: new[] { "ProductsId", "TagsId" });

            migrationBuilder.CreateIndex(
                name: "IX_ProductTag_TagsId",
                table: "ProductTag",
                column: "TagsId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductTag_Products_ProductsId",
                table: "ProductTag",
                column: "ProductsId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductTag_Tags_TagsId",
                table: "ProductTag",
                column: "TagsId",
                principalTable: "Tags",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductTag_Products_ProductsId",
                table: "ProductTag");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductTag_Tags_TagsId",
                table: "ProductTag");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductTag",
                table: "ProductTag");

            migrationBuilder.DropIndex(
                name: "IX_ProductTag_TagsId",
                table: "ProductTag");

            migrationBuilder.RenameColumn(
                name: "ProductsId",
                table: "ProductTag",
                newName: "TagsId1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductTag",
                table: "ProductTag",
                columns: new[] { "TagsId", "TagsId1" });

            migrationBuilder.CreateIndex(
                name: "IX_ProductTag_TagsId1",
                table: "ProductTag",
                column: "TagsId1");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductTag_Products_TagsId",
                table: "ProductTag",
                column: "TagsId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductTag_Tags_TagsId1",
                table: "ProductTag",
                column: "TagsId1",
                principalTable: "Tags",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
