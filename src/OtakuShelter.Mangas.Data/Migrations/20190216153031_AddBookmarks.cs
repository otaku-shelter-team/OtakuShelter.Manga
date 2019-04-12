using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace OtakuShelter.Mangas.Migrations
{
	public partial class AddBookmarks : Migration
	{
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.CreateTable(
				"bookmarks",
				table => new
				{
					id = table.Column<int>()
						.Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
					accountid = table.Column<int>(),
					name = table.Column<string>(maxLength: 100),
					created = table.Column<DateTime>(),
					mangaid = table.Column<int>(),
					chapterid = table.Column<int>(),
					pageid = table.Column<int>()
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_bookmarks", x => x.id);
					table.ForeignKey(
						"FK_chapter_bookmarks",
						x => x.chapterid,
						"chapters",
						"id",
						onDelete: ReferentialAction.Restrict);
					table.ForeignKey(
						"FK_manga_bookmarks",
						x => x.mangaid,
						"mangas",
						"id",
						onDelete: ReferentialAction.Restrict);
					table.ForeignKey(
						"FK_page_bookmarks",
						x => x.pageid,
						"pages",
						"id",
						onDelete: ReferentialAction.Restrict);
				});

			migrationBuilder.CreateIndex(
				"IX_bookmarks_chapterid",
				"bookmarks",
				"chapterid");

			migrationBuilder.CreateIndex(
				"IX_bookmarks_mangaid",
				"bookmarks",
				"mangaid");

			migrationBuilder.CreateIndex(
				"IX_bookmarks_pageid",
				"bookmarks",
				"pageid");

			migrationBuilder.CreateIndex(
				"UQ_accountid_mangaid_chapterid_pageid",
				"bookmarks",
				new[] {"accountid", "mangaid", "chapterid", "pageid"},
				unique: true);
		}

		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropTable(
				"bookmarks");
		}
	}
}