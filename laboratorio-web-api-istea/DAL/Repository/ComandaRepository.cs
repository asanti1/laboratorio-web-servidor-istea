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
                .ThenInclude(p => p.Producto)
                .ThenInclude(pr => pr.Sector)
                .Include(c => c.Mesa)
                .Where(c => c.Id == idComanda)
                .Select(c => new ComandaGetDTO
                {
                    NombreCliente = c.NombreCliente,
                    NombreMesa = c.Mesa.Nombre,
                    Pedidos = c.Pedidos.Select(p => new PedidoEnComandaGetDTO
                    {
                        NombreProducto = p.Producto.Descripcion,
                        Precio = p.Producto.Precio.ToString("F2"),
                        Sector = p.Producto.Sector.Descripcion
                    }).ToList()
                })
                .FirstOrDefaultAsync();

            if (comandaDto == null)
            {
                throw new KeyNotFoundException($"No se encontró una comanda con el ID {idComanda}");
            }

            return comandaDto;
        }

        public async Task<Comanda> AgregarComanda(ComandaPostDTO comanda)
        {
            Comanda nuevaComanda = new Comanda()
            {
                NombreCliente = comanda.NombreCliente,
                MesaId = comanda.IdMesa,
            };
            _context.Add(nuevaComanda);
            await _context.SaveChangesAsync();

            return nuevaComanda;
        }
    }
}