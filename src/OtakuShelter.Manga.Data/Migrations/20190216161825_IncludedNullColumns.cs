using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OtakuShelter.Manga.Migrations
{
    public partial class IncludedNullColumns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "UQ_accountid_mangaid_chapterid_pageid",
                table: "bookmarks");

            migrationBuilder.CreateIndex(
                name: "UQ_accountid_mangaid_chapterid_pageid",
                table: "bookmarks",
                columns: new[] { "accountid", "mangaid", "chapterid", "pageid" },
                unique: true,
                filter: "0 = 0");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "UQ_accountid_mangaid_chapterid_pageid",
                table: "bookmarks");

            migrationBuilder.CreateIndex(
                name: "UQ_accountid_mangaid_chapterid_pageid",
                table: "bookmarks",
                columns: new[] { "accountid", "mangaid" },
                unique: true)
                .Annotation("Npgsql:IndexInclude", new[] { "ChapterId", "PageId" });
        }
    }
}
