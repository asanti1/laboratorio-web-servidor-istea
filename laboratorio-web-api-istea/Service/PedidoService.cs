using laboratorio_web_api_istea.DAL.Models;
using laboratorio_web_api_istea.Service.Interface;

namespace laboratorio_web_api_istea.Service;

public class PedidoService : IPedidoService
{
    public Task<List<Pedido>> GetPedidos()
    {
        throw new NotImplementedException();
    }

    public Task<List<Pedido>> GetPedidosPorSector(string sector)
    {
        throw new NotImplementedException();
    }

    public Task<List<Pedido>> GetPedidosNoEntregadosATiempo()
    {
        throw new NotImplementedException();
    }

    public Task<List<Pedido>> GetMenosPedido()
    {
        throw new NotImplementedException();
    }

    public Task<List<Pedido>> GetMasPedido()
    {
        throw new NotImplementedException();
    }

    public Task<Pedido> GetPedidoPorId(int id)
    {
        throw new NotImplementedException();
    }

    public Task<Pedido> CambiarEstadoPedido(int id, string estado)
    {
        throw new NotImplementedException();
    }

    public Task<Pedido> AddPedido(Pedido pedido)
    {
        throw new NotImplementedException();
    }
}