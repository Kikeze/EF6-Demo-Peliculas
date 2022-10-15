using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DemoEF6Peliculas.Migrations
{
    public partial class EntidadAuditable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Borrado",
                table: "Generos",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "BorradoPor",
                table: "Generos",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreadoPor",
                table: "Generos",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModificadorPor",
                table: "Generos",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: true);

            migrationBuilder.UpdateData(
                table: "CinesOfertas",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Final", "Inicio" },
                values: new object[] { new DateTime(2022, 10, 21, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2022, 10, 14, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "CinesOfertas",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Final", "Inicio" },
                values: new object[] { new DateTime(2022, 10, 19, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2022, 10, 14, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Pagos",
                keyColumn: "Id",
                keyValue: 3,
                column: "FechaTransaccion",
                value: new DateTime(2022, 9, 29, 15, 45, 55, 51, DateTimeKind.Local).AddTicks(7814));

            migrationBuilder.UpdateData(
                table: "Pagos",
                keyColumn: "Id",
                keyValue: 4,
                column: "FechaTransaccion",
                value: new DateTime(2022, 10, 4, 15, 45, 55, 51, DateTimeKind.Local).AddTicks(7845));

            migrationBuilder.UpdateData(
                table: "Pagos",
                keyColumn: "Id",
                keyValue: 1,
                column: "FechaTransaccion",
                value: new DateTime(2022, 10, 2, 15, 45, 55, 51, DateTimeKind.Local).AddTicks(7995));

            migrationBuilder.UpdateData(
                table: "Pagos",
                keyColumn: "Id",
                keyValue: 2,
                column: "FechaTransaccion",
                value: new DateTime(2022, 10, 6, 15, 45, 55, 51, DateTimeKind.Local).AddTicks(7997));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Borrado",
                table: "Generos");

            migrationBuilder.DropColumn(
                name: "BorradoPor",
                table: "Generos");

            migrationBuilder.DropColumn(
                name: "CreadoPor",
                table: "Generos");

            migrationBuilder.DropColumn(
                name: "ModificadorPor",
                table: "Generos");

            migrationBuilder.UpdateData(
                table: "CinesOfertas",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Final", "Inicio" },
                values: new object[] { new DateTime(2022, 10, 20, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2022, 10, 13, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "CinesOfertas",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Final", "Inicio" },
                values: new object[] { new DateTime(2022, 10, 18, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2022, 10, 13, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Pagos",
                keyColumn: "Id",
                keyValue: 3,
                column: "FechaTransaccion",
                value: new DateTime(2022, 9, 28, 21, 25, 29, 414, DateTimeKind.Local).AddTicks(448));

            migrationBuilder.UpdateData(
                table: "Pagos",
                keyColumn: "Id",
                keyValue: 4,
                column: "FechaTransaccion",
                value: new DateTime(2022, 10, 3, 21, 25, 29, 414, DateTimeKind.Local).AddTicks(475));

            migrationBuilder.UpdateData(
                table: "Pagos",
                keyColumn: "Id",
                keyValue: 1,
                column: "FechaTransaccion",
                value: new DateTime(2022, 10, 1, 21, 25, 29, 414, DateTimeKind.Local).AddTicks(618));

            migrationBuilder.UpdateData(
                table: "Pagos",
                keyColumn: "Id",
                keyValue: 2,
                column: "FechaTransaccion",
                value: new DateTime(2022, 10, 5, 21, 25, 29, 414, DateTimeKind.Local).AddTicks(620));
        }
    }
}
