using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAppOperacionesTDS.Data.Migrations
{
    public partial class ScriptManagerOperacion1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "FechaModificacion",
                table: "Operacion",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<string>(
                name: "RazonSocial",
                table: "Cliente",
                type: "nvarchar(129)",
                maxLength: 129,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(120)",
                oldMaxLength: 120);

            migrationBuilder.AlterColumn<string>(
                name: "Direccion",
                table: "Cliente",
                type: "nvarchar(129)",
                maxLength: 129,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(120)",
                oldMaxLength: 120);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "FechaModificacion",
                table: "Operacion",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "RazonSocial",
                table: "Cliente",
                type: "nvarchar(120)",
                maxLength: 120,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(129)",
                oldMaxLength: 129);

            migrationBuilder.AlterColumn<string>(
                name: "Direccion",
                table: "Cliente",
                type: "nvarchar(120)",
                maxLength: 120,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(129)",
                oldMaxLength: 129);
        }
    }
}
