using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DemoEF6Peliculas.Migrations
{
    public partial class Pagos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pagos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Monto = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    FechaTransaccion = table.Column<DateTime>(type: "datetime", nullable: false),
                    TipoPago = table.Column<int>(type: "int", nullable: false),
                    EMail = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    Ultimos4Digitos = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pagos", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Pagos",
                columns: new[] { "Id", "EMail", "FechaTransaccion", "Monto", "TipoPago" },
                values: new object[,]
                {
                    { 3, "prueba1@correo.com", new DateTime(2022, 9, 28, 20, 43, 33, 706, DateTimeKind.Local).AddTicks(5374), 150m, 1 },
                    { 4, "prueba2@correo.com", new DateTime(2022, 10, 3, 20, 43, 33, 706, DateTimeKind.Local).AddTicks(5399), 250m, 1 }
                });

            migrationBuilder.InsertData(
                table: "Pagos",
                columns: new[] { "Id", "FechaTransaccion", "Monto", "TipoPago", "Ultimos4Digitos" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 10, 1, 20, 43, 33, 706, DateTimeKind.Local).AddTicks(5537), 175m, 2, "1234" },
                    { 2, new DateTime(2022, 10, 5, 20, 43, 33, 706, DateTimeKind.Local).AddTicks(5539), 275m, 2, "4321" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pagos");
        }
    }
}
