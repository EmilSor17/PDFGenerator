using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PDFGenerator.Infraestructure.Migrations
{
    public partial class AjusteDeNombres : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Nombre",
                table: "Templates",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "Contenido",
                table: "Templates",
                newName: "Content");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Updated",
                table: "Templates",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Templates",
                newName: "Nombre");

            migrationBuilder.RenameColumn(
                name: "Content",
                table: "Templates",
                newName: "Contenido");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Updated",
                table: "Templates",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);
        }
    }
}
