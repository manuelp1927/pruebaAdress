using System;
using System.Collections.Generic;

namespace pruebaAPI.Models;

public partial class Presupuesto
{
    public int PresupuestoId { get; set; }

    public string? Unidad { get; set; }

    public string? TipoBienServicio { get; set; }

    public string? Cantidad { get; set; }

    public string? ValorUnitario { get; set; }

    public string? ValorTotal { get; set; }

    public string? FechaAdquision { get; set; }

    public string? Proveedor { get; set; }

    public string? Documentacion { get; set; }
}
