using laboratorio_web_api_istea.DAL.Models;
using laboratorio_web_api_istea.DAL.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace laboratorio_web_api_istea.DAL.Repository
{
    public class EmpleadoRepository : Repository<Empleado>, IEmpleadoRepository
    {
        protected readonly RestauranteContext context;

        public EmpleadoRepository(RestauranteContext context) : base(context)
        {
            this.context = context;
        }

        public Task<List<Empleado>> GetAllEmpleados()
        {
            return context.Empleados
                    .Include(e => e.Sectore)
                    .Include(e => e.Role)
                    .ToListAsync();
        }

        public Task<Empleado> GetEmpleadoById(int id)
        {
            return context.Empleados
            .Include(e => e.Sectore)
            .Include(e => e.Role)
            .Where(e => e.Id == id)
            .FirstOrDefaultAsync();
        }
    }
}
