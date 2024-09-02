using laboratorio_web_api_istea.DAL;
using laboratorio_web_api_istea.DAL.Models;
using laboratorio_web_api_istea.Service.Interface;
using Microsoft.EntityFrameworkCore;

namespace laboratorio_web_api_istea.Service;

public class PedidoService : IPedidoService
{
    private readonly RestauranteContext _context;
    public PedidoService(RestauranteContext context)
    {
        _context = context;
    }
    public async Task<List<Pedido>> GetPedidos()
    {
        try
        {
            return await _context.Pedidos.ToListAsync();
        }
        catch
        {
            throw new ApplicationException("An error occurred while retrieving employees.");
        }
    }

    public async Task<List<Pedido>> GetPedidosPorSector(string sector)
    {
        try {
            // Retrieve the sector by its description
           var newSector = await _context.Sectores
            .Include(s => s.Empleados)  // Assuming you need to include employees
            .Include(s => s.Productos)  // Assuming you need to include products
            .FirstOrDefaultAsync(s => s.Descripcion == sector);

        if (newSector == null)
        {
            // Handle the case where the sector is not found
            return new List<Pedido>(); // or throw an exception depending on your requirements
        }

        // Retrieve pedidos associated with the sector
        var pedidos = await _context.Pedidos
            .Where(p => newSector.Productos.Any(pr => pr.IdProducto == p.IdProducto))
            .ToListAsync();

        return pedidos;
    }
    catch (Exception ex)
    {
        // Optionally log the exception
        // _logger.LogError(ex, "An error occurred while retrieving pedidos by sector.");

        throw new ApplicationException("An error occurred while retrieving pedidos by sector.", ex);
    }
}
    
    public async Task<List<Pedido>> GetPedidosNoEntregadosATiempo()
    {
        try
        {
            return await _context.Pedidos
                .Where(p => p.IdEstado == 2)
                .ToListAsync();
        }
        catch
        {
            throw new ApplicationException("An error occurred while retrieving orders.");
        }
    }

    public async Task<List<Pedido>> GetMenosPedido()
    {
        try
        {
            return await _context.Pedidos
                .GroupBy(p => p.IdProducto)
                .OrderBy(g => g.Count())
                .Select(g => g.First())
                .ToListAsync();
        }
        catch
        {
            throw new ApplicationException("An error occurred while retrieving the least ordered products.");
        }
    }

    public async Task<List<Pedido>> GetMasPedido()
    {
        try
        {
            return await _context.Pedidos
                .GroupBy(p => p.IdProducto)
                .OrderByDescending(g => g.Count())
                .Select(g => g.First())
                .ToListAsync();
        }
        catch
        {
            throw new ApplicationException("An error occurred while retrieving the most ordered products.");
        }
    }

    public async Task<Pedido> GetPedidoPorId(int id)
    {
        try
        {
            if (id != null)
            {
                return await _context.Pedidos
               .FirstOrDefaultAsync(p => p.IdPedido == id);
            }
            throw new Exception("El id no puede ser nulo4"); 
        }
        catch
        {
            throw new ApplicationException("An error occurred while retrieving the order by ID.");
        }
    }

    public async Task<Pedido> CambiarEstadoPedido(int id, string estado)
    {
        try { 
           
            var pedido = await _context.Pedidos
                .FirstOrDefaultAsync(p => p.IdPedido == id);

            if (pedido == null)
            {
                throw new KeyNotFoundException("Order not found.");
            }

            pedido.IdEstado =Convert.ToInt16(estado);

            _context.Pedidos.Update(pedido);
            await _context.SaveChangesAsync();

            return pedido;
        } 
        catch
        {
            throw new ApplicationException("An error occurred while changing the order status.");
        }
    }

    public async Task<Pedido> AddPedido(Pedido pedido)
    {
        try
        {
            _context.Pedidos.Add(pedido);
            await _context.SaveChangesAsync();

            return pedido;
        }
        catch
        {
            throw new ApplicationException("An error occurred while adding a new order.");
        }
    }
}