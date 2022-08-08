using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DIcrud.Migrations
{
    public partial class aftereditPostTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CreateBy",
                table: "Post",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDate",
                table: "Post",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "UpdateBy",
                table: "Post",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateDate",
                table: "Post",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreateBy",
                table: "Post");

            migrationBuilder.DropColumn(
                name: "CreateDate",
                table: "Post");

            migrationBuilder.DropColumn(
                name: "UpdateBy",
                table: "Post");

            migrationBuilder.DropColumn(
                name: "UpdateDate",
                table: "Post");
        }
    }
}
