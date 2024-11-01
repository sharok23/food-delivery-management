using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace food_delivery_management.Migrations
{
    /// <inheritdoc />
    public partial class Addedentities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OrderCount",
                table: "MenuItems",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "Revenue",
                table: "MenuItems",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OrderCount",
                table: "MenuItems");

            migrationBuilder.DropColumn(
                name: "Revenue",
                table: "MenuItems");
        }
    }
}
