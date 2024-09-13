using AutoMapper;
using laboratorio_web_api_istea.DAL.Models;
using laboratorio_web_api_istea.DTO.Pedido;

namespace laboratorio_web_api_istea;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<PedidoPostDTO, Pedido>();
    }
}