using System;
using System.Collections.Generic;
using laboratorio_web_api_istea.DAL.DataSeed;
using Microsoft.EntityFrameworkCore;
using laboratorio_web_api_istea.DAL.Models;

namespace laboratorio_web_api_istea.DAL;

public class RestauranteContext : DbContext
{
    public RestauranteContext()
    {
    }

    public RestauranteContext(DbContextOptions<RestauranteContext> options)
        : base(options)
    {
    }

    public DbSet<EstadosPedido> EstadosPedidos { get; set; }
    public DbSet<EstadosMesa> EstadosMesas { get; set; }
    public DbSet<Comanda> Comandas { get; set; }
    public DbSet<Empleado> Empleados { get; set; }
    public DbSet<Mesa> Mesas { get; set; }
    public DbSet<Pedido> Pedidos { get; set; }
    public DbSet<Producto> Productos { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<Sectore> Sectores { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new EstadosMesaSeed());
        modelBuilder.ApplyConfiguration(new EstadosPedidosSeed());
        modelBuilder.ApplyConfiguration(new SectoreSeed());
        modelBuilder.ApplyConfiguration(new MesaSeed());
        modelBuilder.ApplyConfiguration(new ProductosSeed());
        modelBuilder.ApplyConfiguration(new RolesSeed());
        modelBuilder.ApplyConfiguration(new EmpleadoSeed());
    }
}