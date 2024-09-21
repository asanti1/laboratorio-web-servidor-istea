using laboratorio_web_api_istea.DAL.Models;

namespace laboratorio_web_api_istea.DAL.Repository.Interfaces
{
    public interface IEmpleadoRepository : IRepository<Empleado>
    {
        Task<List<Empleado>> GetAllEmpleados();
        Task<Empleado?> GetEmpleadoById(int id);

        Task<Empleado> Update(Empleado emp);
        Task<Empleado> AddEmpleado(Empleado empleado);
        Task BorrarEmpleado(int empleadoId);
        Task<Empleado> GetEmpleadoByUsuario(string usuario);
    }
}