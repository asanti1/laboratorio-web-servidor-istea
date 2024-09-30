using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace laboratorio_web_api_istea.DAL.Models;

public class Empleado : ClaseBase
{
    [Required] public string Nombre { get; set; }

    [Required] public string Usuario { get; set; }

    [Required] public string Password { get; set; }
    [ForeignKey(nameof(Sectore))] public int SectorId { get; set; }

    [ForeignKey(nameof(Role))] public int RoleId { get; set; }

    public virtual Sectore Sectore { get; set; } = null!;

    public virtual Role Role { get; set; } = null!;
}