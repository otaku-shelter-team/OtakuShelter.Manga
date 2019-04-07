using Microsoft.EntityFrameworkCore.Migrations;

namespace OtakuShelter.Mangas.Migrations
{
    public partial class increase_image_length : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "image",
                table: "mangas",
                maxLength: 300,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 100);

            migrationBuilder.CreateIndex(
                name: "ux_types_name",
                table: "types",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ux_translators_name",
                table: "translators",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ux_tags_name",
                table: "tags",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ux_authors_name",
                table: "authors",
                column: "name",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "ux_types_name",
                table: "types");

            migrationBuilder.DropIndex(
                name: "ux_translators_name",
                table: "translators");

            migrationBuilder.DropIndex(
                name: "ux_tags_name",
                table: "tags");

            migrationBuilder.DropIndex(
                name: "ux_authors_name",
                table: "authors");

            migrationBuilder.AlterColumn<string>(
                name: "image",
                table: "mangas",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 300);
        }
    }
}
