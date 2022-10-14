using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DemoEF6Peliculas.Migrations
{
    public partial class HerenciaTablaPorTipo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "PosterURL",
                table: "Peliculas",
                type: "varchar(1024)",
                unicode: false,
                maxLength: 1024,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(500)",
                oldUnicode: false,
                oldMaxLength: 500,
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Productos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Precio = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Productos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Juguetes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Disponible = table.Column<bool>(type: "bit", nullable: false),
                    Peso = table.Column<double>(type: "float", nullable: false),
                    Volumen = table.Column<double>(type: "float", nullable: false),
                    esRopa = table.Column<bool>(type: "bit", nullable: false),
                    esColeccionable = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Juguetes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Juguetes_Productos_Id",
                        column: x => x.Id,
                        principalTable: "Productos",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PeliculasAlquilables",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    PeliculaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PeliculasAlquilables", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PeliculasAlquilables_Productos_Id",
                        column: x => x.Id,
                        principalTable: "Productos",
                        principalColumn: "Id");
                });

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

            migrationBuilder.InsertData(
                table: "Productos",
                columns: new[] { "Id", "Nombre", "Precio" },
                values: new object[,]
                {
                    { 2, "Playera", 11m },
                    { 1, "Spider-Man", 5.99m }
                });

            migrationBuilder.InsertData(
                table: "Juguetes",
                columns: new[] { "Id", "Disponible", "Peso", "Volumen", "esColeccionable", "esRopa" },
                values: new object[] { 2, true, 1.0, 1.0, false, true });

            migrationBuilder.InsertData(
                table: "PeliculasAlquilables",
                columns: new[] { "Id", "PeliculaId" },
                values: new object[] { 1, 1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Juguetes");

            migrationBuilder.DropTable(
                name: "PeliculasAlquilables");

            migrationBuilder.DropTable(
                name: "Productos");

            migrationBuilder.AlterColumn<string>(
                name: "PosterURL",
                table: "Peliculas",
                type: "varchar(500)",
                unicode: false,
                maxLength: 500,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(1024)",
                oldUnicode: false,
                oldMaxLength: 1024,
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Pagos",
                keyColumn: "Id",
                keyValue: 3,
                column: "FechaTransaccion",
                value: new DateTime(2022, 9, 28, 20, 43, 33, 706, DateTimeKind.Local).AddTicks(5374));

            migrationBuilder.UpdateData(
                table: "Pagos",
                keyColumn: "Id",
                keyValue: 4,
                column: "FechaTransaccion",
                value: new DateTime(2022, 10, 3, 20, 43, 33, 706, DateTimeKind.Local).AddTicks(5399));

            migrationBuilder.UpdateData(
                table: "Pagos",
                keyColumn: "Id",
                keyValue: 1,
                column: "FechaTransaccion",
                value: new DateTime(2022, 10, 1, 20, 43, 33, 706, DateTimeKind.Local).AddTicks(5537));

            migrationBuilder.UpdateData(
                table: "Pagos",
                keyColumn: "Id",
                keyValue: 2,
                column: "FechaTransaccion",
                value: new DateTime(2022, 10, 5, 20, 43, 33, 706, DateTimeKind.Local).AddTicks(5539));
        }
    }
}
