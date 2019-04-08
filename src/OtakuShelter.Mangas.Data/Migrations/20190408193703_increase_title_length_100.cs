using Microsoft.EntityFrameworkCore.Migrations;

namespace OtakuShelter.Mangas.Migrations
{
    public partial class increase_title_length_100 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "title",
                table: "mangas",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 100);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "title",
                table: "mangas",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 200);
        }
    }
}
