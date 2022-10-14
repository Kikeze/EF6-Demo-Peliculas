using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DemoEF6Peliculas.Migrations
{
    public partial class RestriccionEnBorradoSalaCine : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SalasCine_Cines_CineId",
                table: "SalasCine");

            migrationBuilder.AddForeignKey(
                name: "FK_SalasCine_Cines_CineId",
                table: "SalasCine",
                column: "CineId",
                principalTable: "Cines",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SalasCine_Cines_CineId",
                table: "SalasCine");

            migrationBuilder.AddForeignKey(
                name: "FK_SalasCine_Cines_CineId",
                table: "SalasCine",
                column: "CineId",
                principalTable: "Cines",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
