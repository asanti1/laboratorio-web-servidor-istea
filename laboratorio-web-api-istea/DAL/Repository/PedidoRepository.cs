using laboratorio_web_api_istea.DAL.Models;
using laboratorio_web_api_istea.DAL.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace laboratorio_web_api_istea.DAL.Repository
{
    public class PedidoRepository : Repository<Pedido>, IPedidoRepository
    {
        public PedidoRepository(RestauranteContext context) : base(context)
        {
         
        }

        async Task<List<Pedido>> IPedidoRepository.GetPedidoByEstado(int idEstado)
        {
            try
            {
                return await _context.Pedidos.Where(p => p.IdEstado == idEstado).ToListAsync();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        async Task<List<Pedido>> IPedidoRepository.GetMenosPedido()
        {
            return await _context.Pedidos
                .GroupBy(p => p.IdProducto)
                .OrderBy(g => g.Count())
                .Select(g => g.First())
                .ToListAsync();
        }

        async Task<List<Pedido>> IPedidoRepository.GetMasPedido()
        {
            return await _context.Pedidos
                .GroupBy(p => p.IdProducto)
                .OrderByDescending(g => g.Count())
                .Select(g => g.First())
                .ToListAsync();
        }

        async Task<List<Pedido>> IPedidoRepository.GetPedidosBySector(Sectore sector)
        {
            try
            {
                var pedidos = await _context.Pedidos
                .Where(p => sector.Productos.Any(pr => pr.IdProducto == p.IdProducto))
                .ToListAsync();

                return pedidos;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
