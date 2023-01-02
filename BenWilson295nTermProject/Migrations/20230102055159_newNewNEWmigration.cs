using Microsoft.EntityFrameworkCore.Migrations;

namespace BenWilson295nTermProject.Migrations
{
    public partial class newNewNEWmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BoardProperty",
                table: "ForumPosts",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BoardProperty",
                table: "ForumPosts");
        }
    }
}
