using laboratorio_web_api_istea.DAL.Models;
using laboratorio_web_api_istea.DAL.Repository.Interfaces;

namespace laboratorio_web_api_istea.DAL.Repository
{
    public class EmpleadoRepository : Repository<Empleado>, IEmpleadoRepository
    {
        public EmpleadoRepository(RestauranteContext context) : base(context)
        {
            
        }
    }
}
