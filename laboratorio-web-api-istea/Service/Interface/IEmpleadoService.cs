using laboratorio_web_api_istea.DAL.Models;
using laboratorio_web_api_istea.DTO.Empleado;

namespace laboratorio_web_api_istea.Service.Interface;

public interface IEmpleadoService
{
    Task<List<EmpleadoResponseDTO>> GetAll();
    Task<EmpleadoResponseDTO> Get(int empleadoId);
    Task<EmpleadoResponseDTO> Add(EmpleadoRequestDTO empleado);
    Task<EmpleadoResponseDTO> Update(int id, EmpleadoRequestDTO empleado);
    Task Delete(int empleadoId);

    Task<HorariosIngresoSistemaDTO> GetHorariosIngresoSistema(int empleadoId, DateTime fechaInicio,
        DateTime fechaFin = new DateTime());

    Task<OperacionesPorEmpleadoDTO> GetOperacionesPorEmpleado();
    Task<EmpleadoResponseDTO?> GetEmpleadoByUsuarioPass(string user, string pass);
}