using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace laboratorio_web_api_istea.DAL.Models;

public class Comanda : ClaseBase
{
    [ForeignKey(nameof(Mesa))] public int MesaId { get; set; }

    public string NombreCliente { get; set; } = null!;

    public virtual Mesa Mesa { get; set; } = null!;

    public virtual ICollection<Pedido> Pedidos { get; set; } = new List<Pedido>();
}