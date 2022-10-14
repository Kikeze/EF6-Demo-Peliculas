using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DemoEF6Peliculas.Migrations
{
    public partial class Logs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Logs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime", nullable: false),
                    Mensaje = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Logs", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "CinesOfertas",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Final", "Inicio" },
                values: new object[] { new DateTime(2022, 10, 19, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2022, 10, 12, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "CinesOfertas",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Final", "Inicio" },
                values: new object[] { new DateTime(2022, 10, 17, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2022, 10, 12, 0, 0, 0, 0, DateTimeKind.Local) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Logs");

            migrationBuilder.UpdateData(
                table: "CinesOfertas",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Final", "Inicio" },
                values: new object[] { new DateTime(2022, 10, 7, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2022, 9, 30, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "CinesOfertas",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Final", "Inicio" },
                values: new object[] { new DateTime(2022, 10, 5, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2022, 9, 30, 0, 0, 0, 0, DateTimeKind.Local) });
        }
    }
}
