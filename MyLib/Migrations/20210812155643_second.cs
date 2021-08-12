using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MyLib.Migrations
{
    public partial class second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DueDate",
                table: "Zadacha");

            migrationBuilder.DropColumn(
                name: "DueTime",
                table: "Zadacha");

            migrationBuilder.AddColumn<DateTime>(
                name: "DueDateTime",
                table: "Zadacha",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DueDateTime",
                table: "Zadacha");

            migrationBuilder.AddColumn<DateTime>(
                name: "DueDate",
                table: "Zadacha",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DueTime",
                table: "Zadacha",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
