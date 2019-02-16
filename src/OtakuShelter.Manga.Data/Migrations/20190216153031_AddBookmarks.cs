using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace OtakuShelter.Manga.Migrations
{
    public partial class AddBookmarks : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "bookmarks",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    accountid = table.Column<int>(nullable: false),
                    name = table.Column<string>(maxLength: 100, nullable: false),
                    created = table.Column<DateTime>(nullable: false),
                    mangaid = table.Column<int>(nullable: false),
                    chapterid = table.Column<int>(nullable: false),
                    pageid = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_bookmarks", x => x.id);
                    table.ForeignKey(
                        name: "FK_chapter_bookmarks",
                        column: x => x.chapterid,
                        principalTable: "chapters",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_manga_bookmarks",
                        column: x => x.mangaid,
                        principalTable: "mangas",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_page_bookmarks",
                        column: x => x.pageid,
                        principalTable: "pages",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_bookmarks_chapterid",
                table: "bookmarks",
                column: "chapterid");

            migrationBuilder.CreateIndex(
                name: "IX_bookmarks_mangaid",
                table: "bookmarks",
                column: "mangaid");

            migrationBuilder.CreateIndex(
                name: "IX_bookmarks_pageid",
                table: "bookmarks",
                column: "pageid");

            migrationBuilder.CreateIndex(
                name: "UQ_accountid_mangaid_chapterid_pageid",
                table: "bookmarks",
                columns: new[] { "accountid", "mangaid", "chapterid", "pageid" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "bookmarks");
        }
    }
}
