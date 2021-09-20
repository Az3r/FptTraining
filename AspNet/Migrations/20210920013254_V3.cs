using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProductServer.Migrations
{
    public partial class V3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductDetails_Products_ProductID",
                table: "ProductDetails");

            migrationBuilder.DropColumn(
                name: "ProductDetailID",
                table: "Products");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_ProductDetails_ID",
                table: "Products",
                column: "ID",
                principalTable: "ProductDetails",
                principalColumn: "ProductID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_ProductDetails_ID",
                table: "Products");

            migrationBuilder.AddColumn<Guid>(
                name: "ProductDetailID",
                table: "Products",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddForeignKey(
                name: "FK_ProductDetails_Products_ProductID",
                table: "ProductDetails",
                column: "ProductID",
                principalTable: "Products",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
