using laboratorio_web_api_istea.DAL.Models;
using laboratorio_web_api_istea.DTO.Pedido;

namespace laboratorio_web_api_istea.DAL.Repository.Interfaces
{
    public interface IPedidoRepository : IRepository<Pedido>
    {
        Task<List<Pedido>> GetPedidoByEstado(int idEstado);
        Task<List<Pedido>> GetAllPedidos();        
        Task<List<Pedido>> GetMenosPedido();
        Task<List<Pedido>> GetMasPedido();
        Task<List<Pedido>> GetPedidosBySector(Sectore sector);
        Task<Pedido> AddPedido(Pedido pedido);
        Task<PedidoResponseDTO> CambiarEstadoPedido(int idPedido, int estado);

    }
}
