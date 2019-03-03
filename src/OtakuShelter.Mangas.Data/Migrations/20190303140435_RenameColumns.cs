using Microsoft.EntityFrameworkCore.Migrations;

namespace OtakuShelter.Mangas.Migrations
{
    public partial class RenameColumns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_author_mangaauthors",
                table: "mangaauthors");

            migrationBuilder.DropForeignKey(
                name: "FK_manga_mangaauthors",
                table: "mangaauthors");

            migrationBuilder.DropForeignKey(
                name: "FK_manga_mangatags",
                table: "mangatags");

            migrationBuilder.DropForeignKey(
                name: "FK_tag_mangatags",
                table: "mangatags");

            migrationBuilder.DropForeignKey(
                name: "FK_manga_mangatranslators",
                table: "mangatranslators");

            migrationBuilder.DropForeignKey(
                name: "FK_translator_mangatranslators",
                table: "mangatranslators");

            migrationBuilder.DropPrimaryKey(
                name: "PK_mangatranslators",
                table: "mangatranslators");

            migrationBuilder.DropPrimaryKey(
                name: "PK_mangatags",
                table: "mangatags");

            migrationBuilder.DropPrimaryKey(
                name: "PK_mangaauthors",
                table: "mangaauthors");

            migrationBuilder.RenameTable(
                name: "mangatranslators",
                newName: "manga_translators");

            migrationBuilder.RenameTable(
                name: "mangatags",
                newName: "manga_tags");

            migrationBuilder.RenameTable(
                name: "mangaauthors",
                newName: "manga_authors");

            migrationBuilder.RenameColumn(
                name: "translatorid",
                table: "manga_translators",
                newName: "translator_id");

            migrationBuilder.RenameColumn(
                name: "mangaid",
                table: "manga_translators",
                newName: "manga_id");

            migrationBuilder.RenameIndex(
                name: "IX_mangatranslators_translatorid",
                table: "manga_translators",
                newName: "IX_manga_translators_translator_id");

            migrationBuilder.RenameIndex(
                name: "IX_mangatags_manga_id",
                table: "manga_tags",
                newName: "IX_manga_tags_manga_id");

            migrationBuilder.RenameIndex(
                name: "IX_mangaauthors_author_id",
                table: "manga_authors",
                newName: "IX_manga_authors_author_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_manga_translators",
                table: "manga_translators",
                columns: new[] { "manga_id", "translator_id" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_manga_tags",
                table: "manga_tags",
                columns: new[] { "tag_id", "manga_id" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_manga_authors",
                table: "manga_authors",
                columns: new[] { "manga_id", "author_id" });

            migrationBuilder.AddForeignKey(
                name: "FK_author_manga_authors",
                table: "manga_authors",
                column: "author_id",
                principalTable: "authors",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_manga_manga_authors",
                table: "manga_authors",
                column: "manga_id",
                principalTable: "mangas",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_manga_manga_tags",
                table: "manga_tags",
                column: "manga_id",
                principalTable: "mangas",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_tag_manga_tags",
                table: "manga_tags",
                column: "tag_id",
                principalTable: "tags",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_manga_manga_translators",
                table: "manga_translators",
                column: "manga_id",
                principalTable: "mangas",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_translator_manga_translators",
                table: "manga_translators",
                column: "translator_id",
                principalTable: "translators",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_author_manga_authors",
                table: "manga_authors");

            migrationBuilder.DropForeignKey(
                name: "FK_manga_manga_authors",
                table: "manga_authors");

            migrationBuilder.DropForeignKey(
                name: "FK_manga_manga_tags",
                table: "manga_tags");

            migrationBuilder.DropForeignKey(
                name: "FK_tag_manga_tags",
                table: "manga_tags");

            migrationBuilder.DropForeignKey(
                name: "FK_manga_manga_translators",
                table: "manga_translators");

            migrationBuilder.DropForeignKey(
                name: "FK_translator_manga_translators",
                table: "manga_translators");

            migrationBuilder.DropPrimaryKey(
                name: "PK_manga_translators",
                table: "manga_translators");

            migrationBuilder.DropPrimaryKey(
                name: "PK_manga_tags",
                table: "manga_tags");

            migrationBuilder.DropPrimaryKey(
                name: "PK_manga_authors",
                table: "manga_authors");

            migrationBuilder.RenameTable(
                name: "manga_translators",
                newName: "mangatranslators");

            migrationBuilder.RenameTable(
                name: "manga_tags",
                newName: "mangatags");

            migrationBuilder.RenameTable(
                name: "manga_authors",
                newName: "mangaauthors");

            migrationBuilder.RenameColumn(
                name: "translator_id",
                table: "mangatranslators",
                newName: "translatorid");

            migrationBuilder.RenameColumn(
                name: "manga_id",
                table: "mangatranslators",
                newName: "mangaid");

            migrationBuilder.RenameIndex(
                name: "IX_manga_translators_translator_id",
                table: "mangatranslators",
                newName: "IX_mangatranslators_translatorid");

            migrationBuilder.RenameIndex(
                name: "IX_manga_tags_manga_id",
                table: "mangatags",
                newName: "IX_mangatags_manga_id");

            migrationBuilder.RenameIndex(
                name: "IX_manga_authors_author_id",
                table: "mangaauthors",
                newName: "IX_mangaauthors_author_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_mangatranslators",
                table: "mangatranslators",
                columns: new[] { "mangaid", "translatorid" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_mangatags",
                table: "mangatags",
                columns: new[] { "tag_id", "manga_id" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_mangaauthors",
                table: "mangaauthors",
                columns: new[] { "manga_id", "author_id" });

            migrationBuilder.AddForeignKey(
                name: "FK_author_mangaauthors",
                table: "mangaauthors",
                column: "author_id",
                principalTable: "authors",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_manga_mangaauthors",
                table: "mangaauthors",
                column: "manga_id",
                principalTable: "mangas",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_manga_mangatags",
                table: "mangatags",
                column: "manga_id",
                principalTable: "mangas",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_tag_mangatags",
                table: "mangatags",
                column: "tag_id",
                principalTable: "tags",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_manga_mangatranslators",
                table: "mangatranslators",
                column: "mangaid",
                principalTable: "mangas",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_translator_mangatranslators",
                table: "mangatranslators",
                column: "translatorid",
                principalTable: "translators",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
