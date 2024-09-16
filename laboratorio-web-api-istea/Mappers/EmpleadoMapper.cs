using AutoMapper;
using laboratorio_web_api_istea.DAL.Models;
using laboratorio_web_api_istea.DTO.Empleado;
using laboratorio_web_api_istea.DTO.Pedido;

namespace laboratorio_web_api_istea.Mappers;

public class EmpleadoMapper : Profile
{
    public EmpleadoMapper()
    {
        CreateMap<Empleado, EmpleadoResponseDTO>()
            .ForMember(src => src.Id, emp => emp.MapFrom(src => src.Id))
            .ForMember(src => src.Nombre, emp => emp.MapFrom(src => src.Nombre))
            .ForMember(src => src.Usuario, emp => emp.MapFrom(src => src.Usuario))
            .ForMember(src => src.Sector, emp => emp.MapFrom(src => src.Sectore.Descripcion))
            .ForMember(src => src.Rol, emp => emp.MapFrom(src => src.Role.Descripcion));
        CreateMap<EmpleadoRequestDTO, Empleado>()
            .ForMember(src => src.Nombre, emp => emp.MapFrom(src => src.Nombre))
            .ForMember(src => src.Usuario, emp => emp.MapFrom(src => src.Usuario))
            .ForMember(src => src.RoleId, emp => emp.MapFrom(src => src.RoleId))
            .ForMember(src => src.IdSector, emp => emp.MapFrom(src => src.IdSector));
    }
}