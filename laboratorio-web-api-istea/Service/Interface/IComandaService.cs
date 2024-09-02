using laboratorio_web_api_istea.DAL.Models;

namespace laboratorio_web_api_istea.Service.Interface;

public interface IComandaService
{
    Task<Comanda> Get(int idComanda);
    Task<Comanda> Add(Comanda comanda);
    Task<Comanda> Update(int idComanda, Comanda comanda);
    Task<bool> Delete(int idComanda);
}