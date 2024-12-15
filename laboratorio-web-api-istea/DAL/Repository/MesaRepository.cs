using laboratorio_web_api_istea.DAL.Models;
using laboratorio_web_api_istea.DAL.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
namespace laboratorio_web_api_istea.DAL.Repository;
public class MesaRepository : Repository<Mesa>, IMesaRepository
{
    public MesaRepository(RestauranteContext context) : base(context)
    {
    }
    public async Task<List<Mesa>> GetMesas()
    {
        var mesas = await _context.Mesas
            .Include(m => m.EstadosMesa)
            .ToListAsync();
        return mesas;
    }
    public async Task CerrarMesa(string nombreMesa)
    {
        var mesa = await _context.Mesas.FirstOrDefaultAsync(m => m.Nombre == nombreMesa);
        if (mesa == null)
        {
            throw new Exception($"La mesa {nombreMesa} no existe");
        }
       else
        {
            var estadoCerrada = await _context.EstadosMesas.FirstOrDefaultAsync(e => e.Descripcion == "Cerrada");
            if (estadoCerrada != null)
            {
                mesa.EstadosMesaId = estadoCerrada.Id;
                await _context.SaveChangesAsync();
            }
        }    
       
    }

    public async Task CambiarEstado(string nombreMesa, int idEstado)
    {
        
            //Obtengo la mesa a la cual quiero cambiar el estado
            var mesa = await _context.Mesas.FirstOrDefaultAsync(m => m.Nombre == nombreMesa);
            if (mesa == null)
            {
                throw new Exception($"La mesa {nombreMesa} no existe");
            }
            else
            {
                //Si existe le cambio el estado. 
                mesa.EstadosMesaId = idEstado;
                await _context.SaveChangesAsync();
            }
        
    }
}