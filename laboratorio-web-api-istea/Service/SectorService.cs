using AutoMapper;
using laboratorio_web_api_istea.DAL.Models;
using laboratorio_web_api_istea.DAL;
using laboratorio_web_api_istea.DTO.Sector;
using laboratorio_web_api_istea.Service.Interface;
using laboratorio_web_api_istea.DTO.Pedido;

public class SectorService : ISectorService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public SectorService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<List<OperacionesPorSectorDTO>> GetOperacionesPorSector(string sectorDescripcion)
    {
        var operacionesPorSectorEmpleado = await _unitOfWork.SectorRepository.GetOperacionesPorSector(sectorDescripcion);
        return _mapper.Map<List<OperacionesPorSectorDTO>>(operacionesPorSectorEmpleado);
    }

    // Método para obtener la cantidad de operaciones por empleado
    private async Task<int> ObtenerCantidadDeOperacionesPorEmpleado(Sectore sector)
    {
        // Obtén todos los empleados relacionados con el sector desde el repositorio de empleados
        var empleados = await _unitOfWork.EmpleadoRepository.GetAll();

        // Filtra los empleados que pertenecen al sector específico
        var empleadosPorSector = empleados.Where(e => e.IdSector == sector.Id).ToList();

        // Devuelve la cantidad de empleados en ese sector
        return empleadosPorSector.Count;
    }


    public async Task<List<OperacionesPorSectorYEmpleadoDTO>> GetOperacionesPorSectorPorEmpleado()
    {
        var operacionesPorSectorEmpleado = await _unitOfWork.SectorRepository.GetOperacionesPorSectorPorEmpleado();
        return _mapper.Map<List<OperacionesPorSectorYEmpleadoDTO>>(operacionesPorSectorEmpleado);
    }

    public async Task<List<OperacionesPorSectorPorEmpleadoDTO>> GetOperacionesPorSectorPorEmpleado(string sectorDescripcion)
    {
        var operacionesPorSectorEmpleado = await _unitOfWork.SectorRepository.GetOperacionesPorSectorPorEmpleado(sectorDescripcion);
        return _mapper.Map<List<OperacionesPorSectorPorEmpleadoDTO>>(operacionesPorSectorEmpleado);
    }

}