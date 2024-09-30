using laboratorio_web_api_istea.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace laboratorio_web_api_istea.DAL.DataSeed;

public class ProductosSeed : IEntityTypeConfiguration<Producto>
{
    public void Configure(EntityTypeBuilder<Producto> builder)
    {
        builder.HasData(
            new Producto() { Id = 1, Descripcion = "Vino Toro", Stock = 150, SectorId = 1, Precio = 1100 },
            new Producto() { Id = 2, Descripcion = "Fernet Branca", Stock = 200, SectorId = 1, Precio = 2000 },
            new Producto() { Id = 3, Descripcion = "Whisky Jack Daniels", Stock = 80, SectorId = 1, Precio = 4500 },
            new Producto() { Id = 4, Descripcion = "Cerveza IPA", Stock = 300, SectorId = 2, Precio = 700 },
            new Producto() { Id = 5, Descripcion = "Cerveza Stout", Stock = 250, SectorId = 2, Precio = 800 },
            new Producto() { Id = 6, Descripcion = "Cerveza APA", Stock = 275, SectorId = 2, Precio = 750 },
            new Producto() { Id = 7, Descripcion = "Pizza Margarita", Stock = 50, SectorId = 3, Precio = 1200 },
            new Producto() { Id = 8, Descripcion = "Hamburguesa Doble", Stock = 60, SectorId = 3, Precio = 1500 },
            new Producto() { Id = 9, Descripcion = "Sándwich de Lomito", Stock = 40, SectorId = 3, Precio = 1400 },
            new Producto() { Id = 10, Descripcion = "Empanadas de Carne", Stock = 100, SectorId = 3, Precio = 100 },
            new Producto() { Id = 11, Descripcion = "Nachos con Guacamole", Stock = 70, SectorId = 3, Precio = 500 },
            new Producto() { Id = 12, Descripcion = "Pochoclos", Stock = 300, SectorId = 4, Precio = 300 },
            new Producto() { Id = 13, Descripcion = "Gomitas Frutales", Stock = 250, SectorId = 4, Precio = 150 },
            new Producto() { Id = 14, Descripcion = "Alfajor Triple", Stock = 120, SectorId = 4, Precio = 180 },
            new Producto() { Id = 15, Descripcion = "Chocolates Milka", Stock = 90, SectorId = 4, Precio = 350 },
            new Producto() { Id = 16, Descripcion = "Frapuccino", Stock = 100, SectorId = 1, Precio = 1300 },
            new Producto() { Id = 17, Descripcion = "Vino Malbec", Stock = 130, SectorId = 1, Precio = 2300 },
            new Producto() { Id = 18, Descripcion = "Cerveza Porter", Stock = 280, SectorId = 2, Precio = 900 },
            new Producto() { Id = 19, Descripcion = "Torta de Chocolate", Stock = 30, SectorId = 3, Precio = 1600 },
            new Producto() { Id = 20, Descripcion = "Muffin de Arándanos", Stock = 50, SectorId = 4, Precio = 400 },
            new Producto() { Id = 21, Descripcion = "Milanesa a caballo", Stock = 40, SectorId = 3, Precio = 4800 },
            new Producto() { Id = 22, Descripcion = "Hamburguesa de garbanzo", Stock = 20, SectorId = 3, Precio = 3500 },
            new Producto() { Id = 23, Descripcion = "Cerveza Corona", Stock = 70, SectorId = 2, Precio = 2500 },
            new Producto() { Id = 24, Descripcion = "Daikiri", Stock = 15, SectorId = 1, Precio = 3700 }
        );
    }
}