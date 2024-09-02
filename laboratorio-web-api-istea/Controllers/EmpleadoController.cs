using laboratorio_web_api_istea.DAL.Models;
using laboratorio_web_api_istea.DTO.Empleado;
using laboratorio_web_api_istea.Service.Interface;
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
    public async Task<ActionResult<List<Empleado>>> GetAll()
    {
        var emp = await _empleadoService.GetAll();
        if (emp.Count == 0) return NotFound();
        return Ok(emp);
    }

    [HttpGet("GetEmpleadoPorId/{id}")]
    public async Task<ActionResult<Empleado>> Get(int empleadoId)
    {
        var emp = await _empleadoService.Get(empleadoId);
        if (emp == null) return NotFound();
        return Ok(emp);
    }

    [HttpPost("AgregarEmpleado")]
    public async Task<ActionResult<Empleado>> Add(Empleado empleado)
    {
        return await _empleadoService.Add(empleado);
    }

    [HttpPut("EditarEmpleado/{id}")]
    public async Task<ActionResult<Empleado>> Update([FromRoute] int id, [FromBody] Empleado empleado)
    {
        var emp = await _empleadoService.Update(id, empleado);
        if (emp != null)
        {
            return Created(string.Empty, emp);
        }

        return NotFound();
    }

    [HttpDelete("EliminarEmpleado/{id}")]
    public async Task<ActionResult> Delete([FromRoute] int empleadoId)
    {
        bool success= await _empleadoService.Delete(empleadoId);
        if (!success) return NotFound();
        return NoContent();
    }

    //TODO: AGREGAR EL DTO PARA MANEJAR EL BODY CON FECHAS
    [HttpGet("ObtenerIngresosDeEmpleado/{id}")]
    public async Task<ActionResult<HorariosIngresoSistemaDTO>> GetHorariosIngresoSistema(
        [FromRoute] int empleadoId,
        DateTime fechaInicio,
        [FromBody] DateTime fechaFin = new DateTime())
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