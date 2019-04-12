using Microsoft.EntityFrameworkCore.Migrations;

namespace OtakuShelter.Mangas.Migrations
{
	public partial class IncreateName : Migration
	{
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.AlterColumn<string>(
				"name",
				"types",
				maxLength: 100,
				nullable: false,
				oldClrType: typeof(string),
				oldMaxLength: 50);

			migrationBuilder.AlterColumn<string>(
				"name",
				"translators",
				maxLength: 100,
				nullable: false,
				oldClrType: typeof(string),
				oldMaxLength: 50);

			migrationBuilder.AlterColumn<string>(
				"name",
				"tags",
				maxLength: 100,
				nullable: false,
				oldClrType: typeof(string),
				oldMaxLength: 50);

			migrationBuilder.AlterColumn<string>(
				"name",
				"authors",
				maxLength: 100,
				nullable: false,
				oldClrType: typeof(string),
				oldMaxLength: 50);
		}

		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.AlterColumn<string>(
				"name",
				"types",
				maxLength: 50,
				nullable: false,
				oldClrType: typeof(string),
				oldMaxLength: 100);

			migrationBuilder.AlterColumn<string>(
				"name",
				"translators",
				maxLength: 50,
				nullable: false,
				oldClrType: typeof(string),
				oldMaxLength: 100);

			migrationBuilder.AlterColumn<string>(
				"name",
				"tags",
				maxLength: 50,
				nullable: false,
				oldClrType: typeof(string),
				oldMaxLength: 100);

			migrationBuilder.AlterColumn<string>(
				"name",
				"authors",
				maxLength: 50,
				nullable: false,
				oldClrType: typeof(string),
				oldMaxLength: 100);
		}
	}
}