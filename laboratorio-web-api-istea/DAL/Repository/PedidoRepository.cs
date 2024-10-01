using AutoMapper;
using laboratorio_web_api_istea.DAL.Enum;
using laboratorio_web_api_istea.DAL.Models;
using laboratorio_web_api_istea.DAL.Repository.Interfaces;
using laboratorio_web_api_istea.DTO.Pedido;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http.HttpResults;
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

        public async Task<List<Pedido>> GetPedidosListos() {
            try
            {
                return await _context.Pedidos
                .Where(p => p.EstadosPedidoId == (int) EstadoPedidoEnum.LISTO_PARA_SERVIR)
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
            try
            {
                var pedidos = await _context.Pedidos
                    .Include(p => p.EstadosPedido)
                    .Include(p => p.Comanda)
                        .ThenInclude(c => c.Mesa)
                    .Include(p => p.Producto)
                    .GroupBy(p => p.ProductoId)
                    .OrderBy(g => g.Count())
                    .Select(g => g.First())
                    .ToListAsync();

                return pedidos;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<List<Pedido>> GetMasPedido()
        {
            try
            {
                // obtengo los pedidos agrupados y ordenados por la cantidad de productos, incluyendo las relaciones necesarias
                var pedidos = await _context.Pedidos
                    .Include(p => p.EstadosPedido)
                    .Include(p => p.Comanda)
                        .ThenInclude(c => c.Mesa)
                    .Include(p => p.Producto)
                    .GroupBy(p => p.ProductoId)
                    .OrderByDescending(g => g.Count()) // Ordenamos por los productos más pedidos
                    .Select(g => g.First()) // Seleccionamos el primer pedido de cada grupo
                    .ToListAsync();



                return pedidos;
            }
            catch (Exception ex)
            {
                return null;
            }
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

        public async Task<Pedido> GetPedidoPorId(int idPedido)
        {
            try
            {
                var pedidos = await _context.Pedidos
                .Where(p => p.Id == idPedido)
                .Include(p => p.EstadosPedido)
                .Include(p => p.Comanda)
                 .ThenInclude(c => c.Mesa)
                .Include(p => p.Producto)
                .FirstOrDefaultAsync();

                return pedidos;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<Pedido> CambiarEstadoPedido(int idPedido, string sector, int estado)
        {
            var pedido = await _context.Pedidos
            .Include(p => p.Comanda)
            .ThenInclude(c => c.Mesa)
            .Include(p => p.Producto)
            .ThenInclude(pr => pr.Sector)
            .Include(p => p.EstadosPedido)
            .FirstOrDefaultAsync(p => p.Id == idPedido);

            if (pedido == null)
            {
                throw new KeyNotFoundException("Order not found.");
            }

            if(pedido.Producto.Sector.Descripcion != sector)
            {
                throw new UnauthorizedAccessException("You are not authorized to change this order.");
            }

            // Cambiar el estado del pedido
            pedido.EstadosPedidoId = estado;
            if(estado == (int)EstadoPedidoEnum.LISTO_PARA_SERVIR)
            {
                pedido.FechaFinalizacion = DateTime.Now;
            }

            await _context.SaveChangesAsync();

            pedido = await this.GetPedidoPorId(idPedido);

            return pedido; // Devuelve el Pedido
        }

        public async Task<Pedido> AddPedido(Pedido pedido)
        {
            try
            {
                // Verificamos si la comanda existe
                var comanda = await _context.Comandas.FindAsync(pedido.ComandaId);
                if (comanda == null) throw new Exception($"Comanda not found with id: {pedido.ComandaId}");

                // Verificamos si el producto existe
                var producto = await _context.Productos.FindAsync(pedido.ProductoId);
                if (producto == null) throw new Exception($"Producto not found with id: {pedido.ProductoId}");

                // Verificamos si el estado del pedido existe
                var estadoPedido = await _context.EstadosPedidos.FindAsync(pedido.EstadosPedidoId);
                if (estadoPedido == null) throw new Exception($"EstadoPedido not found with id: {pedido.EstadosPedidoId}");

                // Creamos el nuevo pedido
                Pedido nuevoPedido = new Pedido()
                {
                    EstadosPedidoId = pedido.EstadosPedidoId,
                    ProductoId = pedido.ProductoId,
                    Cantidad = pedido.Cantidad,
                    FechaCreacion = DateTime.Now,
                    FechaFinalizacion = pedido.FechaFinalizacion,
                    ComandaId = comanda.Id,
                };

                _context.Pedidos.Add(nuevoPedido);
                await _context.SaveChangesAsync();
                return nuevoPedido;
            }
            catch (Exception ex)
            {
                // Logueamos el error para poder identificar qué está fallando
                Console.WriteLine($"Error: {ex.Message}");
                throw new ApplicationException("An error occurred while adding a new order.");
            }
        }
    }
}