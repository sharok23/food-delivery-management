using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace food_delivery_management.Migrations
{
    /// <inheritdoc />
    public partial class Addedmodels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CustomerAddress",
                table: "Orders",
                newName: "DeliveryAddress");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DeliveryAddress",
                table: "Orders",
                newName: "CustomerAddress");
        }
    }
}
