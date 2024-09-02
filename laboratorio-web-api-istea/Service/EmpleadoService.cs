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
    public async Task<List<Empleado>> GetAll()
    {
        try
        {
            return await _unitOfWork.EmpleadoRepository.GetAll();
        }
        catch
        {
            throw new ApplicationException("An error occurred while retrieving employees.");
        } 
    }

    public async Task<Empleado> Get(int empleadoId)
    {
        try
        {
            var empleado = await _unitOfWork.EmpleadoRepository.GetId(empleadoId);

            if (empleado == null)
            {
                // Optionally, throw an exception or return null if not found
                throw new KeyNotFoundException($"No se encontró un empleado con el ID {empleadoId}");
            }

            return empleado;
        }
        catch (Exception ex)
        {
            // Optionally log the exception
            // _logger.LogError(ex, "An error occurred while retrieving the employee.");

            throw new ApplicationException("An error occurred while retrieving the employee.", ex);
        }
    }

    public async Task<Empleado> Add(Empleado empleado)
    {
        try
        {
            await _unitOfWork.EmpleadoRepository.Add(empleado);
            await _unitOfWork.Save();  // Save the changes to the database

            return empleado;  // Return the newly added employee
        }
        catch (Exception ex)
        {
            // Optionally log the exception
            // _logger.LogError(ex, "An error occurred while adding the employee.");

            throw new ApplicationException("An error occurred while adding the employee.", ex);
        }
    }

    public async Task<Empleado> Update(int id, Empleado empleado)
    {
        throw new NotImplementedException();
    }

    public Task<bool> Delete(int empleadoId)
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