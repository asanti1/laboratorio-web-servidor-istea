using laboratorio_web_api_istea.DAL.Models;
using laboratorio_web_api_istea.DAL.Repository.Interfaces;
using laboratorio_web_api_istea.DTO.Comanda;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

namespace laboratorio_web_api_istea.DAL.Repository
{
    public class ComandaRepository : Repository<Comanda>, IComandaRepository
    {
        public ComandaRepository(RestauranteContext context) : base(context)
        {

        }

        public async Task<ComandaGetDTO> ObtenerComandaPorId(int idComanda)
        {
            var comandaDto = await _context.Comandas
                .Include(c => c.Pedidos)
                .ThenInclude(p => p.IdProductoNavigation)
                .ThenInclude(p => p.IdSectorNavigation)
                .Where(c => c.IdComanda == idComanda)
                .Select(c => new ComandaGetDTO
                {
                    NombreCliente = c.NombreCliente,
                    NombreMesa = c.IdMesaNavigation.Nombre,
                    Productos = c.Pedidos.Select(p => new PedidoEnComandaGetDTO
                    {
                        NombreProducto = p.IdProductoNavigation.Descripcion,
                        Precio = p.IdProductoNavigation.Precio.ToString("F2"),
                        Sector = p.IdProductoNavigation.IdSectorNavigation.Descripcion
                    }).ToList()
                })
                .FirstOrDefaultAsync();
        return comandaDto;
        }
        
        public async Task<Comanda> AgregarComanda(ComandaPostDTO comanda)
        {
            Comanda nuevaComanda = new Comanda()
            {
                NombreCliente = comanda.NombreCliente,
                IdMesa = comanda.IdMesa,
            };
            _context.Add(nuevaComanda);
            await _context.SaveChangesAsync();

            return nuevaComanda;
        }
    }
}
