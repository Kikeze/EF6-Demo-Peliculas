using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DemoEF6Peliculas.Migrations
{
    public partial class CineDetalle : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "Apertura",
                table: "Cines",
                type: "datetime",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Etica",
                table: "Cines",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Historia",
                table: "Cines",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Misiones",
                table: "Cines",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Valores",
                table: "Cines",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Apertura",
                table: "Cines");

            migrationBuilder.DropColumn(
                name: "Etica",
                table: "Cines");

            migrationBuilder.DropColumn(
                name: "Historia",
                table: "Cines");

            migrationBuilder.DropColumn(
                name: "Misiones",
                table: "Cines");

            migrationBuilder.DropColumn(
                name: "Valores",
                table: "Cines");
        }
    }
}
