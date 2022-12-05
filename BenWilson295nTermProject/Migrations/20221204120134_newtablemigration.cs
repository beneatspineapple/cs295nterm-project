using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BenWilson295nTermProject.Migrations
{
    public partial class newtablemigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Items",
                table: "Items");

            migrationBuilder.RenameTable(
                name: "Items",
                newName: "Rides");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateSubmitted",
                table: "Rides",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Rides",
                table: "Rides",
                column: "RideId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Rides",
                table: "Rides");

            migrationBuilder.DropColumn(
                name: "DateSubmitted",
                table: "Rides");

            migrationBuilder.RenameTable(
                name: "Rides",
                newName: "Items");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Items",
                table: "Items",
                column: "RideId");
        }
    }
}
