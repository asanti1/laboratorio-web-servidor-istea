using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace laboratorio_web_api_istea.DAL.Models;

public class Producto : ClaseBase
{
    [ForeignKey(nameof(Sectore))] public int SectorId { get; set; }

    public string Descripcion { get; set; } = null!;

    public int Stock { get; set; }

    public decimal Precio { get; set; }

    public virtual ICollection<Pedido> Pedidos { get; set; } = new List<Pedido>();
    
    public virtual Sectore Sector { get; set; } = null!;
}