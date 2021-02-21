using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MakeJobWell.DAL.Migrations
{
    public partial class v3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2021, 2, 21, 14, 32, 39, 473, DateTimeKind.Local).AddTicks(2554));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2021, 2, 13, 17, 46, 19, 427, DateTimeKind.Local).AddTicks(111));
        }
    }
}
