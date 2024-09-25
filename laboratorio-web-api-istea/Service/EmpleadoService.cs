using AutoMapper;
using laboratorio_web_api_istea.DAL;
using laboratorio_web_api_istea.DAL.Models;
using laboratorio_web_api_istea.DTO.Empleado;
using laboratorio_web_api_istea.Service.Interface;

namespace laboratorio_web_api_istea.Service;

public class EmpleadoService : IEmpleadoService

{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public EmpleadoService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<List<EmpleadoResponseDTO>> GetAll()
    {
        try
        {
            var _empleados = await _unitOfWork.EmpleadoRepository.GetAllEmpleados();

            return _mapper.Map<List<EmpleadoResponseDTO>>(_empleados);
        }
        catch
        {
            throw new ApplicationException("An error occurred while retrieving employees.");
        }
    }

    public async Task<EmpleadoResponseDTO> Get(int empleadoId)
    {
        try
        {
            var empleado = await _unitOfWork.EmpleadoRepository.GetEmpleadoById(empleadoId);

            if (empleado == null)
            {
                // Optionally, throw an exception or return null if not found
                throw new KeyNotFoundException($"No se encontró un empleado con el ID {empleadoId}");
            }

            //Transformamos Empleado a EmpleadoResponseDTO
            var _empleadoDTO = new EmpleadoResponseDTO
            {
                Id = empleado.Id,
                Nombre = empleado.Nombre,
                Usuario = empleado.Usuario,
                Sector = empleado.Sectore.Descripcion,
                Rol = empleado.Role.Descripcion
            };

            return _empleadoDTO;
        }
        catch (Exception ex)
        {
            // Optionally log the exception
            // _logger.LogError(ex, "An error occurred while retrieving the employee.");

            throw new ApplicationException("An error occurred while retrieving the employee.", ex);
        }
    }

    public async Task<EmpleadoResponseDTO> Add(EmpleadoRequestDTO emp)
    {
        try
        {
            var empleado = _mapper.Map<Empleado>(emp);
            var existeEmpleado = await _unitOfWork.EmpleadoRepository.GetEmpleadoByUsuario(emp.Usuario);

            if(existeEmpleado != null)
            {
                throw new ApplicationException("El usuario del empleado ya existe");
            }

            empleado = await _unitOfWork.EmpleadoRepository.AddEmpleado(empleado);
            return _mapper.Map<EmpleadoResponseDTO>(empleado);
        }
        catch (Exception ex)
        {
            throw new ApplicationException("An error occurred while adding the employee.", ex);
        }
    }

    public async Task<EmpleadoResponseDTO> Update(int id, EmpleadoUpdateRequestDTO emp)
    {
        Empleado empleado = _mapper.Map<Empleado>(emp);
        empleado.Id = id;
        Empleado empleadoUpdate = await _unitOfWork.EmpleadoRepository.Update(empleado);
        return _mapper.Map<Empleado, EmpleadoResponseDTO>(empleadoUpdate);
    }

    public async Task Delete(int empleadoId)
    {
        await _unitOfWork.EmpleadoRepository.BorrarEmpleado(empleadoId);
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

    public async Task<EmpleadoResponseDTO?> GetEmpleadoByUsuarioPass(string user, string pass)
    {
        var empleado = await _unitOfWork.EmpleadoRepository.GetEmpleadoByUsuario(user);
        if (empleado == null)
        {
            //Usuario No Existe
            return null;
        }
        else if (empleado.Password != pass)
        {
            //Pass erroneo
            return null;
        }

        return _mapper.Map<EmpleadoResponseDTO>(empleado); ;
    }
}