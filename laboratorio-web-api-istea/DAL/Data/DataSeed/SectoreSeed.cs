using laboratorio_web_api_istea.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace laboratorio_web_api_istea.DAL.DataSeed;

public class SectoreSeed : IEntityTypeConfiguration<Sectore>
{
    public void Configure(EntityTypeBuilder<Sectore> builder)
    {
        builder.HasData(
            new Sectore() { Id = 1, Descripcion = "Barra de Tragos y Vinos" },
            new Sectore() { Id = 2, Descripcion = "Barra de Choperas de Cerveza Artesanal" },
            new Sectore() { Id = 3, Descripcion = "Cocina" },
            new Sectore() { Id = 4, Descripcion = "Candy Bar" },
            new Sectore() { Id = 5, Descripcion = "Mesa" },
            new Sectore() { Id = 6, Descripcion = "Administracion" }
        );
    }
}