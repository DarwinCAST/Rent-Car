using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ConcecionarioAutomoviles.Migrations
{
    /// <inheritdoc />
    public partial class SeedVendedoresData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Vendedores",
                columns: new[] { "idVendedor", "domicilioVendedor", "NIF", "nombreVendedor" },
                values: new object[,]
                {
                    { 1, "Calle Principal #123", "001-1234567-8", "Juan Pérez" },
                    { 2, "Avenida Central #456", "002-2345678-9", "María Gómez" },
                    { 3, "Calle Secundaria #789", "003-3456789-0", "Carlos Ramírez" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Vendedores",
                keyColumn: "idVendedor",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Vendedores",
                keyColumn: "idVendedor",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Vendedores",
                keyColumn: "idVendedor",
                keyValue: 3);
        }
    }
}
