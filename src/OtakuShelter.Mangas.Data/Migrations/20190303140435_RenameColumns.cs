using Microsoft.EntityFrameworkCore.Migrations;

namespace OtakuShelter.Mangas.Migrations
{
	public partial class RenameColumns : Migration
	{
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropForeignKey(
				"FK_author_mangaauthors",
				"mangaauthors");

			migrationBuilder.DropForeignKey(
				"FK_manga_mangaauthors",
				"mangaauthors");

			migrationBuilder.DropForeignKey(
				"FK_manga_mangatags",
				"mangatags");

			migrationBuilder.DropForeignKey(
				"FK_tag_mangatags",
				"mangatags");

			migrationBuilder.DropForeignKey(
				"FK_manga_mangatranslators",
				"mangatranslators");

			migrationBuilder.DropForeignKey(
				"FK_translator_mangatranslators",
				"mangatranslators");

			migrationBuilder.DropPrimaryKey(
				"PK_mangatranslators",
				"mangatranslators");

			migrationBuilder.DropPrimaryKey(
				"PK_mangatags",
				"mangatags");

			migrationBuilder.DropPrimaryKey(
				"PK_mangaauthors",
				"mangaauthors");

			migrationBuilder.RenameTable(
				"mangatranslators",
				newName: "manga_translators");

			migrationBuilder.RenameTable(
				"mangatags",
				newName: "manga_tags");

			migrationBuilder.RenameTable(
				"mangaauthors",
				newName: "manga_authors");

			migrationBuilder.RenameColumn(
				"translatorid",
				"manga_translators",
				"translator_id");

			migrationBuilder.RenameColumn(
				"mangaid",
				"manga_translators",
				"manga_id");

			migrationBuilder.RenameIndex(
				"IX_mangatranslators_translatorid",
				table: "manga_translators",
				newName: "IX_manga_translators_translator_id");

			migrationBuilder.RenameIndex(
				"IX_mangatags_manga_id",
				table: "manga_tags",
				newName: "IX_manga_tags_manga_id");

			migrationBuilder.RenameIndex(
				"IX_mangaauthors_author_id",
				table: "manga_authors",
				newName: "IX_manga_authors_author_id");

			migrationBuilder.AddPrimaryKey(
				"PK_manga_translators",
				"manga_translators",
				new[] {"manga_id", "translator_id"});

			migrationBuilder.AddPrimaryKey(
				"PK_manga_tags",
				"manga_tags",
				new[] {"tag_id", "manga_id"});

			migrationBuilder.AddPrimaryKey(
				"PK_manga_authors",
				"manga_authors",
				new[] {"manga_id", "author_id"});

			migrationBuilder.AddForeignKey(
				"FK_author_manga_authors",
				"manga_authors",
				"author_id",
				"authors",
				principalColumn: "id",
				onDelete: ReferentialAction.Restrict);

			migrationBuilder.AddForeignKey(
				"FK_manga_manga_authors",
				"manga_authors",
				"manga_id",
				"mangas",
				principalColumn: "id",
				onDelete: ReferentialAction.Restrict);

			migrationBuilder.AddForeignKey(
				"FK_manga_manga_tags",
				"manga_tags",
				"manga_id",
				"mangas",
				principalColumn: "id",
				onDelete: ReferentialAction.Restrict);

			migrationBuilder.AddForeignKey(
				"FK_tag_manga_tags",
				"manga_tags",
				"tag_id",
				"tags",
				principalColumn: "id",
				onDelete: ReferentialAction.Restrict);

			migrationBuilder.AddForeignKey(
				"FK_manga_manga_translators",
				"manga_translators",
				"manga_id",
				"mangas",
				principalColumn: "id",
				onDelete: ReferentialAction.Restrict);

			migrationBuilder.AddForeignKey(
				"FK_translator_manga_translators",
				"manga_translators",
				"translator_id",
				"translators",
				principalColumn: "id",
				onDelete: ReferentialAction.Restrict);
		}

		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropForeignKey(
				"FK_author_manga_authors",
				"manga_authors");

			migrationBuilder.DropForeignKey(
				"FK_manga_manga_authors",
				"manga_authors");

			migrationBuilder.DropForeignKey(
				"FK_manga_manga_tags",
				"manga_tags");

			migrationBuilder.DropForeignKey(
				"FK_tag_manga_tags",
				"manga_tags");

			migrationBuilder.DropForeignKey(
				"FK_manga_manga_translators",
				"manga_translators");

			migrationBuilder.DropForeignKey(
				"FK_translator_manga_translators",
				"manga_translators");

			migrationBuilder.DropPrimaryKey(
				"PK_manga_translators",
				"manga_translators");

			migrationBuilder.DropPrimaryKey(
				"PK_manga_tags",
				"manga_tags");

			migrationBuilder.DropPrimaryKey(
				"PK_manga_authors",
				"manga_authors");

			migrationBuilder.RenameTable(
				"manga_translators",
				newName: "mangatranslators");

			migrationBuilder.RenameTable(
				"manga_tags",
				newName: "mangatags");

			migrationBuilder.RenameTable(
				"manga_authors",
				newName: "mangaauthors");

			migrationBuilder.RenameColumn(
				"translator_id",
				"mangatranslators",
				"translatorid");

			migrationBuilder.RenameColumn(
				"manga_id",
				"mangatranslators",
				"mangaid");

			migrationBuilder.RenameIndex(
				"IX_manga_translators_translator_id",
				table: "mangatranslators",
				newName: "IX_mangatranslators_translatorid");

			migrationBuilder.RenameIndex(
				"IX_manga_tags_manga_id",
				table: "mangatags",
				newName: "IX_mangatags_manga_id");

			migrationBuilder.RenameIndex(
				"IX_manga_authors_author_id",
				table: "mangaauthors",
				newName: "IX_mangaauthors_author_id");

			migrationBuilder.AddPrimaryKey(
				"PK_mangatranslators",
				"mangatranslators",
				new[] {"mangaid", "translatorid"});

			migrationBuilder.AddPrimaryKey(
				"PK_mangatags",
				"mangatags",
				new[] {"tag_id", "manga_id"});

			migrationBuilder.AddPrimaryKey(
				"PK_mangaauthors",
				"mangaauthors",
				new[] {"manga_id", "author_id"});

			migrationBuilder.AddForeignKey(
				"FK_author_mangaauthors",
				"mangaauthors",
				"author_id",
				"authors",
				principalColumn: "id",
				onDelete: ReferentialAction.Restrict);

			migrationBuilder.AddForeignKey(
				"FK_manga_mangaauthors",
				"mangaauthors",
				"manga_id",
				"mangas",
				principalColumn: "id",
				onDelete: ReferentialAction.Restrict);

			migrationBuilder.AddForeignKey(
				"FK_manga_mangatags",
				"mangatags",
				"manga_id",
				"mangas",
				principalColumn: "id",
				onDelete: ReferentialAction.Restrict);

			migrationBuilder.AddForeignKey(
				"FK_tag_mangatags",
				"mangatags",
				"tag_id",
				"tags",
				principalColumn: "id",
				onDelete: ReferentialAction.Restrict);

			migrationBuilder.AddForeignKey(
				"FK_manga_mangatranslators",
				"mangatranslators",
				"mangaid",
				"mangas",
				principalColumn: "id",
				onDelete: ReferentialAction.Restrict);

			migrationBuilder.AddForeignKey(
				"FK_translator_mangatranslators",
				"mangatranslators",
				"translatorid",
				"translators",
				principalColumn: "id",
				onDelete: ReferentialAction.Restrict);
		}
	}
}