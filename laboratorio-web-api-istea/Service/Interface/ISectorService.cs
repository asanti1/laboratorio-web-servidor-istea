using laboratorio_web_api_istea.DTO.Sector;

namespace laboratorio_web_api_istea.Service.Interface;

public interface ISectorService
{
    Task<List<OperacionesPorSectorDTO>> GetOperacionesPorSector(string sectorDescripcion);

    Task<List<OperacionesPorSectorYEmpleadoDTO>> GetOperacionesPorSectorPorEmpleado();
    Task<List<OperacionesPorSectorPorEmpleadoDTO>> GetOperacionesPorSectorPorEmpleado(string sectorDescripcion);
}