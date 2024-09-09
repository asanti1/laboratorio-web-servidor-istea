using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace laboratorio_web_api_istea.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "estados_mesas",
                columns: table => new
                {
                    id_estado = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    descripcion = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__estados___86989FB25DC000DA", x => x.id_estado);
                });

            migrationBuilder.CreateTable(
                name: "estados_pedidos",
                columns: table => new
                {
                    id_estado = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    descripcion = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__estados___86989FB22B850469", x => x.id_estado);
                });

            migrationBuilder.CreateTable(
                name: "roles",
                columns: table => new
                {
                    id_rol = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    descripcion = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__roles__6ABCB5E0F0DBB297", x => x.id_rol);
                });

            migrationBuilder.CreateTable(
                name: "sectores",
                columns: table => new
                {
                    id_sector = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    descripcion = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__sectores__3483C369F5575B44", x => x.id_sector);
                });

            migrationBuilder.CreateTable(
                name: "mesas",
                columns: table => new
                {
                    id_mesa = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    id_estado = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__mesas__68A1E159EA69519A", x => x.id_mesa);
                    table.ForeignKey(
                        name: "FK__mesas__id_estado__6754599E",
                        column: x => x.id_estado,
                        principalTable: "estados_mesas",
                        principalColumn: "id_estado");
                });

            migrationBuilder.CreateTable(
                name: "empleados",
                columns: table => new
                {
                    id_empleado = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    usuario = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    password = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    id_sector = table.Column<int>(type: "int", nullable: false),
                    id_rol = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__empleado__88B51394BA44895C", x => x.id_empleado);
                    table.ForeignKey(
                        name: "FK__empleados__id_ro__5FB337D6",
                        column: x => x.id_rol,
                        principalTable: "roles",
                        principalColumn: "id_rol");
                    table.ForeignKey(
                        name: "FK__empleados__id_se__5EBF139D",
                        column: x => x.id_sector,
                        principalTable: "sectores",
                        principalColumn: "id_sector");
                });

            migrationBuilder.CreateTable(
                name: "productos",
                columns: table => new
                {
                    id_producto = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_sector = table.Column<int>(type: "int", nullable: false),
                    descripcion = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    stock = table.Column<int>(type: "int", nullable: false),
                    precio = table.Column<decimal>(type: "decimal(10,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__producto__FF341C0DBCB8AC7D", x => x.id_producto);
                    table.ForeignKey(
                        name: "FK__productos__id_se__628FA481",
                        column: x => x.id_sector,
                        principalTable: "sectores",
                        principalColumn: "id_sector");
                });

            migrationBuilder.CreateTable(
                name: "comandas",
                columns: table => new
                {
                    id_comanda = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_mesa = table.Column<int>(type: "int", nullable: false),
                    nombre_cliente = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__comandas__6D6D170D8EE45A48", x => x.id_comanda);
                    table.ForeignKey(
                        name: "FK__comandas__id_mes__6A30C649",
                        column: x => x.id_mesa,
                        principalTable: "mesas",
                        principalColumn: "id_mesa");
                });

            migrationBuilder.CreateTable(
                name: "pedidos",
                columns: table => new
                {
                    id_pedido = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_comanda = table.Column<int>(type: "int", nullable: false),
                    id_producto = table.Column<int>(type: "int", nullable: false),
                    cantidad = table.Column<int>(type: "int", nullable: false),
                    id_estado = table.Column<int>(type: "int", nullable: false),
                    fecha_creacion = table.Column<DateTime>(type: "datetime", nullable: false),
                    fecha_finalizacion = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__pedidos__6FF014893198D858", x => x.id_pedido);
                    table.ForeignKey(
                        name: "FK__pedidos__id_coma__6EF57B66",
                        column: x => x.id_comanda,
                        principalTable: "comandas",
                        principalColumn: "id_comanda");
                    table.ForeignKey(
                        name: "FK__pedidos__id_esta__70DDC3D8",
                        column: x => x.id_estado,
                        principalTable: "estados_pedidos",
                        principalColumn: "id_estado");
                    table.ForeignKey(
                        name: "FK__pedidos__id_prod__6FE99F9F",
                        column: x => x.id_producto,
                        principalTable: "productos",
                        principalColumn: "id_producto");
                });

            migrationBuilder.CreateIndex(
                name: "IX_comandas_id_mesa",
                table: "comandas",
                column: "id_mesa");

            migrationBuilder.CreateIndex(
                name: "IX_empleados_id_rol",
                table: "empleados",
                column: "id_rol");

            migrationBuilder.CreateIndex(
                name: "IX_empleados_id_sector",
                table: "empleados",
                column: "id_sector");

            migrationBuilder.CreateIndex(
                name: "IX_mesas_id_estado",
                table: "mesas",
                column: "id_estado");

            migrationBuilder.CreateIndex(
                name: "IX_pedidos_id_comanda",
                table: "pedidos",
                column: "id_comanda");

            migrationBuilder.CreateIndex(
                name: "IX_pedidos_id_estado",
                table: "pedidos",
                column: "id_estado");

            migrationBuilder.CreateIndex(
                name: "IX_pedidos_id_producto",
                table: "pedidos",
                column: "id_producto");

            migrationBuilder.CreateIndex(
                name: "IX_productos_id_sector",
                table: "productos",
                column: "id_sector");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "empleados");

            migrationBuilder.DropTable(
                name: "pedidos");

            migrationBuilder.DropTable(
                name: "roles");

            migrationBuilder.DropTable(
                name: "comandas");

            migrationBuilder.DropTable(
                name: "estados_pedidos");

            migrationBuilder.DropTable(
                name: "productos");

            migrationBuilder.DropTable(
                name: "mesas");

            migrationBuilder.DropTable(
                name: "sectores");

            migrationBuilder.DropTable(
                name: "estados_mesas");
        }
    }
}
