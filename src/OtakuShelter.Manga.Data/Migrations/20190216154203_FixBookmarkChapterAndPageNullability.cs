using Microsoft.EntityFrameworkCore.Migrations;

namespace OtakuShelter.Manga.Migrations
{
    public partial class FixBookmarkChapterAndPageNullability : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "pageid",
                table: "bookmarks",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "chapterid",
                table: "bookmarks",
                nullable: true,
                oldClrType: typeof(int));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "pageid",
                table: "bookmarks",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "chapterid",
                table: "bookmarks",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);
        }
    }
}
