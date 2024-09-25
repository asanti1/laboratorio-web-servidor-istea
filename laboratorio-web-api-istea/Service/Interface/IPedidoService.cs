using laboratorio_web_api_istea.DAL.Models;
using laboratorio_web_api_istea.DTO.Pedido;

namespace laboratorio_web_api_istea.Service.Interface;

public interface IPedidoService
{
    Task<List<PedidoResponseDTO>> GetPedidos();
    Task<List<PedidoResponseDTO>> GetPedidosPorSector(string sector);
    Task<List<PedidoResponseDTO>> GetPedidosNoEntregadosATiempo();
    Task<List<PedidoResponseDTO>> GetMenosPedido();
    Task<List<PedidoResponseDTO>> GetMasPedido();
    Task<PedidoResponseDTO> GetPedidoPorId(int id);
    Task<PedidoResponseDTO> CambiarEstadoPedido(int id, int estado);
    Task<Pedido> AddPedido(PedidoPostDTO pedido);
}