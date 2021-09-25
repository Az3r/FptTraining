using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProductServer.Migrations
{
  public partial class V6 : Migration
  {
    protected override void Up(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.RenameColumn(
          name: "RefreshToken",
          table: "Auth",
          newName: "Token");

      migrationBuilder.DropColumn(
          name: "HashedPassword",
          table: "Users"
      );
      migrationBuilder.AddColumn<byte[]>(
          name: "HashedPassword",
          table: "Users",
          type: "binary(64)",
          fixedLength: true,
          maxLength: 64,
          nullable: false);

      migrationBuilder.AddColumn<byte[]>(
          name: "Salt",
          table: "Users",
          type: "binary(32)",
          fixedLength: true,
          maxLength: 32,
          nullable: false,
          defaultValue: new byte[0]);

      migrationBuilder.AddColumn<DateTime>(
          name: "ExpirationTime",
          table: "Auth",
          type: "datetime2",
          nullable: false,
          defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.DropColumn(
          name: "Salt",
          table: "Users");

      migrationBuilder.DropColumn(
          name: "ExpirationTime",
          table: "Auth");

      migrationBuilder.RenameColumn(
          name: "Token",
          table: "Auth",
          newName: "RefreshToken");

      migrationBuilder.AlterColumn<string>(
          name: "HashedPassword",
          table: "Users",
          type: "nvarchar(60)",
          maxLength: 60,
          nullable: false,
          oldClrType: typeof(byte[]),
          oldType: "binary(64)",
          oldFixedLength: true,
          oldMaxLength: 64);
    }
  }
}
