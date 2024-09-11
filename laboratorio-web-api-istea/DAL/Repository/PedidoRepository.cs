using laboratorio_web_api_istea.DAL.Models;
using laboratorio_web_api_istea.DAL.Repository.Interfaces;
using laboratorio_web_api_istea.DTO.Pedido;
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
                return await _context.Pedidos.Where(p => p.EstadosPedidoId == idEstado).ToListAsync();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        async Task<List<Pedido>> IPedidoRepository.GetMenosPedido()
        {
            return await _context.Pedidos
                .GroupBy(p => p.ProductoId)
                .OrderBy(g => g.Count())
                .Select(g => g.First())
                .ToListAsync();
        }

        async Task<List<Pedido>> IPedidoRepository.GetMasPedido()
        {
            return await _context.Pedidos
                .GroupBy(p => p.ProductoId)
                .OrderByDescending(g => g.Count())
                .Select(g => g.First())
                .ToListAsync();
        }

        async Task<List<Pedido>> IPedidoRepository.GetPedidosBySector(Sectore sector)
        {
            try
            {
                var pedidos = await _context.Pedidos
                    .Where(pedido => sector.Productos.Any(producto => producto.Id == pedido.ProductoId))
                    .ToListAsync();

                return pedidos;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        async Task<Pedido> IPedidoRepository.CambiarEstadoPedido(int idPedido, int estado)
        {
            try
            {
                Pedido pedido = await _context.Pedidos.FindAsync(idPedido);

                if (pedido == null) throw new KeyNotFoundException("Order not found.");

                pedido.EstadosPedidoId = estado;

                var result = await _context.SaveChangesAsync();

                return pedido;
            }
            catch
            {
                throw new ApplicationException("An error occurred while changing the order status.");
            }
        }

        async Task<Pedido> IPedidoRepository.AddPedido(PedidoPostDTO pedido)
        {
            try
            {
                var comanda = await _context.Comandas.FindAsync(pedido.IdComanda);
                Console.WriteLine("here");
                if (comanda == null) throw new Exception("Comanda not found with id: " + pedido.IdComanda);
                Pedido nuevoPedido = new Pedido()
                {
                    EstadosPedidoId = pedido.IdEstado,
                    ProductoId = pedido.IdProducto,
                    Cantidad = pedido.Cantidad,
                    FechaCreacion = DateTime.Now,
                    FechaFinalizacion = pedido.FechaFinalizacion,
                    ComandaId = comanda.Id,
                };

                _context.Add(nuevoPedido);
                await _context.SaveChangesAsync();
                return nuevoPedido;
            }
            catch
            {
                throw new ApplicationException("An error occurred while adding a new order.");
            }
        }
    }
}