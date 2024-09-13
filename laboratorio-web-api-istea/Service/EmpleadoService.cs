using laboratorio_web_api_istea.DAL;
using laboratorio_web_api_istea.DAL.Models;
using laboratorio_web_api_istea.DTO.Empleado;
using laboratorio_web_api_istea.Service.Interface;
using Microsoft.EntityFrameworkCore;

namespace laboratorio_web_api_istea.Service;

//TODO: Capa repositorio con o sin unit of work TBD.
public class EmpleadoService : IEmpleadoService
    
{
    private readonly IUnitOfWork _unitOfWork;
    public EmpleadoService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public async Task<List<EmpleadoResponseDTO>> GetAll()
    {
        try
        {
            var _empleados = await _unitOfWork.EmpleadoRepository.GetAllEmpleados();
             
            var _empleadosDTO = _empleados.Select(empleado => new EmpleadoResponseDTO
            {
                Id = empleado.Id,
                Nombre = empleado.Nombre,
                Usuario = empleado.Usuario,
                Sector = empleado.Sectore.Descripcion,
                Rol = empleado.Role.Descripcion
            }).ToList();

            return _empleadosDTO;
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

    public async Task<EmpleadoResponseDTO> Add(EmpleadoRequestDTO empleado)
    {
        try
        {
            var _empleado = new Empleado
            {
                Nombre = empleado.Nombre,
                Usuario = empleado.Usuario,
                Password = empleado.Password,
                IdSector = empleado.IdSector,
                RoleId = empleado.RoleId
            };
            await _unitOfWork.EmpleadoRepository.Add(_empleado);
            await _unitOfWork.Save();  // Save the changes to the database

            return await Get(_empleado.Id);

        }
        catch (Exception ex)
        {
            // Optionally log the exception
            // _logger.LogError(ex, "An error occurred while adding the employee.");

            throw new ApplicationException("An error occurred while adding the employee.", ex);
        }
    }

    public async Task<EmpleadoResponseDTO> Update(int id, EmpleadoRequestDTO empleado)
    {
        try
        {
            var _empleado = new Empleado
            {
                Nombre = empleado.Nombre,
                Usuario = empleado.Usuario,
                Password = empleado.Password,
                IdSector = empleado.IdSector,
                RoleId = empleado.RoleId,
                Id = id
            };
            _unitOfWork.EmpleadoRepository.Edit(_empleado);
            await _unitOfWork.Save();  // Save the changes to the database

            return await Get(_empleado.Id);

        }
        catch (Exception ex)
        {
            // Optionally log the exception
            // _logger.LogError(ex, "An error occurred while adding the employee.");

            throw new ApplicationException("An error occurred while adding the employee.", ex);
        }
    }

    public async Task<bool> Delete(int empleadoId)
    {
        try
        {
            var _empleado = await _unitOfWork.EmpleadoRepository.GetId(empleadoId);

            if (_empleado != null)
            {
                _unitOfWork.EmpleadoRepository.Delete(_empleado);
                await _unitOfWork.Save();  // Save the changes to the database

                return true;  // Si se guarda correctamente
            }

            return false;  // Si el empleado no fue encontrado
        }
        catch (Exception ex)
        {
            // Optionally log the exception
            // _logger.LogError(ex, "An error occurred while adding the employee.");

            throw new ApplicationException("An error occurred while adding the employee.", ex);
        }
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