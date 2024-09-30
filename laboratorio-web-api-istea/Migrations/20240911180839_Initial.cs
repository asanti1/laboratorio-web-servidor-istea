using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace laboratorio_web_api_istea.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EstadosMesas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstadosMesas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EstadosPedidos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstadosPedidos", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "EstadosMesas",
                columns: new[] { "Id", "Descripcion" },
                values: new object[,]
                {
                                { 1, "Cliente esperando pedido" },
                                { 2, "Cliente comiendo" },
                                { 3, "Cliente pagando" },
                                { 4, "Cerrada" }
                });

            migrationBuilder.InsertData(
                table: "EstadosPedidos",
                columns: new[] { "Id", "Descripcion" },
                values: new object[,]
                {
                    { 1, "Pendiente" },
                    { 2, "En preparación" },
                    { 3, "Listo para servir" }
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });


            migrationBuilder.CreateTable(
                name: "Sectores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sectores", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Descripcion" },
                values: new object[,]
                {
                                { 1, "Bartender" },
                                { 2, "Cervecero" },
                                { 3, "Cocinero" },
                                { 4, "Mozo" },
                                { 5, "Socio" }
                });

            migrationBuilder.InsertData(
                table: "Sectores",
                columns: new[] { "Id", "Descripcion" },
                values: new object[,]
                {
                    { 1, "Barra de Tragos y Vinos" },
                    { 2, "Barra de Choperas de Cerveza Artesanal" },
                    { 3, "Cocina" },
                    { 4, "Candy Bar" },
                    { 5, "Mesa" },
                    { 6, "Administracion" }
                });

            migrationBuilder.CreateTable(
                name: "Mesas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EstadosMesaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mesas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Mesas_EstadosMesas_EstadosMesaId",
                        column: x => x.EstadosMesaId,
                        principalTable: "EstadosMesas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Empleados",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Usuario = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdSector = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empleados", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Empleados_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Empleados_Sectores_IdSector",
                        column: x => x.IdSector,
                        principalTable: "Sectores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Productos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SectorId = table.Column<int>(type: "int", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Stock = table.Column<int>(type: "int", nullable: false),
                    Precio = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Productos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Productos_Sectores_SectorId",
                        column: x => x.SectorId,
                        principalTable: "Sectores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comandas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MesaId = table.Column<int>(type: "int", nullable: false),
                    NombreCliente = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comandas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comandas_Mesas_MesaId",
                        column: x => x.MesaId,
                        principalTable: "Mesas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pedidos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ComandaId = table.Column<int>(type: "int", nullable: false),
                    ProductoId = table.Column<int>(type: "int", nullable: false),
                    EstadosPedidoId = table.Column<int>(type: "int", nullable: false),
                    Cantidad = table.Column<int>(type: "int", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaFinalizacion = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pedidos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pedidos_Comandas_ComandaId",
                        column: x => x.ComandaId,
                        principalTable: "Comandas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pedidos_EstadosPedidos_EstadosPedidoId",
                        column: x => x.EstadosPedidoId,
                        principalTable: "EstadosPedidos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pedidos_Productos_ProductoId",
                        column: x => x.ProductoId,
                        principalTable: "Productos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
               name: "RegistroEmpleados",
               columns: table => new
               {
                   Id = table.Column<int>(type: "int", nullable: false)
                       .Annotation("SqlServer:Identity", "1, 1"),
                   IdEmpleado = table.Column<int>(type: "int", nullable: false),
                   FechaHora = table.Column<DateTime>(type: "datetime", nullable: false)
               },
               constraints: table =>
               {
                   table.PrimaryKey("PK_RegistroEmpleados", x => x.Id);
                   table.ForeignKey(
                       name: "FK_RegistroEmpleados_Empleados",
                       column: x => x.IdEmpleado,
                       principalTable: "Empleados",
                       principalColumn: "Id",
                       onDelete: ReferentialAction.Cascade);
               });

            migrationBuilder.InsertData(
                table: "Empleados",
                columns: new[] { "Id", "IdSector", "Nombre", "Password", "RoleId", "Usuario" },
                values: new object[,]
                {
                    { 1, 1, "Carlos", "12345", 1, "carlos" },
                    { 2, 2, "Roberto", "12345", 2, "roberto" },
                    { 3, 3, "Maria", "12345", 3, "maria" },
                    { 4, 5, "Juana", "12345", 4, "juana" },
                    { 5, 6, "Marcelo", "12345", 5, "marcelo" }
                });

            migrationBuilder.InsertData(
                table: "Mesas",
                columns: new[] { "Id", "EstadosMesaId", "Nombre" },
                values: new object[,]
                {
                    { 1, 4, "MESA0" },
                    { 2, 4, "MESA1" },
                    { 3, 4, "MESA2" },
                    { 4, 4, "MESA3" },
                    { 5, 4, "MESA4" },
                    { 6, 4, "MESA5" },
                    { 7, 4, "MESA6" },
                    { 8, 4, "MESA7" },
                    { 9, 4, "MESA8" },
                    { 10, 4, "MESA9" }
                });

            migrationBuilder.InsertData(
                table: "Productos",
                columns: new[] { "Id", "Descripcion", "Precio", "SectorId", "Stock" },
                values: new object[,]
                {
                    { 1, "Vino Toro", 1100m, 1, 150 },
                    { 2, "Fernet Branca", 2000m, 1, 200 },
                    { 3, "Whisky Jack Daniels", 4500m, 1, 80 },
                    { 4, "Cerveza IPA", 700m, 2, 300 },
                    { 5, "Cerveza Stout", 800m, 2, 250 },
                    { 6, "Cerveza APA", 750m, 2, 275 },
                    { 7, "Pizza Margarita", 1200m, 3, 50 },
                    { 8, "Hamburguesa Doble", 1500m, 3, 60 },
                    { 9, "Sándwich de Lomito", 1400m, 3, 40 },
                    { 10, "Empanadas de Carne", 100m, 3, 100 },
                    { 11, "Nachos con Guacamole", 500m, 3, 70 },
                    { 12, "Pochoclos", 300m, 4, 300 },
                    { 13, "Gomitas Frutales", 150m, 4, 250 },
                    { 14, "Alfajor Triple", 180m, 4, 120 },
                    { 15, "Chocolates Milka", 350m, 4, 90 },
                    { 16, "Frapuccino", 1300m, 1, 100 },
                    { 17, "Vino Malbec", 2300m, 1, 130 },
                    { 18, "Cerveza Porter", 900m, 2, 280 },
                    { 19, "Torta de Chocolate", 1600m, 3, 30 },
                    { 20, "Muffin de Arándanos", 400m, 4, 50 }
                });

            //INDICES
            migrationBuilder.CreateIndex(
                name: "IX_Comandas_MesaId",
                table: "Comandas",
                column: "MesaId");

            migrationBuilder.CreateIndex(
                name: "IX_Empleados_IdSector",
                table: "Empleados",
                column: "IdSector");

            migrationBuilder.CreateIndex(
                name: "IX_Empleados_RoleId",
                table: "Empleados",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Mesas_EstadosMesaId",
                table: "Mesas",
                column: "EstadosMesaId");

            migrationBuilder.CreateIndex(
                name: "IX_Pedidos_ComandaId",
                table: "Pedidos",
                column: "ComandaId");

            migrationBuilder.CreateIndex(
                name: "IX_Pedidos_EstadosPedidoId",
                table: "Pedidos",
                column: "EstadosPedidoId");

            migrationBuilder.CreateIndex(
                name: "IX_Pedidos_ProductoId",
                table: "Pedidos",
                column: "ProductoId");

            migrationBuilder.CreateIndex(
                name: "IX_Productos_SectorId",
                table: "Productos",
                column: "SectorId");

            migrationBuilder.CreateIndex(
                name: "IX_RegistroEmpleados_IdEmpleado",
                table: "RegistroEmpleados",
                column: "IdEmpleado");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Empleados");

            migrationBuilder.DropTable(
                name: "Pedidos");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Comandas");

            migrationBuilder.DropTable(
                name: "EstadosPedidos");

            migrationBuilder.DropTable(
                name: "Productos");

            migrationBuilder.DropTable(
                name: "Mesas");

            migrationBuilder.DropTable(
                name: "Sectores");

            migrationBuilder.DropTable(
                name: "EstadosMesas");

            migrationBuilder.DropTable(
            name: "RegistroEmpleados");
        }
    }
}
