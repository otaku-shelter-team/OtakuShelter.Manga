using Microsoft.EntityFrameworkCore.Migrations;

namespace OtakuShelter.Mangas.Migrations
{
	public partial class FixPageImage : Migration
	{
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.AlterColumn<string>(
				"image",
				"pages",
				maxLength: 300,
				nullable: false,
				oldClrType: typeof(string),
				oldMaxLength: 50);
		}

		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.AlterColumn<string>(
				"image",
				"pages",
				maxLength: 50,
				nullable: false,
				oldClrType: typeof(string),
				oldMaxLength: 300);
		}
	}
}