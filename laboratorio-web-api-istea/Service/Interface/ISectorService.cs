using laboratorio_web_api_istea.DTO.Sector;

namespace laboratorio_web_api_istea.Service.Interface;

public interface ISectorService
{
    Task<OperacionesPorSectorDTO> GetOperacionesPorSector();
    
    Task<OperacionesPorSectorPorEmpleadoDTO> GetOperacionesPorSectorPorEmpleado();
}