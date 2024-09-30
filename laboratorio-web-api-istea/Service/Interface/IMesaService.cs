using laboratorio_web_api_istea.DAL.Models;
using laboratorio_web_api_istea.DTO.Mesa;

namespace laboratorio_web_api_istea.Service.Interface;

public interface IMesaService
{
    Task<List<MesaResponseDTO>> GetMesas();

    Task CerrarMesa(string idMesa);

}