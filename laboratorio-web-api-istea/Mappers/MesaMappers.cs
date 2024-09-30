using AutoMapper;
using laboratorio_web_api_istea.DAL.Models;
using laboratorio_web_api_istea.DTO.Mesa;
namespace laboratorio_web_api_istea.Mappers;
public class MesaMapper : Profile
{
    public MesaMapper()
    {
        CreateMap<Mesa, MesaResponseDTO>()
            .ForMember(dest => dest.Nombre, opt => opt.MapFrom(src => src.Nombre))
            .ForMember(dest => dest.EstadoDescripcion, opt => opt.MapFrom(src => src.EstadosMesa.Descripcion));
    }
}