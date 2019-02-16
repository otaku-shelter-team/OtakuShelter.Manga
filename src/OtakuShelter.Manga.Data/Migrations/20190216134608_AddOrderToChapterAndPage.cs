using Microsoft.EntityFrameworkCore.Migrations;

namespace OtakuShelter.Manga.Migrations
{
    public partial class AddOrderToChapterAndPage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_pages_chapterid",
                table: "pages");

            migrationBuilder.DropIndex(
                name: "IX_chapters_mangaid",
                table: "chapters");

            migrationBuilder.AddColumn<int>(
                name: "order",
                table: "pages",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "order",
                table: "chapters",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "UQ_chapterid_order",
                table: "pages",
                columns: new[] { "chapterid", "order" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UQ_mangaid_order",
                table: "chapters",
                columns: new[] { "mangaid", "order" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "UQ_chapterid_order",
                table: "pages");

            migrationBuilder.DropIndex(
                name: "UQ_mangaid_order",
                table: "chapters");

            migrationBuilder.DropColumn(
                name: "order",
                table: "pages");

            migrationBuilder.DropColumn(
                name: "order",
                table: "chapters");

            migrationBuilder.CreateIndex(
                name: "IX_pages_chapterid",
                table: "pages",
                column: "chapterid");

            migrationBuilder.CreateIndex(
                name: "IX_chapters_mangaid",
                table: "chapters",
                column: "mangaid");
        }
    }
}
