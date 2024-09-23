using System.Security.Principal;
using laboratorio_web_api_istea.DAL.Models;
using laboratorio_web_api_istea.DTO.Empleado;
using laboratorio_web_api_istea.Service.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace laboratorio_web_api_istea.Controllers;

//TODO: Cambiar Empleados por los correspondientes DTOs para las clases que siguen.
[Route("api/[controller]")]
[ApiController]
public class EmpleadoController : ControllerBase
{
    private readonly IEmpleadoService _empleadoService;

    public EmpleadoController(IEmpleadoService empleadoService)
    {
        _empleadoService = empleadoService;
    }

    [HttpGet("GetEmpleados")]
    public async Task<ActionResult<List<EmpleadoResponseDTO>>> GetAll()
    {
        var emp = await _empleadoService.GetAll();
        if (emp.Count == 0) return NotFound();
        return Ok(emp);
    }

    [Authorize(Roles = "Socio")]
    [HttpGet("GetEmpleadoPorId/{id}")]
    public async Task<ActionResult<EmpleadoResponseDTO>> Get(int id)
    {
        var emp = await _empleadoService.Get(id);
        if (emp == null) return NotFound();
        return Ok(emp);
    }

    [HttpPost("AgregarEmpleado")]
    public async Task<ActionResult<EmpleadoResponseDTO>> Add(EmpleadoRequestDTO empleado)
    {
        return await _empleadoService.Add(empleado);
    }

    [HttpPut("EditarEmpleado/{id}")]
    public async Task<ActionResult<EmpleadoResponseDTO>> Update([FromRoute] int id, EmpleadoRequestDTO empleado)
    {
        var emp = await _empleadoService.Update(id, empleado);
        if (emp != null)
        {
            return Created(string.Empty, emp);
        }

        return NotFound();
    }

    [HttpDelete("EliminarEmpleado/{id}")]
    public async Task<ActionResult> Delete([FromRoute] int id)
    {
        try
        {
            await _empleadoService.Delete(id);
            return NoContent();
        }
        catch (Exception ex)
        {
            return NotFound(ex.Message);
        }
    }

    //TODO: AGREGAR EL DTO PARA MANEJAR EL BODY CON FECHAS
    [HttpGet("ObtenerIngresosDeEmpleado/{id}")]
    public async Task<ActionResult<HorariosIngresoSistemaDTO>> GetHorariosIngresoSistema(
        [FromRoute] int empleadoId,
        DateTime fechaInicio,
        [FromBody] DateTime fechaFin = new())
    {
        var horarios = await _empleadoService.GetHorariosIngresoSistema(empleadoId, fechaInicio, fechaFin);
        if (horarios == null) return NotFound();
        return Ok(horarios);
    }

    [HttpGet("GetOperacionesPorEmpleado")]
    public async Task<ActionResult<OperacionesPorEmpleadoDTO>> GetOperacionesPorEmpleado()
    {
        var operaciones = await _empleadoService.GetOperacionesPorEmpleado();
        if (operaciones == null) return NotFound();
        return Ok(operaciones);
    }
}