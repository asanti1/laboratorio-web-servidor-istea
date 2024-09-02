using laboratorio_web_api_istea.DAL;
using laboratorio_web_api_istea.DAL.Models;
using laboratorio_web_api_istea.Service.Interface;
using Microsoft.EntityFrameworkCore;

namespace laboratorio_web_api_istea.Service;

public class ComandaService : IComandaService
{
    private readonly RestauranteContext _context;

    public ComandaService(RestauranteContext context)
    {
        _context = context;
    }

    public async Task<Comanda> Get(int idComanda)
    {
        var comanda = await _context.Comandas
                                    .FirstOrDefaultAsync(c => c.IdComanda == idComanda);
        if (comanda == null)
        {
            throw new KeyNotFoundException($"No se encontró una comanda con el ID {idComanda}");
        }

        return comanda;
    }

    public async Task<Comanda> Add(Comanda comanda)
    {
        throw new NotImplementedException();
    }

    public async Task<Comanda> Update(int idComanda, Comanda comanda)
    {
        throw new NotImplementedException();
    }

    public async Task<Comanda> Delete(int idComanda)
    {
        throw new NotImplementedException();
    }
}