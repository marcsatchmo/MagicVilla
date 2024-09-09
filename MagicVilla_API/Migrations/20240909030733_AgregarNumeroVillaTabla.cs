using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MagicVillaAPI.Migrations
{
    /// <inheritdoc />
    public partial class AgregarNumeroVillaTabla : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Villas",
                table: "Villas");

            migrationBuilder.RenameTable(
                name: "Villas",
                newName: "Villa");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Villa",
                table: "Villa",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "Villa",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "FechaActualizacion", "FechaCreacion" },
                values: new object[] { new DateTime(2024, 9, 9, 0, 7, 33, 673, DateTimeKind.Local).AddTicks(1013), new DateTime(2024, 9, 9, 0, 7, 33, 673, DateTimeKind.Local).AddTicks(952) });

            migrationBuilder.UpdateData(
                table: "Villa",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "FechaActualizacion", "FechaCreacion" },
                values: new object[] { new DateTime(2024, 9, 9, 0, 7, 33, 673, DateTimeKind.Local).AddTicks(1017), new DateTime(2024, 9, 9, 0, 7, 33, 673, DateTimeKind.Local).AddTicks(1016) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Villa",
                table: "Villa");

            migrationBuilder.RenameTable(
                name: "Villa",
                newName: "Villas");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Villas",
                table: "Villas",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "FechaActualizacion", "FechaCreacion" },
                values: new object[] { new DateTime(2024, 9, 1, 22, 35, 13, 134, DateTimeKind.Local).AddTicks(7490), new DateTime(2024, 9, 1, 22, 35, 13, 134, DateTimeKind.Local).AddTicks(7468) });

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "FechaActualizacion", "FechaCreacion" },
                values: new object[] { new DateTime(2024, 9, 1, 22, 35, 13, 134, DateTimeKind.Local).AddTicks(7493), new DateTime(2024, 9, 1, 22, 35, 13, 134, DateTimeKind.Local).AddTicks(7492) });
        }
    }
}
