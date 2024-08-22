using laboratorio_web_api_istea.DAL.Models;
using laboratorio_web_api_istea.DTO.Empleado;

namespace laboratorio_web_api_istea.Service.Interface;

public interface IEmpleadoService
{
    Task<List<Empleado>> GetAll();
    Task<Empleado> Get(int empleadoId);
    Task<Empleado> Add(Empleado empleado);
    Task<Empleado> Update(int id, Empleado empleado);
    Task<Empleado> Delete(int empleadoId);

    Task<HorariosIngresoSistemaDTO> GetHorariosIngresoSistema(int empleadoId, DateTime fechaInicio,
        DateTime fechaFin = new DateTime());
    Task<OperacionesPorEmpleadoDTO> GetOperacionesPorEmpleado();
}