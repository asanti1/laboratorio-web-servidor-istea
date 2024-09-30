using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace laboratorio_web_api_istea.Migrations
{
    /// <inheritdoc />
    public partial class ActualizarProductosSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Productos",
                columns: new[] { "Id", "Descripcion", "Precio", "SectorId", "Stock" },
                values: new object[,]
                {
                    { 21, "Milanesa a caballo", 4800m, 3, 40 },
                    { 22, "Hamburguesa de garbanzo", 3500m, 3, 20 },
                    { 23, "Cerveza Corona", 2500m, 2, 70 },
                    { 24, "Daikiri", 3700m, 1, 15 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Productos",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Productos",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Productos",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Productos",
                keyColumn: "Id",
                keyValue: 24);
        }
    }
}
