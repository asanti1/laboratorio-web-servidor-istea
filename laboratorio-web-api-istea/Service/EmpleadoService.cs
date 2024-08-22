using laboratorio_web_api_istea.DAL.Models;
using laboratorio_web_api_istea.DTO.Empleado;
using laboratorio_web_api_istea.Service.Interface;

namespace laboratorio_web_api_istea.Service;

//TODO: Capa repositorio con o sin unit of work TBD.
public class EmpleadoService : IEmpleadoService
{
    public async Task<List<Empleado>> GetAll()
    {
        throw new NotImplementedException();
    }

    public async Task<Empleado> Get(int empleadoId)
    {
        throw new NotImplementedException();
    }

    public async Task<Empleado> Add(Empleado empleado)
    {
        throw new NotImplementedException();
    }

    public async Task<Empleado> Update(int id, Empleado empleado)
    {
        throw new NotImplementedException();
    }

    public async Task<Empleado> Delete(int empleadoId)
    {
        throw new NotImplementedException();
    }

    public async Task<HorariosIngresoSistemaDTO> GetHorariosIngresoSistema(int empleadoId, DateTime fechaInicio,
        DateTime fechaFin = new DateTime())
    {
        throw new NotImplementedException();
    }

    public async Task<OperacionesPorEmpleadoDTO> GetOperacionesPorEmpleado()
    {
        throw new NotImplementedException();
    }
}