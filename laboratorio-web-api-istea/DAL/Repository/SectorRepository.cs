using laboratorio_web_api_istea.DAL.Models;
using laboratorio_web_api_istea.DAL.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace laboratorio_web_api_istea.DAL.Repository
{
    public class SectorRepository : Repository<Sectore>, ISectorRepository
    {
        public SectorRepository(RestauranteContext context) : base(context)
        {
        }

        async Task<Sectore> ISectorRepository.GetSectorByDescription(string description)
        {
            try
            {
                var newSector = await _context.Sectores
                    .FirstOrDefaultAsync(s => s.Descripcion == description);

                return newSector;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        async Task<List<OperacionesPorSector>> ISectorRepository.GetOperacionesPorSector(string description)
        {
            try
            {
                var resultado = await _context.Pedidos
                 .Join(_context.Productos, pe => pe.ProductoId, pr => pr.Id, (pe, pr) => new { Pedido = pe, Producto = pr })
                 .Join(_context.Sectores, combined => combined.Producto.SectorId, s => s.Id, (combined, sector) => new { combined.Pedido, combined.Producto, Sector = sector })
                 .Join(_context.Empleados, combined => combined.Producto.SectorId, e => e.SectorId, (combined, empleado) => new { combined.Pedido, combined.Producto, combined.Sector, Empleado = empleado })
                 .Join(_context.EstadosPedidos, combined => combined.Pedido.EstadosPedidoId, ep => ep.Id, (combined, estadoPedido) => new { combined.Pedido, combined.Producto, combined.Sector, combined.Empleado, EstadoPedido = estadoPedido })
                 .GroupBy(g => g.Sector.Descripcion) // Agrupar por la descripción del sector
                 .Select(group => new OperacionesPorSector
                 {
                     NombreSector = group.Key,
                     CantidadPedidos = group.Count() // Contar la cantidad de pedidos
                 })
                 .ToListAsync();

                return resultado;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        async Task<List<OperacionesPorSectorPorEmpleado>> ISectorRepository.GetOperacionesPorSectorPorEmpleado(string descriptionSector)
        {
            try
            {
                var resultado = await _context.Pedidos
                    .Where(pe => pe.Producto.Sector.Descripcion.Contains(descriptionSector)) // Filtro por la descripción del sector
                    .Join(_context.Productos, pe => pe.ProductoId, pr => pr.Id, (pe, pr) => new { Pedido = pe, Producto = pr })
                    .Join(_context.Empleados, combined => combined.Producto.SectorId, e => e.SectorId, (combined, empleado) => new { combined.Pedido, Empleado = empleado })
                    .Join(_context.EstadosPedidos, combined => combined.Pedido.EstadosPedidoId, ep => ep.Id, (combined, estadoPedido) => new { combined.Pedido, combined.Empleado, EstadoPedido = estadoPedido })
                    .GroupBy(g => g.Empleado.Nombre)
                    .Select(group => new OperacionesPorSectorPorEmpleado
                    {
                        NombreEmpleado = group.Key,
                        CantidadPedidos = group.Count()
                    })
                    .ToListAsync();

                return resultado;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        async Task<List<OperacionesPorSectorYEmpleado>> ISectorRepository.GetOperacionesPorSectorPorEmpleado()
        {
            try
            {
                var resultado = await _context.Pedidos
                    .Join(_context.Productos, pe => pe.ProductoId, pr => pr.Id, (pe, pr) => new { Pedido = pe, Producto = pr })
                    .Join(_context.Sectores, combined => combined.Producto.SectorId, s => s.Id, (combined, sector) => new { combined.Pedido, combined.Producto, Sector = sector })
                    .Join(_context.Empleados, combined => combined.Producto.SectorId, e => e.SectorId, (combined, empleado) => new { combined.Pedido, combined.Producto, combined.Sector, Empleado = empleado })
                    .Join(_context.EstadosPedidos, combined => combined.Pedido.EstadosPedidoId, ep => ep.Id, (combined, estadoPedido) => new { combined.Pedido, combined.Producto, combined.Sector, combined.Empleado, EstadoPedido = estadoPedido })
                    .GroupBy(g => new { g.Sector.Descripcion, g.Empleado.Nombre }) // Agrupar por sector y empleado
                    .Select(group => new OperacionesPorSectorYEmpleado
                    {
                        SectorDescripcion = group.Key.Descripcion,
                        NombreEmpleado = group.Key.Nombre,
                        CantidadPedidos = group.Count() // Contar la cantidad de pedidos
                    })
                    .ToListAsync();

                return resultado;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

    }
}