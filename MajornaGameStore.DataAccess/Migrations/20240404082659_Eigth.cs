using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MajornaGameStore.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class Eigth : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Developers",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ImageLink",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Languages",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "MacRequirements",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PcRequirements",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Publishers",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "ReleaseDate",
                table: "Products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateTable(
                name: "Screenshot",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Path = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Screenshot", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Screenshot_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Screenshot_ProductId",
                table: "Screenshot",
                column: "ProductId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Screenshot");

            migrationBuilder.DropColumn(
                name: "Developers",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ImageLink",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Languages",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "MacRequirements",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "PcRequirements",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Publishers",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ReleaseDate",
                table: "Products");
        }
    }
}
