using AutoMapper;
using laboratorio_web_api_istea.DAL.Models;
using laboratorio_web_api_istea.DTO.Pedido;
using laboratorio_web_api_istea.DTO.Sector;

namespace laboratorio_web_api_istea.Mappers
{
    public class SectorMapper : Profile
    {
        public SectorMapper()
        {
            CreateMap<OperacionesPorSectorPorEmpleado, OperacionesPorSectorPorEmpleadoDTO>()
               .ForMember(src => src.CantidadPedidos, emp => emp.MapFrom(src => src.CantidadPedidos))
               .ForMember(src => src.NombreEmpleado, emp => emp.MapFrom(src => src.NombreEmpleado));

            CreateMap<OperacionesPorSectorYEmpleado, OperacionesPorSectorYEmpleadoDTO>()
               .ForMember(src => src.CantidadPedidos, emp => emp.MapFrom(src => src.CantidadPedidos))
               .ForMember(src => src.NombreEmpleado, emp => emp.MapFrom(src => src.NombreEmpleado))
               .ForMember(src => src.SectorDescripcion, emp => emp.MapFrom(src => src.SectorDescripcion));

            CreateMap<OperacionesPorSector, OperacionesPorSectorDTO>()
                .ForMember(src => src.CantidadPedidos, emp => emp.MapFrom(src => src.CantidadPedidos))
                .ForMember(src => src.NombreSector, emp => emp.MapFrom(src => src.NombreSector));
        }
    }
}
