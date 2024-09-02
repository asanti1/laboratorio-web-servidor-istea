using laboratorio_web_api_istea.DAL;
using laboratorio_web_api_istea.DTO.Sector;
using laboratorio_web_api_istea.Service.Interface;

namespace laboratorio_web_api_istea.Service;

public class SectorService : ISectorService
{
    private readonly IUnitOfWork _unitOfWork;
    public SectorService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<OperacionesPorSectorDTO> GetOperacionesPorSector()
    {
        throw new NotImplementedException();
    }

    public async Task<OperacionesPorSectorPorEmpleadoDTO> GetOperacionesPorSectorPorEmpleado()
    {
        throw new NotImplementedException();
    }
}