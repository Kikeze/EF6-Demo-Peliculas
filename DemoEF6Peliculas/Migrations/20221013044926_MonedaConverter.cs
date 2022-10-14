using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DemoEF6Peliculas.Migrations
{
    public partial class MonedaConverter : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Moneda",
                table: "SalasCine",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Moneda",
                table: "SalasCine");
        }
    }
}
