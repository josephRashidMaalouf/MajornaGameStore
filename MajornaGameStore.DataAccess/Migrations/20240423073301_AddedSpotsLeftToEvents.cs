using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MajornaGameStore.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddedSpotsLeftToEvents : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SpotsLeft",
                table: "Events",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SpotsLeft",
                table: "Events");
        }
    }
}
