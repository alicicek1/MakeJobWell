using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MakeJobWell.DAL.Migrations
{
    public partial class v2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "TrustCode",
                table: "Company",
                type: "numeric(2,2)",
                precision: 2,
                scale: 2,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric(1,2)",
                oldPrecision: 1,
                oldScale: 2,
                oldDefaultValueSql: "0");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2021, 1, 18, 17, 47, 48, 584, DateTimeKind.Local).AddTicks(6441));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "TrustCode",
                table: "Company",
                type: "numeric(1,2)",
                precision: 1,
                scale: 2,
                nullable: false,
                defaultValueSql: "0",
                oldClrType: typeof(decimal),
                oldType: "numeric(2,2)",
                oldPrecision: 2,
                oldScale: 2);

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2020, 12, 19, 23, 14, 47, 176, DateTimeKind.Local).AddTicks(8489));
        }
    }
}
