using Microsoft.EntityFrameworkCore.Migrations;

namespace ProductServer.Migrations
{
    public partial class V5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Auth",
                table: "Auth");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Auth",
                table: "Auth",
                column: "RefreshToken");

            migrationBuilder.CreateIndex(
                name: "IX_Auth_UserID",
                table: "Auth",
                column: "UserID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Auth",
                table: "Auth");

            migrationBuilder.DropIndex(
                name: "IX_Auth_UserID",
                table: "Auth");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Auth",
                table: "Auth",
                columns: new[] { "UserID", "RefreshToken" });
        }
    }
}
