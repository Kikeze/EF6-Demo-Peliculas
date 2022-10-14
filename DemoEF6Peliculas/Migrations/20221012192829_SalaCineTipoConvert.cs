using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DemoEF6Peliculas.Migrations
{
    public partial class SalaCineTipoConvert : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Tipo",
                table: "SalasCine",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "NoDefinida",
                oldClrType: typeof(int),
                oldType: "int",
                oldDefaultValue: 0);

            migrationBuilder.UpdateData(
                table: "SalasCine",
                keyColumn: "Id",
                keyValue: 1,
                column: "Tipo",
                value: "DosDimensiones");

            migrationBuilder.UpdateData(
                table: "SalasCine",
                keyColumn: "Id",
                keyValue: 2,
                column: "Tipo",
                value: "TresDimensiones");

            migrationBuilder.UpdateData(
                table: "SalasCine",
                keyColumn: "Id",
                keyValue: 3,
                column: "Tipo",
                value: "DosDimensiones");

            migrationBuilder.UpdateData(
                table: "SalasCine",
                keyColumn: "Id",
                keyValue: 4,
                column: "Tipo",
                value: "TresDimensiones");

            migrationBuilder.UpdateData(
                table: "SalasCine",
                keyColumn: "Id",
                keyValue: 5,
                column: "Tipo",
                value: "DosDimensiones");

            migrationBuilder.UpdateData(
                table: "SalasCine",
                keyColumn: "Id",
                keyValue: 6,
                column: "Tipo",
                value: "TresDimensiones");

            migrationBuilder.UpdateData(
                table: "SalasCine",
                keyColumn: "Id",
                keyValue: 7,
                column: "Tipo",
                value: "VIP");

            migrationBuilder.UpdateData(
                table: "SalasCine",
                keyColumn: "Id",
                keyValue: 8,
                column: "Tipo",
                value: "DosDimensiones");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Tipo",
                table: "SalasCine",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldDefaultValue: "NoDefinida");

            migrationBuilder.UpdateData(
                table: "SalasCine",
                keyColumn: "Id",
                keyValue: 1,
                column: "Tipo",
                value: 1);

            migrationBuilder.UpdateData(
                table: "SalasCine",
                keyColumn: "Id",
                keyValue: 2,
                column: "Tipo",
                value: 2);

            migrationBuilder.UpdateData(
                table: "SalasCine",
                keyColumn: "Id",
                keyValue: 3,
                column: "Tipo",
                value: 1);

            migrationBuilder.UpdateData(
                table: "SalasCine",
                keyColumn: "Id",
                keyValue: 4,
                column: "Tipo",
                value: 2);

            migrationBuilder.UpdateData(
                table: "SalasCine",
                keyColumn: "Id",
                keyValue: 5,
                column: "Tipo",
                value: 1);

            migrationBuilder.UpdateData(
                table: "SalasCine",
                keyColumn: "Id",
                keyValue: 6,
                column: "Tipo",
                value: 2);

            migrationBuilder.UpdateData(
                table: "SalasCine",
                keyColumn: "Id",
                keyValue: 7,
                column: "Tipo",
                value: 3);

            migrationBuilder.UpdateData(
                table: "SalasCine",
                keyColumn: "Id",
                keyValue: 8,
                column: "Tipo",
                value: 1);
        }
    }
}
