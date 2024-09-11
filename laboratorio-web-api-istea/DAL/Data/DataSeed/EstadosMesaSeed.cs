using laboratorio_web_api_istea.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace laboratorio_web_api_istea.DAL.DataSeed;

public class EstadosMesaSeed : IEntityTypeConfiguration<EstadosMesa>
{
    public void Configure(EntityTypeBuilder<EstadosMesa> builder)
    {
        builder.HasData(
            new EstadosMesa() { Id = 1, Descripcion = "Cliente esperando pedido" },
            new EstadosMesa() { Id = 2, Descripcion = "Cliente comiendo" },
            new EstadosMesa() { Id = 3, Descripcion = "Cliente pagando" },
            new EstadosMesa() { Id = 4, Descripcion = "Cerrada" }
        );
    }
}