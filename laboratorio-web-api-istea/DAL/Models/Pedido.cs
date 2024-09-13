using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace laboratorio_web_api_istea.DAL.Models;

public class Pedido : ClaseBase
{
    [ForeignKey(nameof(Comanda))] public int ComandaId { get; set; }

    [ForeignKey(nameof(Producto))] public int ProductoId { get; set; }

    [ForeignKey(nameof(EstadosPedido))] public int EstadosPedidoId { get; set; }

    public int Cantidad { get; set; }
    public DateTime FechaCreacion { get; set; }

    public DateTime? FechaFinalizacion { get; set; }

    public virtual Producto Producto { get; set; } = null!;
    public virtual Comanda Comanda { get; set; } = null!;
}