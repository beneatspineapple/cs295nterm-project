using Microsoft.EntityFrameworkCore.Migrations;

namespace BenWilson295nTermProject.Migrations
{
    public partial class hellomigrations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BoardID",
                table: "ForumPosts",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Boards",
                columns: table => new
                {
                    BoardID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BoardSubject = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Boards", x => x.BoardID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ForumPosts_BoardID",
                table: "ForumPosts",
                column: "BoardID");

            migrationBuilder.AddForeignKey(
                name: "FK_ForumPosts_Boards_BoardID",
                table: "ForumPosts",
                column: "BoardID",
                principalTable: "Boards",
                principalColumn: "BoardID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ForumPosts_Boards_BoardID",
                table: "ForumPosts");

            migrationBuilder.DropTable(
                name: "Boards");

            migrationBuilder.DropIndex(
                name: "IX_ForumPosts_BoardID",
                table: "ForumPosts");

            migrationBuilder.DropColumn(
                name: "BoardID",
                table: "ForumPosts");
        }
    }
}
