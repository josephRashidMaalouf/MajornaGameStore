using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MajornaGameStore.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class Second : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Review_AspNetUsers_UserId1",
                table: "Review");

            migrationBuilder.DropForeignKey(
                name: "FK_Review_Products_ProductId",
                table: "Review");

            migrationBuilder.DropForeignKey(
                name: "FK_Tags_Products_ProductId",
                table: "Tags");

            migrationBuilder.DropIndex(
                name: "IX_Tags_ProductId",
                table: "Tags");

            migrationBuilder.DropIndex(
                name: "IX_Review_UserId1",
                table: "Review");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "Tags");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "Review");

            migrationBuilder.RenameColumn(
                name: "EventType",
                table: "Events",
                newName: "EventTypeId");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Review",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ProductId",
                table: "Review",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "ProductTag",
                columns: table => new
                {
                    TagsId = table.Column<int>(type: "int", nullable: false),
                    TagsId1 = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductTag", x => new { x.TagsId, x.TagsId1 });
                    table.ForeignKey(
                        name: "FK_ProductTag_Products_TagsId",
                        column: x => x.TagsId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductTag_Tags_TagsId1",
                        column: x => x.TagsId1,
                        principalTable: "Tags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Review_UserId",
                table: "Review",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductTag_TagsId1",
                table: "ProductTag",
                column: "TagsId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Review_AspNetUsers_UserId",
                table: "Review",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Review_Products_ProductId",
                table: "Review",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Review_AspNetUsers_UserId",
                table: "Review");

            migrationBuilder.DropForeignKey(
                name: "FK_Review_Products_ProductId",
                table: "Review");

            migrationBuilder.DropTable(
                name: "ProductTag");

            migrationBuilder.DropIndex(
                name: "IX_Review_UserId",
                table: "Review");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "EventTypeId",
                table: "Events",
                newName: "EventType");

            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "Tags",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Review",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ProductId",
                table: "Review",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId1",
                table: "Review",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tags_ProductId",
                table: "Tags",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Review_UserId1",
                table: "Review",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Review_AspNetUsers_UserId1",
                table: "Review",
                column: "UserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Review_Products_ProductId",
                table: "Review",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tags_Products_ProductId",
                table: "Tags",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id");
        }
    }
}
