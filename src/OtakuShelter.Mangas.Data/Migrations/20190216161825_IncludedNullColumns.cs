using Microsoft.EntityFrameworkCore.Migrations;

namespace OtakuShelter.Mangas.Migrations
{
	public partial class IncludedNullColumns : Migration
	{
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropIndex(
				"UQ_accountid_mangaid_chapterid_pageid",
				"bookmarks");

			migrationBuilder.CreateIndex(
				"UQ_accountid_mangaid_chapterid_pageid",
				"bookmarks",
				new[] {"accountid", "mangaid", "chapterid", "pageid"},
				unique: true,
				filter: "0 = 0");
		}

		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropIndex(
				"UQ_accountid_mangaid_chapterid_pageid",
				"bookmarks");

			migrationBuilder.CreateIndex(
					"UQ_accountid_mangaid_chapterid_pageid",
					"bookmarks",
					new[] {"accountid", "mangaid"},
					unique: true)
				.Annotation("Npgsql:IndexInclude", new[] {"ChapterId", "PageId"});
		}
	}
}