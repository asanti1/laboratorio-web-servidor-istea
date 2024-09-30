using laboratorio_web_api_istea.DAL.Models;
namespace laboratorio_web_api_istea.DAL.Repository.Interfaces;
public interface IMesaRepository
{
    Task<List<Mesa>> GetMesas();
    Task CerrarMesa(string nombreMesa);
    Task CambiarEstado(string nombreMesa, int idEstado);
}