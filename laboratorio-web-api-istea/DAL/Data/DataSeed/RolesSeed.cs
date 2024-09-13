using laboratorio_web_api_istea.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace laboratorio_web_api_istea.DAL.DataSeed;

public class RolesSeed : IEntityTypeConfiguration<Role>
{
    public void Configure(EntityTypeBuilder<Role> builder)
    {
        builder.HasData(
            new Role() { Id = 1, Descripcion = "Bartender" },
            new Role() { Id = 2, Descripcion = "Cervecero" },
            new Role() { Id = 3, Descripcion = "Cocinero" },
            new Role() { Id = 4, Descripcion = "Mozo" },
            new Role() { Id = 5, Descripcion = "Socio" }
        );
    }
}