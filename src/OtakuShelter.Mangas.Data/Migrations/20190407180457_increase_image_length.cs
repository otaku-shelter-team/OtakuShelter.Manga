using Microsoft.EntityFrameworkCore.Migrations;

namespace OtakuShelter.Mangas.Migrations
{
	public partial class increase_image_length : Migration
	{
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.AlterColumn<string>(
				"image",
				"mangas",
				maxLength: 300,
				nullable: false,
				oldClrType: typeof(string),
				oldMaxLength: 100);

			migrationBuilder.CreateIndex(
				"ux_types_name",
				"types",
				"name",
				unique: true);

			migrationBuilder.CreateIndex(
				"ux_translators_name",
				"translators",
				"name",
				unique: true);

			migrationBuilder.CreateIndex(
				"ux_tags_name",
				"tags",
				"name",
				unique: true);

			migrationBuilder.CreateIndex(
				"ux_authors_name",
				"authors",
				"name",
				unique: true);
		}

		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropIndex(
				"ux_types_name",
				"types");

			migrationBuilder.DropIndex(
				"ux_translators_name",
				"translators");

			migrationBuilder.DropIndex(
				"ux_tags_name",
				"tags");

			migrationBuilder.DropIndex(
				"ux_authors_name",
				"authors");

			migrationBuilder.AlterColumn<string>(
				"image",
				"mangas",
				maxLength: 100,
				nullable: false,
				oldClrType: typeof(string),
				oldMaxLength: 300);
		}
	}
}