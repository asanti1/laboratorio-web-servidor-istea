using laboratorio_web_api_istea.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace laboratorio_web_api_istea.DAL.DataSeed;

public class MesaSeed : IEntityTypeConfiguration<Mesa>
{
    public void Configure(EntityTypeBuilder<Mesa> builder)
    {
        builder.HasData(
            new Mesa() { Id = 1, Nombre = "MESA0", EstadosMesaId = 4 },
            new Mesa() { Id = 2, Nombre = "MESA1", EstadosMesaId = 4 },
            new Mesa() { Id = 4, Nombre = "MESA3", EstadosMesaId = 4 },
            new Mesa() { Id = 3, Nombre = "MESA2", EstadosMesaId = 4 },
            new Mesa() { Id = 5, Nombre = "MESA4", EstadosMesaId = 4 },
            new Mesa() { Id = 6, Nombre = "MESA5", EstadosMesaId = 4 },
            new Mesa() { Id = 7, Nombre = "MESA6", EstadosMesaId = 4 },
            new Mesa() { Id = 8, Nombre = "MESA7", EstadosMesaId = 4 },
            new Mesa() { Id = 9, Nombre = "MESA8", EstadosMesaId = 4 },
            new Mesa() { Id = 10, Nombre = "MESA9", EstadosMesaId = 4 }
        );
    }
}