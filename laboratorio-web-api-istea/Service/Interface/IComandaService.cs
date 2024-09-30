using laboratorio_web_api_istea.DAL.Models;
using laboratorio_web_api_istea.DTO.Comanda;

namespace laboratorio_web_api_istea.Service.Interface
{
    public interface IComandaService
    {
        Task<Comanda> Get(int idComanda);
        Task<ComandaResponseDTO> Add(ComandaPostDTO comanda);
        Task<ComandaResponseDTO> Update(int idComanda, ComandaPostDTO comanda); 
        Task<bool> Delete(int idComanda);
        Task<ComandaResponseDTO> ObtenerComandaPorId(int idComanda);
    }
}
