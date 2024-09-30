using AutoMapper;
using laboratorio_web_api_istea.DAL.Models;
using laboratorio_web_api_istea.DAL.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace laboratorio_web_api_istea.DAL.Repository
{
    public class EmpleadoRepository : Repository<Empleado>, IEmpleadoRepository
    {
        private readonly RestauranteContext _context;
        private readonly IMapper _mapper;

        public EmpleadoRepository(RestauranteContext context, IMapper mapper) : base(context)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Empleado> AddEmpleado(Empleado empleado)
        {
            _context.Empleados.Add(empleado);
            await _context.SaveChangesAsync();
            return empleado;
        }

        public async Task BorrarEmpleado(int empleadoId)
        {
            var empleado = await _context.Empleados.FindAsync(empleadoId);
            if (empleado == null) throw new Exception("Empleado no encontrado");

            _context.Empleados.Remove(empleado);
            await _context.SaveChangesAsync();
        }


        public async Task<Empleado> Update(Empleado emp)
        {
            // Buscar el empleado en la base de datos
            var empleado = await _context.Empleados.FindAsync(emp.Id);
            if (empleado == null)
                throw new Exception("No se encontró esa entidad de empleado.");

            // Verificar si el sector existe en la base de datos
            var sector = await _context.Sectores.FindAsync(emp.IdSector);
            if (sector == null)
                throw new Exception("No se encontró el sector con ese ID.");

            // Verificar si el rol existe en la base de datos
            var role = await _context.Roles.FindAsync(emp.RoleId);
            if (role == null)
                throw new Exception("No se encontró el rol con ese ID.");

            // Actualizar las propiedades del empleado
            empleado.Nombre = emp.Nombre;
            empleado.IdSector = emp.IdSector;
            empleado.RoleId = emp.RoleId;

            // Guardar los cambios en la base de datos
            await _context.SaveChangesAsync();

            return empleado;
        }


        public Task<List<Empleado>> GetAllEmpleados()
        {
            return _context.Empleados
                .Include(e => e.Sectore)
                .Include(e => e.Role)
                .ToListAsync();
        }

        public Task<Empleado?> GetEmpleadoById(int id)
        {
            return _context.Empleados
                .Include(e => e.Sectore)
                .Include(e => e.Role)
                .Where(e => e.Id == id)
                .FirstOrDefaultAsync();
        }

        public Task<Empleado?> GetEmpleadoByUsuario(string usuario)
        {
            return _context.Empleados
                .Include(e => e.Sectore)
                .Include(e => e.Role)
                .Where(e => e.Usuario == usuario)
                .FirstOrDefaultAsync();
        }

        public async Task RegistrarLogin(int empleadoId)
        {
            var registroEmpleado = new RegistroEmpleados();
            registroEmpleado.IdEmpleado = empleadoId;
            registroEmpleado.FechaHora= DateTime.Now;

            _context.RegistroEmpleados.Add(registroEmpleado);
            await _context.SaveChangesAsync();
        }
    }
}