using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MakeJobWell.DAL.Migrations
{
    public partial class update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserID",
                table: "UserOperationClaim",
                newName: "UserId");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "UserOperationClaim",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddColumn<int>(
                name: "UserID",
                table: "UserOperationClaim",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2021, 2, 13, 23, 16, 29, 448, DateTimeKind.Local).AddTicks(5955));

            migrationBuilder.CreateIndex(
                name: "IX_UserOperationClaim_UserId",
                table: "UserOperationClaim",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserOperationClaim_User_UserId",
                table: "UserOperationClaim",
                column: "UserId",
                principalTable: "User",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserOperationClaim_User_UserId",
                table: "UserOperationClaim");

            migrationBuilder.DropIndex(
                name: "IX_UserOperationClaim_UserId",
                table: "UserOperationClaim");

            migrationBuilder.DropColumn(
                name: "UserID",
                table: "UserOperationClaim");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "UserOperationClaim",
                newName: "UserID");

            migrationBuilder.AlterColumn<int>(
                name: "UserID",
                table: "UserOperationClaim",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2021, 2, 13, 17, 46, 19, 427, DateTimeKind.Local).AddTicks(111));
        }
    }
}
