using Microsoft.EntityFrameworkCore.Migrations;

namespace OtakuShelter.Mangas.Migrations
{
	public partial class SnakeCase : Migration
	{
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropIndex(
				"UQ_accountid_mangaid_chapterid_pageid",
				"bookmarks");

			migrationBuilder.RenameColumn(
				"chapterid",
				"pages",
				"chapter_id");

			migrationBuilder.RenameIndex(
				"UQ_chapterid_order",
				table: "pages",
				newName: "UQ_chapter_id_order");

			migrationBuilder.RenameColumn(
				"mangaid",
				"mangatags",
				"manga_id");

			migrationBuilder.RenameColumn(
				"tagid",
				"mangatags",
				"tag_id");

			migrationBuilder.RenameIndex(
				"IX_mangatags_mangaid",
				table: "mangatags",
				newName: "IX_mangatags_manga_id");

			migrationBuilder.RenameColumn(
				"typeid",
				"mangas",
				"type_id");

			migrationBuilder.RenameIndex(
				"IX_mangas_typeid",
				table: "mangas",
				newName: "IX_mangas_type_id");

			migrationBuilder.RenameColumn(
				"authorid",
				"mangaauthors",
				"author_id");

			migrationBuilder.RenameColumn(
				"mangaid",
				"mangaauthors",
				"manga_id");

			migrationBuilder.RenameIndex(
				"IX_mangaauthors_authorid",
				table: "mangaauthors",
				newName: "IX_mangaauthors_author_id");

			migrationBuilder.RenameColumn(
				"uploaddate",
				"chapters",
				"upload_date");

			migrationBuilder.RenameColumn(
				"mangaid",
				"chapters",
				"manga_id");

			migrationBuilder.RenameColumn(
				"pageid",
				"bookmarks",
				"page_id");

			migrationBuilder.RenameColumn(
				"mangaid",
				"bookmarks",
				"manga_id");

			migrationBuilder.RenameColumn(
				"chapterid",
				"bookmarks",
				"chapter_id");

			migrationBuilder.RenameColumn(
				"accountid",
				"bookmarks",
				"account_id");

			migrationBuilder.RenameIndex(
				"IX_bookmarks_pageid",
				table: "bookmarks",
				newName: "IX_bookmarks_page_id");

			migrationBuilder.RenameIndex(
				"IX_bookmarks_mangaid",
				table: "bookmarks",
				newName: "IX_bookmarks_manga_id");

			migrationBuilder.RenameIndex(
				"IX_bookmarks_chapterid",
				table: "bookmarks",
				newName: "IX_bookmarks_chapter_id");

			migrationBuilder.CreateIndex(
				"UQ_accountid_mangaid_chapterid_pageid",
				"bookmarks",
				new[] {"account_id", "manga_id", "chapter_id", "page_id"},
				unique: true);
		}

		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropIndex(
				"UQ_accountid_mangaid_chapterid_pageid",
				"bookmarks");

			migrationBuilder.RenameColumn(
				"chapter_id",
				"pages",
				"chapterid");

			migrationBuilder.RenameIndex(
				"UQ_chapter_id_order",
				table: "pages",
				newName: "UQ_chapterid_order");

			migrationBuilder.RenameColumn(
				"manga_id",
				"mangatags",
				"mangaid");

			migrationBuilder.RenameColumn(
				"tag_id",
				"mangatags",
				"tagid");

			migrationBuilder.RenameIndex(
				"IX_mangatags_manga_id",
				table: "mangatags",
				newName: "IX_mangatags_mangaid");

			migrationBuilder.RenameColumn(
				"type_id",
				"mangas",
				"typeid");

			migrationBuilder.RenameIndex(
				"IX_mangas_type_id",
				table: "mangas",
				newName: "IX_mangas_typeid");

			migrationBuilder.RenameColumn(
				"author_id",
				"mangaauthors",
				"authorid");

			migrationBuilder.RenameColumn(
				"manga_id",
				"mangaauthors",
				"mangaid");

			migrationBuilder.RenameIndex(
				"IX_mangaauthors_author_id",
				table: "mangaauthors",
				newName: "IX_mangaauthors_authorid");

			migrationBuilder.RenameColumn(
				"upload_date",
				"chapters",
				"uploaddate");

			migrationBuilder.RenameColumn(
				"manga_id",
				"chapters",
				"mangaid");

			migrationBuilder.RenameColumn(
				"page_id",
				"bookmarks",
				"pageid");

			migrationBuilder.RenameColumn(
				"manga_id",
				"bookmarks",
				"mangaid");

			migrationBuilder.RenameColumn(
				"chapter_id",
				"bookmarks",
				"chapterid");

			migrationBuilder.RenameColumn(
				"account_id",
				"bookmarks",
				"accountid");

			migrationBuilder.RenameIndex(
				"IX_bookmarks_page_id",
				table: "bookmarks",
				newName: "IX_bookmarks_pageid");

			migrationBuilder.RenameIndex(
				"IX_bookmarks_manga_id",
				table: "bookmarks",
				newName: "IX_bookmarks_mangaid");

			migrationBuilder.RenameIndex(
				"IX_bookmarks_chapter_id",
				table: "bookmarks",
				newName: "IX_bookmarks_chapterid");

			migrationBuilder.CreateIndex(
				"UQ_accountid_mangaid_chapterid_pageid",
				"bookmarks",
				new[] {"accountid", "mangaid", "chapterid", "pageid"},
				unique: true,
				filter: "0 = 0");
		}
	}
}