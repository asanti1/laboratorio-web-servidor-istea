using laboratorio_web_api_istea.DAL.Enum;
using laboratorio_web_api_istea.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace laboratorio_web_api_istea.DAL.DataSeed;

public class RolesSeed : IEntityTypeConfiguration<Role>
{
    public void Configure(EntityTypeBuilder<Role> builder)
    {
        builder.HasData(
            new Role() { Id = 1, Descripcion = RolesUsuarioEnum.Bartender.ToString() },
            new Role() { Id = 2, Descripcion = RolesUsuarioEnum.Cervecero.ToString() },
            new Role() { Id = 3, Descripcion = RolesUsuarioEnum.Cocinero.ToString() },
            new Role() { Id = 4, Descripcion = RolesUsuarioEnum.Mozo.ToString() },
            new Role() { Id = 5, Descripcion = RolesUsuarioEnum.Socio.ToString() }
        );
    }
}