using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace food_delivery_management.Migrations
{
    /// <inheritdoc />
    public partial class updatemigrations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MenuItems_Resturants_ResturantId",
                table: "MenuItems");

            migrationBuilder.DropIndex(
                name: "IX_MenuItems_ResturantId",
                table: "MenuItems");

            migrationBuilder.DropColumn(
                name: "ResturantId",
                table: "MenuItems");

            migrationBuilder.AddColumn<decimal>(
                name: "revenue",
                table: "Resturants",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "totalOrders",
                table: "Resturants",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "revenue",
                table: "Resturants");

            migrationBuilder.DropColumn(
                name: "totalOrders",
                table: "Resturants");

            migrationBuilder.AddColumn<Guid>(
                name: "ResturantId",
                table: "MenuItems",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_MenuItems_ResturantId",
                table: "MenuItems",
                column: "ResturantId");

            migrationBuilder.AddForeignKey(
                name: "FK_MenuItems_Resturants_ResturantId",
                table: "MenuItems",
                column: "ResturantId",
                principalTable: "Resturants",
                principalColumn: "Id");
        }
    }
}
