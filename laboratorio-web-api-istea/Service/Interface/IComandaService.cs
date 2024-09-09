using laboratorio_web_api_istea.DAL.Models;
using laboratorio_web_api_istea.DTO.Comanda;

namespace laboratorio_web_api_istea.Service.Interface;

public interface IComandaService
{
    Task<Comanda> Get(int idComanda);
    Task<Comanda> Add(ComandaPostDTO comanda);
    Task<Comanda> Update(int idComanda, Comanda comanda);
    Task<bool> Delete(int idComanda);
    Task<ComandaGetDTO> ObtenerComandaPorId(int idComanda);
}