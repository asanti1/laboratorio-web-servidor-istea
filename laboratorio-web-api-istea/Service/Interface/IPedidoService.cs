using laboratorio_web_api_istea.DAL.Models;
using laboratorio_web_api_istea.DTO.Pedido;

namespace laboratorio_web_api_istea.Service.Interface;

public interface IPedidoService
{
    Task<List<Pedido>> GetPedidos();
    Task<List<Pedido>> GetPedidosPorSector(string sector);
    Task<List<Pedido>> GetPedidosNoEntregadosATiempo();
    Task<List<Pedido>> GetMenosPedido();
    Task<List<Pedido>> GetMasPedido();
    Task<Pedido> GetPedidoPorId(int id);
    Task<Pedido> CambiarEstadoPedido(int id, int estado);
    Task<Pedido> AddPedido(PedidoPostDTO pedido);
}