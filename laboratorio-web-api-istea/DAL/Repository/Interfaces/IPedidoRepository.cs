using laboratorio_web_api_istea.DAL.Models;

namespace laboratorio_web_api_istea.DAL.Repository.Interfaces
{
    public interface IPedidoRepository : IRepository<Pedido>
    {
        Task<List<Pedido>> GetPedidoByEstado(int idEstado);
        Task<List<Pedido>> GetMenosPedido();
        Task<List<Pedido>> GetMasPedido();
        Task<List<Pedido>> GetPedidosBySector(Sectore sector);

    }
}
