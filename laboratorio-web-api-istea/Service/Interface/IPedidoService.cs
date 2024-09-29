using laboratorio_web_api_istea.DAL.Models;
using laboratorio_web_api_istea.DTO.Pedido;

namespace laboratorio_web_api_istea.Service.Interface;

public interface IPedidoService
{
    Task<List<PedidoResponseDTO>> GetPedidos();
    Task<List<PedidoResponseDTO>> GetPedidosPorSector(string sector);

    Task<List<PedidoResponseDTO>> GetPedidosListos();
    
    Task<List<PedidoResponseDTO>> GetPedidosPorRol(string rol);
    Task<List<PedidoResponseDTO>> GetPedidosNoEntregadosATiempo();
    Task<List<PedidoResponseDTO>> GetMenosPedido();
    Task<List<PedidoResponseDTO>> GetMasPedido();
    Task<PedidoResponseDTO> GetPedidoPorId(int id);
    Task<PedidoResponseDTO> CambiarEstadoPedido(int id, string sector, int estado);
    Task<Pedido> AddPedido(PedidoPostDTO pedido);

    string ObtenerSectorPorRol(string userRole);
}