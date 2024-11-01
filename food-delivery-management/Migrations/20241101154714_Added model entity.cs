using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace food_delivery_management.Migrations
{
    /// <inheritdoc />
    public partial class Addedmodelentity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ResturantId",
                table: "Orders",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ResturantId",
                table: "Orders",
                column: "ResturantId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Resturants_ResturantId",
                table: "Orders",
                column: "ResturantId",
                principalTable: "Resturants",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Resturants_ResturantId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_ResturantId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "ResturantId",
                table: "Orders");
        }
    }
}
