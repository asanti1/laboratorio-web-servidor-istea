using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace laboratorio_web_api_istea.DAL.Models;

public class Mesa : ClaseBase
{
    public string Nombre { get; set; } = null!;

    [ForeignKey(nameof(EstadosMesa))] public int EstadosMesaId { get; set; }

    public EstadosMesa EstadosMesa { get; set; } = null!;
}