using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DemoEF6Peliculas.Migrations
{
    public partial class VistaPeliculaConteo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.Sql(@"
CREATE VIEW [dbo].[PeliculaConteo]
AS
SELECT p.Id, p.Titulo,
	(SELECT COUNT(*)
	 FROM GeneroPelicula AS gp
	 WHERE gp.PeliculasId = p.Id) AS CantidadGeneros,
	(SELECT COUNT(DISTINCT CineId)
	 FROM PeliculaSalaCine AS psc
	 INNER JOIN SalasCine AS sc ON sc.Id = psc.SalasCineId
	 WHERE psc.PeliculasId = p.Id) AS CantidadCines,
	(SELECT COUNT(*)
	 FROM PeliculasActores AS pa
	 WHERE pa.PeliculaId = p.Id) AS CantidadActores
FROM Peliculas AS p");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.Sql("DROP VIEW [dbo].[PeliculaConteo]");
        }
    }
}
