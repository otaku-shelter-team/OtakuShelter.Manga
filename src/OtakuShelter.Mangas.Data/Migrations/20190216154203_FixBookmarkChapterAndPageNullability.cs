using Microsoft.EntityFrameworkCore.Migrations;

namespace OtakuShelter.Mangas.Migrations
{
	public partial class FixBookmarkChapterAndPageNullability : Migration
	{
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.AlterColumn<int>(
				"pageid",
				"bookmarks",
				nullable: true,
				oldClrType: typeof(int));

			migrationBuilder.AlterColumn<int>(
				"chapterid",
				"bookmarks",
				nullable: true,
				oldClrType: typeof(int));
		}

		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.AlterColumn<int>(
				"pageid",
				"bookmarks",
				nullable: false,
				oldClrType: typeof(int),
				oldNullable: true);

			migrationBuilder.AlterColumn<int>(
				"chapterid",
				"bookmarks",
				nullable: false,
				oldClrType: typeof(int),
				oldNullable: true);
		}
	}
}