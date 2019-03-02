using Microsoft.EntityFrameworkCore.Migrations;

namespace OtakuShelter.Mangas.Migrations
{
    public partial class SnakeCase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "UQ_accountid_mangaid_chapterid_pageid",
                table: "bookmarks");

            migrationBuilder.RenameColumn(
                name: "chapterid",
                table: "pages",
                newName: "chapter_id");

            migrationBuilder.RenameIndex(
                name: "UQ_chapterid_order",
                table: "pages",
                newName: "UQ_chapter_id_order");

            migrationBuilder.RenameColumn(
                name: "mangaid",
                table: "mangatags",
                newName: "manga_id");

            migrationBuilder.RenameColumn(
                name: "tagid",
                table: "mangatags",
                newName: "tag_id");

            migrationBuilder.RenameIndex(
                name: "IX_mangatags_mangaid",
                table: "mangatags",
                newName: "IX_mangatags_manga_id");

            migrationBuilder.RenameColumn(
                name: "typeid",
                table: "mangas",
                newName: "type_id");

            migrationBuilder.RenameIndex(
                name: "IX_mangas_typeid",
                table: "mangas",
                newName: "IX_mangas_type_id");

            migrationBuilder.RenameColumn(
                name: "authorid",
                table: "mangaauthors",
                newName: "author_id");

            migrationBuilder.RenameColumn(
                name: "mangaid",
                table: "mangaauthors",
                newName: "manga_id");

            migrationBuilder.RenameIndex(
                name: "IX_mangaauthors_authorid",
                table: "mangaauthors",
                newName: "IX_mangaauthors_author_id");

            migrationBuilder.RenameColumn(
                name: "uploaddate",
                table: "chapters",
                newName: "upload_date");

            migrationBuilder.RenameColumn(
                name: "mangaid",
                table: "chapters",
                newName: "manga_id");

            migrationBuilder.RenameColumn(
                name: "pageid",
                table: "bookmarks",
                newName: "page_id");

            migrationBuilder.RenameColumn(
                name: "mangaid",
                table: "bookmarks",
                newName: "manga_id");

            migrationBuilder.RenameColumn(
                name: "chapterid",
                table: "bookmarks",
                newName: "chapter_id");

            migrationBuilder.RenameColumn(
                name: "accountid",
                table: "bookmarks",
                newName: "account_id");

            migrationBuilder.RenameIndex(
                name: "IX_bookmarks_pageid",
                table: "bookmarks",
                newName: "IX_bookmarks_page_id");

            migrationBuilder.RenameIndex(
                name: "IX_bookmarks_mangaid",
                table: "bookmarks",
                newName: "IX_bookmarks_manga_id");

            migrationBuilder.RenameIndex(
                name: "IX_bookmarks_chapterid",
                table: "bookmarks",
                newName: "IX_bookmarks_chapter_id");

            migrationBuilder.CreateIndex(
                name: "UQ_accountid_mangaid_chapterid_pageid",
                table: "bookmarks",
                columns: new[] { "account_id", "manga_id", "chapter_id", "page_id" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "UQ_accountid_mangaid_chapterid_pageid",
                table: "bookmarks");

            migrationBuilder.RenameColumn(
                name: "chapter_id",
                table: "pages",
                newName: "chapterid");

            migrationBuilder.RenameIndex(
                name: "UQ_chapter_id_order",
                table: "pages",
                newName: "UQ_chapterid_order");

            migrationBuilder.RenameColumn(
                name: "manga_id",
                table: "mangatags",
                newName: "mangaid");

            migrationBuilder.RenameColumn(
                name: "tag_id",
                table: "mangatags",
                newName: "tagid");

            migrationBuilder.RenameIndex(
                name: "IX_mangatags_manga_id",
                table: "mangatags",
                newName: "IX_mangatags_mangaid");

            migrationBuilder.RenameColumn(
                name: "type_id",
                table: "mangas",
                newName: "typeid");

            migrationBuilder.RenameIndex(
                name: "IX_mangas_type_id",
                table: "mangas",
                newName: "IX_mangas_typeid");

            migrationBuilder.RenameColumn(
                name: "author_id",
                table: "mangaauthors",
                newName: "authorid");

            migrationBuilder.RenameColumn(
                name: "manga_id",
                table: "mangaauthors",
                newName: "mangaid");

            migrationBuilder.RenameIndex(
                name: "IX_mangaauthors_author_id",
                table: "mangaauthors",
                newName: "IX_mangaauthors_authorid");

            migrationBuilder.RenameColumn(
                name: "upload_date",
                table: "chapters",
                newName: "uploaddate");

            migrationBuilder.RenameColumn(
                name: "manga_id",
                table: "chapters",
                newName: "mangaid");

            migrationBuilder.RenameColumn(
                name: "page_id",
                table: "bookmarks",
                newName: "pageid");

            migrationBuilder.RenameColumn(
                name: "manga_id",
                table: "bookmarks",
                newName: "mangaid");

            migrationBuilder.RenameColumn(
                name: "chapter_id",
                table: "bookmarks",
                newName: "chapterid");

            migrationBuilder.RenameColumn(
                name: "account_id",
                table: "bookmarks",
                newName: "accountid");

            migrationBuilder.RenameIndex(
                name: "IX_bookmarks_page_id",
                table: "bookmarks",
                newName: "IX_bookmarks_pageid");

            migrationBuilder.RenameIndex(
                name: "IX_bookmarks_manga_id",
                table: "bookmarks",
                newName: "IX_bookmarks_mangaid");

            migrationBuilder.RenameIndex(
                name: "IX_bookmarks_chapter_id",
                table: "bookmarks",
                newName: "IX_bookmarks_chapterid");

            migrationBuilder.CreateIndex(
                name: "UQ_accountid_mangaid_chapterid_pageid",
                table: "bookmarks",
                columns: new[] { "accountid", "mangaid", "chapterid", "pageid" },
                unique: true,
                filter: "0 = 0");
        }
    }
}
