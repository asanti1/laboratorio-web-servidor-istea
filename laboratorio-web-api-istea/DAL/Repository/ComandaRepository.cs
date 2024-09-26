using laboratorio_web_api_istea.DAL.Models;
using laboratorio_web_api_istea.DAL.Repository.Interfaces;
using laboratorio_web_api_istea.DTO.Comanda;
using Microsoft.EntityFrameworkCore;

namespace laboratorio_web_api_istea.DAL.Repository
{
    public class ComandaRepository : Repository<Comanda>, IComandaRepository
    {
        public ComandaRepository(RestauranteContext context) : base(context)
        {
        }

        public async Task<Comanda> ObtenerComandaPorId(int idComanda)
        {
            var comandaDto = await _context.Comandas
                .Include(c => c.Pedidos)
                    .ThenInclude(z => z.EstadosPedido)
                .Include(c => c.Pedidos)
                    .ThenInclude(p => p.Producto)
                    .ThenInclude(x => x.Sector)
                .Include(c => c.Mesa)
                .FirstOrDefaultAsync(c => c.Id == idComanda);

            if (comandaDto == null)
            {
                throw new KeyNotFoundException($"No se encontró una comanda con el ID {idComanda}");
            }

            return comandaDto;
        }

        public async Task<Comanda> AgregarComanda(ComandaPostDTO comanda)
        {
            // Creamos una nueva comanda
            Comanda nuevaComanda = new Comanda
            {
                NombreCliente = comanda.NombreCliente,
                MesaId = comanda.IdMesa,
            };

            // Agregamos la nueva comanda al contexto
            _context.Add(nuevaComanda);

            // Guardamos cambios
            await _context.SaveChangesAsync();

            // Cargamos las propiedades relacionadas (Mesa y Pedidos) desde la base de datos
            await _context.Entry(nuevaComanda)
                .Reference(c => c.Mesa)          // Cargamos la relación con Mesa
                .LoadAsync();

            await _context.Entry(nuevaComanda)
                .Collection(c => c.Pedidos)      // Cargamos la colección de Pedidos
                .LoadAsync();

            return nuevaComanda;
        }

        public async Task<Comanda> ActualizarComanda(Comanda comanda)
        {
            // Verificamos si la comanda existe en el contexto
            var comandaExistente = await _context.Comandas.FindAsync(comanda.Id);
            if (comandaExistente == null)
            {
                throw new KeyNotFoundException($"No se encontró una comanda con el ID {comanda.Id}");
            }

            // Actualizamos las propiedades
            comandaExistente.NombreCliente = comanda.NombreCliente;
            comandaExistente.MesaId = comanda.MesaId;

            // Guardamos los cambios
            await _context.SaveChangesAsync();

            // Cargamos las propiedades relacionadas si es necesario
            await _context.Entry(comandaExistente)
                .Reference(c => c.Mesa)
                .LoadAsync();

            await _context.Entry(comandaExistente)
                .Collection(c => c.Pedidos)
                .LoadAsync();

            return comandaExistente;
        }
    }
}
