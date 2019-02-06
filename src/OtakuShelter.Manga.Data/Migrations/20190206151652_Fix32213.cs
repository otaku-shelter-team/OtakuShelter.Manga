using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace OtakuShelter.Manga.Migrations
{
    public partial class Fix32213 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_manga_tags",
                table: "manga_tags");

            migrationBuilder.RenameTable(
                name: "manga_tags",
                newName: "mangatags");

            migrationBuilder.RenameColumn(
                name: "chapter_id",
                table: "pages",
                newName: "chapterid");

            migrationBuilder.RenameColumn(
                name: "page_url",
                table: "pages",
                newName: "image");

            migrationBuilder.RenameIndex(
                name: "IX_pages_chapter_id",
                table: "pages",
                newName: "IX_pages_chapterid");

            migrationBuilder.RenameColumn(
                name: "type_id",
                table: "mangas",
                newName: "typeid");

            migrationBuilder.RenameIndex(
                name: "IX_mangas_type_id",
                table: "mangas",
                newName: "IX_mangas_typeid");

            migrationBuilder.RenameColumn(
                name: "upload_date",
                table: "chapters",
                newName: "uploaddate");

            migrationBuilder.RenameColumn(
                name: "manga_id",
                table: "chapters",
                newName: "mangaid");

            migrationBuilder.RenameIndex(
                name: "IX_chapters_manga_id",
                table: "chapters",
                newName: "IX_chapters_mangaid");

            migrationBuilder.RenameColumn(
                name: "manga_id",
                table: "mangatags",
                newName: "mangaid");

            migrationBuilder.RenameColumn(
                name: "tag_id",
                table: "mangatags",
                newName: "tagid");

            migrationBuilder.RenameIndex(
                name: "IX_manga_tags_manga_id",
                table: "mangatags",
                newName: "IX_mangatags_mangaid");

            migrationBuilder.AddColumn<string>(
                name: "image",
                table: "mangas",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_mangatags",
                table: "mangatags",
                columns: new[] { "tagid", "mangaid" });

            migrationBuilder.CreateTable(
                name: "authors",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_authors", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "translators",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_translators", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "mangaauthors",
                columns: table => new
                {
                    mangaid = table.Column<int>(nullable: false),
                    authorid = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mangaauthors", x => new { x.mangaid, x.authorid });
                    table.ForeignKey(
                        name: "FK_author_mangaauthors",
                        column: x => x.authorid,
                        principalTable: "authors",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_manga_mangaauthors",
                        column: x => x.mangaid,
                        principalTable: "mangas",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "mangatranslators",
                columns: table => new
                {
                    mangaid = table.Column<int>(nullable: false),
                    translatorid = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mangatranslators", x => new { x.mangaid, x.translatorid });
                    table.ForeignKey(
                        name: "FK_manga_mangatranslators",
                        column: x => x.mangaid,
                        principalTable: "mangas",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_translator_mangatranslators",
                        column: x => x.translatorid,
                        principalTable: "translators",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_mangaauthors_authorid",
                table: "mangaauthors",
                column: "authorid");

            migrationBuilder.CreateIndex(
                name: "IX_mangatranslators_translatorid",
                table: "mangatranslators",
                column: "translatorid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "mangaauthors");

            migrationBuilder.DropTable(
                name: "mangatranslators");

            migrationBuilder.DropTable(
                name: "authors");

            migrationBuilder.DropTable(
                name: "translators");

            migrationBuilder.DropPrimaryKey(
                name: "PK_mangatags",
                table: "mangatags");

            migrationBuilder.DropColumn(
                name: "image",
                table: "mangas");

            migrationBuilder.RenameTable(
                name: "mangatags",
                newName: "manga_tags");

            migrationBuilder.RenameColumn(
                name: "chapterid",
                table: "pages",
                newName: "chapter_id");

            migrationBuilder.RenameColumn(
                name: "image",
                table: "pages",
                newName: "page_url");

            migrationBuilder.RenameIndex(
                name: "IX_pages_chapterid",
                table: "pages",
                newName: "IX_pages_chapter_id");

            migrationBuilder.RenameColumn(
                name: "typeid",
                table: "mangas",
                newName: "type_id");

            migrationBuilder.RenameIndex(
                name: "IX_mangas_typeid",
                table: "mangas",
                newName: "IX_mangas_type_id");

            migrationBuilder.RenameColumn(
                name: "uploaddate",
                table: "chapters",
                newName: "upload_date");

            migrationBuilder.RenameColumn(
                name: "mangaid",
                table: "chapters",
                newName: "manga_id");

            migrationBuilder.RenameIndex(
                name: "IX_chapters_mangaid",
                table: "chapters",
                newName: "IX_chapters_manga_id");

            migrationBuilder.RenameColumn(
                name: "mangaid",
                table: "manga_tags",
                newName: "manga_id");

            migrationBuilder.RenameColumn(
                name: "tagid",
                table: "manga_tags",
                newName: "tag_id");

            migrationBuilder.RenameIndex(
                name: "IX_mangatags_mangaid",
                table: "manga_tags",
                newName: "IX_manga_tags_manga_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_manga_tags",
                table: "manga_tags",
                columns: new[] { "tag_id", "manga_id" });
        }
    }
}
