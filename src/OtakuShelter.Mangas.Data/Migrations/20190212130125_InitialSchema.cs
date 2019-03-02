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
                name: "tags",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tags", x => x.id);
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
                name: "types",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_types", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "mangas",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    title = table.Column<string>(maxLength: 50, nullable: false),
                    description = table.Column<string>(maxLength: 500, nullable: false),
                    image = table.Column<string>(maxLength: 100, nullable: false),
                    typeid = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mangas", x => x.id);
                    table.ForeignKey(
                        name: "FK_type_mangas",
                        column: x => x.typeid,
                        principalTable: "types",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "chapters",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    title = table.Column<string>(maxLength: 50, nullable: false),
                    uploaddate = table.Column<DateTime>(type: "date", nullable: false),
                    mangaid = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_chapters", x => x.id);
                    table.ForeignKey(
                        name: "FK_manga_chapters",
                        column: x => x.mangaid,
                        principalTable: "mangas",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
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
                name: "mangatags",
                columns: table => new
                {
                    mangaid = table.Column<int>(nullable: false),
                    tagid = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mangatags", x => new { x.tagid, x.mangaid });
                    table.ForeignKey(
                        name: "FK_manga_mangatags",
                        column: x => x.mangaid,
                        principalTable: "mangas",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tag_mangatags",
                        column: x => x.tagid,
                        principalTable: "tags",
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

            migrationBuilder.CreateTable(
                name: "pages",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    image = table.Column<string>(maxLength: 50, nullable: false),
                    chapterid = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pages", x => x.id);
                    table.ForeignKey(
                        name: "FK_chapter_pages",
                        column: x => x.chapterid,
                        principalTable: "chapters",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_chapters_mangaid",
                table: "chapters",
                column: "mangaid");

            migrationBuilder.CreateIndex(
                name: "IX_mangaauthors_authorid",
                table: "mangaauthors",
                column: "authorid");

            migrationBuilder.CreateIndex(
                name: "IX_mangas_typeid",
                table: "mangas",
                column: "typeid");

            migrationBuilder.CreateIndex(
                name: "IX_mangatags_mangaid",
                table: "mangatags",
                column: "mangaid");

            migrationBuilder.CreateIndex(
                name: "IX_mangatranslators_translatorid",
                table: "mangatranslators",
                column: "translatorid");

            migrationBuilder.CreateIndex(
                name: "IX_pages_chapterid",
                table: "pages",
                column: "chapterid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "mangaauthors");

            migrationBuilder.DropTable(
                name: "mangatags");

            migrationBuilder.DropTable(
                name: "mangatranslators");

            migrationBuilder.DropTable(
                name: "pages");

            migrationBuilder.DropTable(
                name: "authors");

            migrationBuilder.DropTable(
                name: "tags");

            migrationBuilder.DropTable(
                name: "translators");

            migrationBuilder.DropTable(
                name: "chapters");

            migrationBuilder.DropTable(
                name: "mangas");

            migrationBuilder.DropTable(
                name: "types");
        }
    }
}
