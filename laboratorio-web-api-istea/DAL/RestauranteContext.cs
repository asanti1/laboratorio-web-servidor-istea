using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using laboratorio_web_api_istea.DAL.Models;

namespace laboratorio_web_api_istea.DAL;

public partial class RestauranteContext : DbContext
{
    public RestauranteContext()
    {
    }

    public RestauranteContext(DbContextOptions<RestauranteContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Comanda> Comandas { get; set; }

    public virtual DbSet<Empleado> Empleados { get; set; }

    public virtual DbSet<EstadosMesa> EstadosMesas { get; set; }

    public virtual DbSet<EstadosPedido> EstadosPedidos { get; set; }

    public virtual DbSet<Mesa> Mesas { get; set; }

    public virtual DbSet<Pedido> Pedidos { get; set; }

    public virtual DbSet<Producto> Productos { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Sectore> Sectores { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=DESKTOP-MIB1G7Q;Database=Restaurante;Trusted_Connection=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Comanda>(entity =>
        {
            entity.HasKey(e => e.IdComanda).HasName("PK__comandas__6D6D170D8EE45A48");

            entity.ToTable("comandas");

            entity.Property(e => e.IdComanda).HasColumnName("id_comanda");
            entity.Property(e => e.IdMesa).HasColumnName("id_mesa");
            entity.Property(e => e.NombreCliente)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("nombre_cliente");

            entity.HasOne(d => d.IdMesaNavigation).WithMany(p => p.Comanda)
                .HasForeignKey(d => d.IdMesa)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__comandas__id_mes__6A30C649");
        });

        modelBuilder.Entity<Empleado>(entity =>
        {
            entity.HasKey(e => e.IdEmpleado).HasName("PK__empleado__88B51394BA44895C");

            entity.ToTable("empleados");

            entity.Property(e => e.IdEmpleado).HasColumnName("id_empleado");
            entity.Property(e => e.IdRol).HasColumnName("id_rol");
            entity.Property(e => e.IdSector).HasColumnName("id_sector");
            entity.Property(e => e.Nombre)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(e => e.Password)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("password");
            entity.Property(e => e.Usuario)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("usuario");

            entity.HasOne(d => d.IdRolNavigation).WithMany(p => p.Empleados)
                .HasForeignKey(d => d.IdRol)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__empleados__id_ro__5FB337D6");

            entity.HasOne(d => d.IdSectorNavigation).WithMany(p => p.Empleados)
                .HasForeignKey(d => d.IdSector)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__empleados__id_se__5EBF139D");
        });

        modelBuilder.Entity<EstadosMesa>(entity =>
        {
            entity.HasKey(e => e.IdEstado).HasName("PK__estados___86989FB25DC000DA");

            entity.ToTable("estados_mesas");

            entity.Property(e => e.IdEstado).HasColumnName("id_estado");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("descripcion");
        });

        modelBuilder.Entity<EstadosPedido>(entity =>
        {
            entity.HasKey(e => e.IdEstado).HasName("PK__estados___86989FB22B850469");

            entity.ToTable("estados_pedidos");

            entity.Property(e => e.IdEstado).HasColumnName("id_estado");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("descripcion");
        });

        modelBuilder.Entity<Mesa>(entity =>
        {
            entity.HasKey(e => e.IdMesa).HasName("PK__mesas__68A1E159EA69519A");

            entity.ToTable("mesas");

            entity.Property(e => e.IdMesa).HasColumnName("id_mesa");
            entity.Property(e => e.IdEstado).HasColumnName("id_estado");
            entity.Property(e => e.Nombre)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("nombre");

            entity.HasOne(d => d.IdEstadoNavigation).WithMany(p => p.Mesas)
                .HasForeignKey(d => d.IdEstado)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__mesas__id_estado__6754599E");
        });

        modelBuilder.Entity<Pedido>(entity =>
        {
            entity.HasKey(e => e.IdPedido).HasName("PK__pedidos__6FF014893198D858");

            entity.ToTable("pedidos");

            entity.Property(e => e.IdPedido).HasColumnName("id_pedido");
            entity.Property(e => e.Cantidad).HasColumnName("cantidad");
            entity.Property(e => e.FechaCreacion)
                .HasColumnType("datetime")
                .HasColumnName("fecha_creacion");
            entity.Property(e => e.FechaFinalizacion)
                .HasColumnType("datetime")
                .HasColumnName("fecha_finalizacion");
            entity.Property(e => e.IdComanda).HasColumnName("id_comanda");
            entity.Property(e => e.IdEstado).HasColumnName("id_estado");
            entity.Property(e => e.IdProducto).HasColumnName("id_producto");

            entity.HasOne(d => d.IdComandaNavigation).WithMany(p => p.Pedidos)
                .HasForeignKey(d => d.IdComanda)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__pedidos__id_coma__6EF57B66");

            entity.HasOne(d => d.IdEstadoNavigation).WithMany(p => p.Pedidos)
                .HasForeignKey(d => d.IdEstado)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__pedidos__id_esta__70DDC3D8");

            entity.HasOne(d => d.IdProductoNavigation).WithMany(p => p.Pedidos)
                .HasForeignKey(d => d.IdProducto)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__pedidos__id_prod__6FE99F9F");
        });

        modelBuilder.Entity<Producto>(entity =>
        {
            entity.HasKey(e => e.IdProducto).HasName("PK__producto__FF341C0DBCB8AC7D");

            entity.ToTable("productos");

            entity.Property(e => e.IdProducto).HasColumnName("id_producto");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("descripcion");
            entity.Property(e => e.IdSector).HasColumnName("id_sector");
            entity.Property(e => e.Precio)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("precio");
            entity.Property(e => e.Stock).HasColumnName("stock");

            entity.HasOne(d => d.IdSectorNavigation).WithMany(p => p.Productos)
                .HasForeignKey(d => d.IdSector)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__productos__id_se__628FA481");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.IdRol).HasName("PK__roles__6ABCB5E0F0DBB297");

            entity.ToTable("roles");

            entity.Property(e => e.IdRol).HasColumnName("id_rol");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("descripcion");
        });

        modelBuilder.Entity<Sectore>(entity =>
        {
            entity.HasKey(e => e.IdSector).HasName("PK__sectores__3483C369F5575B44");

            entity.ToTable("sectores");

            entity.Property(e => e.IdSector).HasColumnName("id_sector");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("descripcion");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
