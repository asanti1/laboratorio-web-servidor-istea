﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using laboratorio_web_api_istea.DAL;

#nullable disable

namespace laboratorio_web_api_istea.Migrations
{
    [DbContext(typeof(RestauranteContext))]
    partial class RestauranteContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("laboratorio_web_api_istea.DAL.Models.Comanda", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("MesaId")
                        .HasColumnType("int");

                    b.Property<string>("NombreCliente")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("MesaId");

                    b.ToTable("Comandas");
                });

            modelBuilder.Entity("laboratorio_web_api_istea.DAL.Models.Empleado", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("IdSector")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.Property<string>("Usuario")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("IdSector");

                    b.HasIndex("RoleId");

                    b.ToTable("Empleados");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            IdSector = 1,
                            Nombre = "Carlos",
                            Password = "12345",
                            RoleId = 1,
                            Usuario = "carlos"
                        },
                        new
                        {
                            Id = 2,
                            IdSector = 2,
                            Nombre = "Roberto",
                            Password = "12345",
                            RoleId = 2,
                            Usuario = "roberto"
                        },
                        new
                        {
                            Id = 3,
                            IdSector = 3,
                            Nombre = "Maria",
                            Password = "12345",
                            RoleId = 3,
                            Usuario = "maria"
                        },
                        new
                        {
                            Id = 4,
                            IdSector = 5,
                            Nombre = "Juana",
                            Password = "12345",
                            RoleId = 4,
                            Usuario = "juana"
                        },
                        new
                        {
                            Id = 5,
                            IdSector = 6,
                            Nombre = "Marcelo",
                            Password = "12345",
                            RoleId = 5,
                            Usuario = "marcelo"
                        });
                });

            modelBuilder.Entity("laboratorio_web_api_istea.DAL.Models.EstadosMesa", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("EstadosMesas");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Descripcion = "Cliente esperando pedido"
                        },
                        new
                        {
                            Id = 2,
                            Descripcion = "Cliente comiendo"
                        },
                        new
                        {
                            Id = 3,
                            Descripcion = "Cliente pagando"
                        },
                        new
                        {
                            Id = 4,
                            Descripcion = "Cerrada"
                        });
                });

            modelBuilder.Entity("laboratorio_web_api_istea.DAL.Models.EstadosPedido", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("EstadosPedidos");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Descripcion = "Pendiente"
                        },
                        new
                        {
                            Id = 2,
                            Descripcion = "En preparación"
                        },
                        new
                        {
                            Id = 3,
                            Descripcion = "Listo para servir"
                        });
                });

            modelBuilder.Entity("laboratorio_web_api_istea.DAL.Models.Mesa", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("EstadosMesaId")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("EstadosMesaId");

                    b.ToTable("Mesas");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            EstadosMesaId = 4,
                            Nombre = "MESA0"
                        },
                        new
                        {
                            Id = 2,
                            EstadosMesaId = 4,
                            Nombre = "MESA1"
                        },
                        new
                        {
                            Id = 4,
                            EstadosMesaId = 4,
                            Nombre = "MESA3"
                        },
                        new
                        {
                            Id = 3,
                            EstadosMesaId = 4,
                            Nombre = "MESA2"
                        },
                        new
                        {
                            Id = 5,
                            EstadosMesaId = 4,
                            Nombre = "MESA4"
                        },
                        new
                        {
                            Id = 6,
                            EstadosMesaId = 4,
                            Nombre = "MESA5"
                        },
                        new
                        {
                            Id = 7,
                            EstadosMesaId = 4,
                            Nombre = "MESA6"
                        },
                        new
                        {
                            Id = 8,
                            EstadosMesaId = 4,
                            Nombre = "MESA7"
                        },
                        new
                        {
                            Id = 9,
                            EstadosMesaId = 4,
                            Nombre = "MESA8"
                        },
                        new
                        {
                            Id = 10,
                            EstadosMesaId = 4,
                            Nombre = "MESA9"
                        });
                });

            modelBuilder.Entity("laboratorio_web_api_istea.DAL.Models.Pedido", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Cantidad")
                        .HasColumnType("int");

                    b.Property<int>("ComandaId")
                        .HasColumnType("int");

                    b.Property<int>("EstadosPedidoId")
                        .HasColumnType("int");

                    b.Property<DateTime>("FechaCreacion")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("FechaFinalizacion")
                        .HasColumnType("datetime2");

                    b.Property<int>("ProductoId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ComandaId");

                    b.HasIndex("EstadosPedidoId");

                    b.HasIndex("ProductoId");

                    b.ToTable("Pedidos");
                });

            modelBuilder.Entity("laboratorio_web_api_istea.DAL.Models.Producto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Precio")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("SectorId")
                        .HasColumnType("int");

                    b.Property<int>("Stock")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SectorId");

                    b.ToTable("Productos");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Descripcion = "Vino Toro",
                            Precio = 1100m,
                            SectorId = 1,
                            Stock = 150
                        },
                        new
                        {
                            Id = 2,
                            Descripcion = "Fernet Branca",
                            Precio = 2000m,
                            SectorId = 1,
                            Stock = 200
                        },
                        new
                        {
                            Id = 3,
                            Descripcion = "Whisky Jack Daniels",
                            Precio = 4500m,
                            SectorId = 1,
                            Stock = 80
                        },
                        new
                        {
                            Id = 4,
                            Descripcion = "Cerveza IPA",
                            Precio = 700m,
                            SectorId = 2,
                            Stock = 300
                        },
                        new
                        {
                            Id = 5,
                            Descripcion = "Cerveza Stout",
                            Precio = 800m,
                            SectorId = 2,
                            Stock = 250
                        },
                        new
                        {
                            Id = 6,
                            Descripcion = "Cerveza APA",
                            Precio = 750m,
                            SectorId = 2,
                            Stock = 275
                        },
                        new
                        {
                            Id = 7,
                            Descripcion = "Pizza Margarita",
                            Precio = 1200m,
                            SectorId = 3,
                            Stock = 50
                        },
                        new
                        {
                            Id = 8,
                            Descripcion = "Hamburguesa Doble",
                            Precio = 1500m,
                            SectorId = 3,
                            Stock = 60
                        },
                        new
                        {
                            Id = 9,
                            Descripcion = "Sándwich de Lomito",
                            Precio = 1400m,
                            SectorId = 3,
                            Stock = 40
                        },
                        new
                        {
                            Id = 10,
                            Descripcion = "Empanadas de Carne",
                            Precio = 100m,
                            SectorId = 3,
                            Stock = 100
                        },
                        new
                        {
                            Id = 11,
                            Descripcion = "Nachos con Guacamole",
                            Precio = 500m,
                            SectorId = 3,
                            Stock = 70
                        },
                        new
                        {
                            Id = 12,
                            Descripcion = "Pochoclos",
                            Precio = 300m,
                            SectorId = 4,
                            Stock = 300
                        },
                        new
                        {
                            Id = 13,
                            Descripcion = "Gomitas Frutales",
                            Precio = 150m,
                            SectorId = 4,
                            Stock = 250
                        },
                        new
                        {
                            Id = 14,
                            Descripcion = "Alfajor Triple",
                            Precio = 180m,
                            SectorId = 4,
                            Stock = 120
                        },
                        new
                        {
                            Id = 15,
                            Descripcion = "Chocolates Milka",
                            Precio = 350m,
                            SectorId = 4,
                            Stock = 90
                        },
                        new
                        {
                            Id = 16,
                            Descripcion = "Frapuccino",
                            Precio = 1300m,
                            SectorId = 1,
                            Stock = 100
                        },
                        new
                        {
                            Id = 17,
                            Descripcion = "Vino Malbec",
                            Precio = 2300m,
                            SectorId = 1,
                            Stock = 130
                        },
                        new
                        {
                            Id = 18,
                            Descripcion = "Cerveza Porter",
                            Precio = 900m,
                            SectorId = 2,
                            Stock = 280
                        },
                        new
                        {
                            Id = 19,
                            Descripcion = "Torta de Chocolate",
                            Precio = 1600m,
                            SectorId = 3,
                            Stock = 30
                        },
                        new
                        {
                            Id = 20,
                            Descripcion = "Muffin de Arándanos",
                            Precio = 400m,
                            SectorId = 4,
                            Stock = 50
                        },
                        new
                        {
                            Id = 21,
                            Descripcion = "Milanesa a caballo",
                            Precio = 4800m,
                            SectorId = 3,
                            Stock = 40
                        },
                        new
                        {
                            Id = 22,
                            Descripcion = "Hamburguesa de garbanzo",
                            Precio = 3500m,
                            SectorId = 3,
                            Stock = 20
                        },
                        new
                        {
                            Id = 23,
                            Descripcion = "Cerveza Corona",
                            Precio = 2500m,
                            SectorId = 2,
                            Stock = 70
                        },
                        new
                        {
                            Id = 24,
                            Descripcion = "Daikiri",
                            Precio = 3700m,
                            SectorId = 1,
                            Stock = 15
                        });
                });

            modelBuilder.Entity("laboratorio_web_api_istea.DAL.Models.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Roles");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Descripcion = "Bartender"
                        },
                        new
                        {
                            Id = 2,
                            Descripcion = "Cervecero"
                        },
                        new
                        {
                            Id = 3,
                            Descripcion = "Cocinero"
                        },
                        new
                        {
                            Id = 4,
                            Descripcion = "Mozo"
                        },
                        new
                        {
                            Id = 5,
                            Descripcion = "Socio"
                        });
                });

            modelBuilder.Entity("laboratorio_web_api_istea.DAL.Models.Sectore", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Sectores");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Descripcion = "Barra de Tragos y Vinos"
                        },
                        new
                        {
                            Id = 2,
                            Descripcion = "Barra de Choperas de Cerveza Artesanal"
                        },
                        new
                        {
                            Id = 3,
                            Descripcion = "Cocina"
                        },
                        new
                        {
                            Id = 4,
                            Descripcion = "Candy Bar"
                        },
                        new
                        {
                            Id = 5,
                            Descripcion = "Mesa"
                        },
                        new
                        {
                            Id = 6,
                            Descripcion = "Administracion"
                        });
        });

            modelBuilder.Entity("laboratorio_web_api_istea.DAL.Models.Comanda", b =>
                {
                    b.HasOne("laboratorio_web_api_istea.DAL.Models.Mesa", "Mesa")
                        .WithMany()
                        .HasForeignKey("MesaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Mesa");
                });

            modelBuilder.Entity("laboratorio_web_api_istea.DAL.Models.Empleado", b =>
                {
                    b.HasOne("laboratorio_web_api_istea.DAL.Models.Sectore", "Sectore")
                        .WithMany()
                        .HasForeignKey("IdSector")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("laboratorio_web_api_istea.DAL.Models.Role", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");

                    b.Navigation("Sectore");
                });

            modelBuilder.Entity("laboratorio_web_api_istea.DAL.Models.Mesa", b =>
                {
                    b.HasOne("laboratorio_web_api_istea.DAL.Models.EstadosMesa", null)
                        .WithMany("Mesas")
                        .HasForeignKey("EstadosMesaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("laboratorio_web_api_istea.DAL.Models.Pedido", b =>
                {
                    b.HasOne("laboratorio_web_api_istea.DAL.Models.Comanda", "Comanda")
                        .WithMany("Pedidos")
                        .HasForeignKey("ComandaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("laboratorio_web_api_istea.DAL.Models.EstadosPedido", "EstadosPedido")
                        .WithMany("Pedidos")
                        .HasForeignKey("EstadosPedidoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("laboratorio_web_api_istea.DAL.Models.Producto", "Producto")
                        .WithMany("Pedidos")
                        .HasForeignKey("ProductoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Comanda");

                    b.Navigation("EstadosPedido");

                    b.Navigation("Producto");
                });

            modelBuilder.Entity("laboratorio_web_api_istea.DAL.Models.Producto", b =>
                {
                    b.HasOne("laboratorio_web_api_istea.DAL.Models.Sectore", "Sector")
                        .WithMany()
                        .HasForeignKey("SectorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Sector");
                });

            modelBuilder.Entity("laboratorio_web_api_istea.DAL.Models.Comanda", b =>
                {
                    b.Navigation("Pedidos");
                });

            modelBuilder.Entity("laboratorio_web_api_istea.DAL.Models.EstadosMesa", b =>
                {
                    b.Navigation("Mesas");
                });

            modelBuilder.Entity("laboratorio_web_api_istea.DAL.Models.EstadosPedido", b =>
                {
                    b.Navigation("Pedidos");
                });

            modelBuilder.Entity("laboratorio_web_api_istea.DAL.Models.Producto", b =>
                {
                    b.Navigation("Pedidos");
                });
#pragma warning restore 612, 618
        }
    }
}
