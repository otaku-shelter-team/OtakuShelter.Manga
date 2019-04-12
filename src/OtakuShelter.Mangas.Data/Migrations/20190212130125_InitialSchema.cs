using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace OtakuShelter.Mangas.Migrations
{
	public partial class InitialSchema : Migration
	{
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.CreateTable(
				"authors",
				table => new
				{
					id = table.Column<int>()
						.Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
					name = table.Column<string>(maxLength: 50)
				},
				constraints: table => { table.PrimaryKey("PK_authors", x => x.id); });

			migrationBuilder.CreateTable(
				"tags",
				table => new
				{
					id = table.Column<int>()
						.Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
					name = table.Column<string>(maxLength: 50)
				},
				constraints: table => { table.PrimaryKey("PK_tags", x => x.id); });

			migrationBuilder.CreateTable(
				"translators",
				table => new
				{
					id = table.Column<int>()
						.Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
					name = table.Column<string>(maxLength: 50)
				},
				constraints: table => { table.PrimaryKey("PK_translators", x => x.id); });

			migrationBuilder.CreateTable(
				"types",
				table => new
				{
					id = table.Column<int>()
						.Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
					name = table.Column<string>(maxLength: 50)
				},
				constraints: table => { table.PrimaryKey("PK_types", x => x.id); });

			migrationBuilder.CreateTable(
				"mangas",
				table => new
				{
					id = table.Column<int>()
						.Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
					title = table.Column<string>(maxLength: 50),
					description = table.Column<string>(maxLength: 500),
					image = table.Column<string>(maxLength: 100),
					typeid = table.Column<int>()
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_mangas", x => x.id);
					table.ForeignKey(
						"FK_type_mangas",
						x => x.typeid,
						"types",
						"id",
						onDelete: ReferentialAction.Restrict);
				});

			migrationBuilder.CreateTable(
				"chapters",
				table => new
				{
					id = table.Column<int>()
						.Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
					title = table.Column<string>(maxLength: 50),
					uploaddate = table.Column<DateTime>("date"),
					mangaid = table.Column<int>()
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_chapters", x => x.id);
					table.ForeignKey(
						"FK_manga_chapters",
						x => x.mangaid,
						"mangas",
						"id",
						onDelete: ReferentialAction.Restrict);
				});

			migrationBuilder.CreateTable(
				"mangaauthors",
				table => new
				{
					mangaid = table.Column<int>(),
					authorid = table.Column<int>()
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_mangaauthors", x => new {x.mangaid, x.authorid});
					table.ForeignKey(
						"FK_author_mangaauthors",
						x => x.authorid,
						"authors",
						"id",
						onDelete: ReferentialAction.Restrict);
					table.ForeignKey(
						"FK_manga_mangaauthors",
						x => x.mangaid,
						"mangas",
						"id",
						onDelete: ReferentialAction.Restrict);
				});

			migrationBuilder.CreateTable(
				"mangatags",
				table => new
				{
					mangaid = table.Column<int>(),
					tagid = table.Column<int>()
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_mangatags", x => new {x.tagid, x.mangaid});
					table.ForeignKey(
						"FK_manga_mangatags",
						x => x.mangaid,
						"mangas",
						"id",
						onDelete: ReferentialAction.Restrict);
					table.ForeignKey(
						"FK_tag_mangatags",
						x => x.tagid,
						"tags",
						"id",
						onDelete: ReferentialAction.Restrict);
				});

			migrationBuilder.CreateTable(
				"mangatranslators",
				table => new
				{
					mangaid = table.Column<int>(),
					translatorid = table.Column<int>()
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_mangatranslators", x => new {x.mangaid, x.translatorid});
					table.ForeignKey(
						"FK_manga_mangatranslators",
						x => x.mangaid,
						"mangas",
						"id",
						onDelete: ReferentialAction.Restrict);
					table.ForeignKey(
						"FK_translator_mangatranslators",
						x => x.translatorid,
						"translators",
						"id",
						onDelete: ReferentialAction.Restrict);
				});

			migrationBuilder.CreateTable(
				"pages",
				table => new
				{
					id = table.Column<int>()
						.Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
					image = table.Column<string>(maxLength: 50),
					chapterid = table.Column<int>()
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_pages", x => x.id);
					table.ForeignKey(
						"FK_chapter_pages",
						x => x.chapterid,
						"chapters",
						"id",
						onDelete: ReferentialAction.Restrict);
				});

			migrationBuilder.CreateIndex(
				"IX_chapters_mangaid",
				"chapters",
				"mangaid");

			migrationBuilder.CreateIndex(
				"IX_mangaauthors_authorid",
				"mangaauthors",
				"authorid");

			migrationBuilder.CreateIndex(
				"IX_mangas_typeid",
				"mangas",
				"typeid");

			migrationBuilder.CreateIndex(
				"IX_mangatags_mangaid",
				"mangatags",
				"mangaid");

			migrationBuilder.CreateIndex(
				"IX_mangatranslators_translatorid",
				"mangatranslators",
				"translatorid");

			migrationBuilder.CreateIndex(
				"IX_pages_chapterid",
				"pages",
				"chapterid");
		}

		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropTable(
				"mangaauthors");

			migrationBuilder.DropTable(
				"mangatags");

			migrationBuilder.DropTable(
				"mangatranslators");

			migrationBuilder.DropTable(
				"pages");

			migrationBuilder.DropTable(
				"authors");

			migrationBuilder.DropTable(
				"tags");

			migrationBuilder.DropTable(
				"translators");

			migrationBuilder.DropTable(
				"chapters");

			migrationBuilder.DropTable(
				"mangas");

			migrationBuilder.DropTable(
				"types");
		}
	}
}