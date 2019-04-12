using Microsoft.EntityFrameworkCore.Migrations;

namespace OtakuShelter.Mangas.Migrations
{
	public partial class increase_chapter_title_length : Migration
	{
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.AlterColumn<string>(
				"title",
				"chapters",
				maxLength: 100,
				nullable: false,
				oldClrType: typeof(string),
				oldMaxLength: 50);
		}

		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.AlterColumn<string>(
				"title",
				"chapters",
				maxLength: 50,
				nullable: false,
				oldClrType: typeof(string),
				oldMaxLength: 100);
		}
	}
}