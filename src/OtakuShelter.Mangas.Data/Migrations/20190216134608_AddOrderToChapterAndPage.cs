using Microsoft.EntityFrameworkCore.Migrations;

namespace OtakuShelter.Mangas.Migrations
{
	public partial class AddOrderToChapterAndPage : Migration
	{
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropIndex(
				"IX_pages_chapterid",
				"pages");

			migrationBuilder.DropIndex(
				"IX_chapters_mangaid",
				"chapters");

			migrationBuilder.AddColumn<int>(
				"order",
				"pages",
				nullable: false,
				defaultValue: 0);

			migrationBuilder.AddColumn<int>(
				"order",
				"chapters",
				nullable: false,
				defaultValue: 0);

			migrationBuilder.CreateIndex(
				"UQ_chapterid_order",
				"pages",
				new[] {"chapterid", "order"},
				unique: true);

			migrationBuilder.CreateIndex(
				"UQ_mangaid_order",
				"chapters",
				new[] {"mangaid", "order"},
				unique: true);
		}

		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropIndex(
				"UQ_chapterid_order",
				"pages");

			migrationBuilder.DropIndex(
				"UQ_mangaid_order",
				"chapters");

			migrationBuilder.DropColumn(
				"order",
				"pages");

			migrationBuilder.DropColumn(
				"order",
				"chapters");

			migrationBuilder.CreateIndex(
				"IX_pages_chapterid",
				"pages",
				"chapterid");

			migrationBuilder.CreateIndex(
				"IX_chapters_mangaid",
				"chapters",
				"mangaid");
		}
	}
}