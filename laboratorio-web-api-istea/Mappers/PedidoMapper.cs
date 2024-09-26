using AutoMapper;
using laboratorio_web_api_istea.DAL.Models;
using laboratorio_web_api_istea.DTO.Empleado;
using laboratorio_web_api_istea.DTO.Pedido;

namespace laboratorio_web_api_istea.Mappers;

public class PedidoMapper : Profile
{
    public PedidoMapper()
    {
        CreateMap<Pedido, PedidoResponseDTO>()
            .ForMember(src => src.Producto, emp => emp.MapFrom(src => src.Producto.Descripcion))
            .ForMember(src => src.ProductoId, emp => emp.MapFrom(src => src.Producto.Id))
            .ForMember(src => src.Id, emp => emp.MapFrom(src => src.Id))
            .ForMember(src => src.Cantidad, emp => emp.MapFrom(src => src.Cantidad))
            .ForMember(src => src.Mesa, emp => emp.MapFrom(src => src.Comanda.Mesa.Nombre))
            .ForMember(src => src.NombreCliente, emp => emp.MapFrom(src => src.Comanda.NombreCliente))
            .ForMember(src => src.EstadosPedido, emp => emp.MapFrom(src => src.EstadosPedido.Descripcion))
            .ForMember(src => src.FechaCreacion, emp => emp.MapFrom(src => src.FechaCreacion))
            .ForMember(src => src.FechaFinalizacion, emp => emp.MapFrom(src => src.FechaFinalizacion));

        CreateMap<PedidoPostDTO, Pedido>()
           .ForMember(src => src.Cantidad, emp => emp.MapFrom(src => src.Cantidad))
           .ForMember(src => src.ProductoId, emp => emp.MapFrom(src => src.IdProducto))
           .ForMember(src => src.ComandaId, emp => emp.MapFrom(src => src.IdComanda))
           .ForMember(src => src.EstadosPedidoId, emp => emp.MapFrom(src => src.IdEstado))
           .ForMember(src => src.FechaCreacion, emp => emp.MapFrom(src => src.FechaCreacion))
           .ForMember(src => src.FechaFinalizacion, emp => emp.MapFrom(src => src.FechaFinalizacion));
    }
}
