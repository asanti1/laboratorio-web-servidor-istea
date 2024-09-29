using laboratorio_web_api_istea.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace laboratorio_web_api_istea.DAL.DataSeed;

public class EmpleadoSeed : IEntityTypeConfiguration<Empleado>
{
    public void Configure(EntityTypeBuilder<Empleado> builder)
    {
        builder.HasData(
            new Empleado()
                { Id = 1, RoleId = 1, Nombre = "Carlos", Password = "12345", IdSector = 1, Usuario = "carlos" },
            new Empleado()
                { Id = 2, RoleId = 2, Nombre = "Roberto", Password = "12345", IdSector = 2, Usuario = "roberto" },
            new Empleado() { Id = 3, RoleId = 3, Nombre = "Maria", Password = "12345", IdSector = 3, Usuario = "maria" },
            new Empleado() { Id = 4, RoleId = 4, Nombre = "Juana", Password = "12345", IdSector = 5, Usuario = "juana" },
            new Empleado()
                { Id = 5, RoleId = 5, Nombre = "Marcelo", Password = "12345", IdSector = 6, Usuario = "marcelo" }
        );
    }
}