using laboratorio_web_api_istea.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace laboratorio_web_api_istea.DAL.DataSeed;

public class EstadosPedidosSeed : IEntityTypeConfiguration<EstadosPedido>
{
    public void Configure(EntityTypeBuilder<EstadosPedido> builder)
    {
        builder.HasData(
            new EstadosPedido() { Id = 1, Descripcion = "Pendiente" },
            new EstadosPedido() { Id = 2, Descripcion = "En preparación" },
            new EstadosPedido() { Id = 3, Descripcion = "Listo para servir" }
        );
    }
}