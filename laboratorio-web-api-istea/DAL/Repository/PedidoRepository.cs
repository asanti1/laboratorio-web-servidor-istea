using AutoMapper;
using laboratorio_web_api_istea.DAL.Models;
using laboratorio_web_api_istea.DAL.Repository.Interfaces;
using laboratorio_web_api_istea.DTO.Pedido;
using Microsoft.EntityFrameworkCore;

namespace laboratorio_web_api_istea.DAL.Repository
{
    public class PedidoRepository : Repository<Pedido>, IPedidoRepository
    {
        private readonly RestauranteContext _context;
        private readonly IMapper _mapper;

        public PedidoRepository(RestauranteContext context, IMapper mapper) : base(context)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<Pedido>> GetAllPedidos()
        {
            try
            {
                return await _context.Pedidos
                .Include(p => p.EstadosPedido)
                .Include(p => p.Comanda)
                 .ThenInclude(c => c.Mesa)
                .Include(p => p.Producto)
                .ToListAsync();
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public async Task<List<Pedido>> GetPedidoByEstado(int idEstado)
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

        public async Task<List<Pedido>> GetMenosPedido()
        {
            return await _context.Pedidos
                .GroupBy(p => p.ProductoId)
                .OrderBy(g => g.Count())
                .Select(g => g.First())
                .ToListAsync();
        }

        public async Task<List<Pedido>> GetMasPedido()
        {
            return await _context.Pedidos
                .GroupBy(p => p.ProductoId)
                .OrderByDescending(g => g.Count())
                .Select(g => g.First())
                .ToListAsync();
        }


        public async Task<List<Pedido>> GetPedidosBySector(Sectore sector)
        {
            try
            {
                var pedidos = await _context.Pedidos
                .Where(p => p.Producto.SectorId == sector.Id)
                .Include(p => p.EstadosPedido)
                .Include(p => p.Comanda)
                 .ThenInclude(c => c.Mesa)
                .Include(p => p.Producto)
                .ToListAsync();

                return pedidos;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<PedidoResponseDTO> CambiarEstadoPedido(int idPedido, int estado)
        {
            try
            {
                var pedido = await _context.Pedidos
                    .Include(p => p.Producto)
                    .Include(p => p.Comanda)
                    .ThenInclude(c => c.Mesa)
                    .Include(p => p.EstadosPedido)
                    .FirstOrDefaultAsync(p => p.Id == idPedido);

                if (pedido == null)
                {
                    throw new KeyNotFoundException("Order not found.");
                }

                // Cambiar el estado del pedido
                pedido.EstadosPedidoId = estado;

                await _context.SaveChangesAsync();

                // Mapear el pedido actualizado a PedidoResponseDTO
                var pedidoDto = _mapper.Map<PedidoResponseDTO>(pedido);

                return pedidoDto; // Devuelve el PedidoResponseDTO
            }
            catch (Exception ex)
            {
                throw new ApplicationException("An error occurred while changing the order status.", ex);
            }
        }


        public async Task<Pedido> AddPedido(Pedido pedido)
        {
            try
            {
                var comanda = await _context.Comandas.FindAsync(pedido.ComandaId);
                Console.WriteLine("here");
                if (comanda == null) throw new Exception("Comanda not found with id: " + pedido.ComandaId);
                Pedido nuevoPedido = new Pedido()
                {
                    EstadosPedidoId = pedido.EstadosPedidoId,
                    ProductoId = pedido.ProductoId,
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