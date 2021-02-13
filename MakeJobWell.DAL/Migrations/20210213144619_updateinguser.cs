using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MakeJobWell.DAL.Migrations
{
    public partial class updateinguser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PasswordHash",
                table: "User",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PasswordSalt",
                table: "User",
                type: "text",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2021, 2, 13, 17, 46, 19, 427, DateTimeKind.Local).AddTicks(111));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PasswordHash",
                table: "User");

            migrationBuilder.DropColumn(
                name: "PasswordSalt",
                table: "User");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2021, 2, 12, 22, 9, 47, 774, DateTimeKind.Local).AddTicks(7999));
        }
    }
}
