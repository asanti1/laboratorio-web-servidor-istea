using laboratorio_web_api_istea.DAL.Models;
using laboratorio_web_api_istea.DTO.Comanda;

namespace laboratorio_web_api_istea.DAL.Repository.Interfaces
{
    public interface IComandaRepository : IRepository<Comanda>
    {
        public Task<ComandaGetDTO> ObtenerComandaPorId(int idComanda);
        public Task<Comanda> AgregarComanda(ComandaPostDTO comanda);
    }
}