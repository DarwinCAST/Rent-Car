using System;
using System.Collections.Generic;

namespace ConcecionarioAutomoviles.Models;

public partial class Venta
{
    public int IdVenta { get; set; }

    public int? IdAutomovil { get; set; }

    public int? IdVendedor { get; set; }

    public int? IdServicioOficial { get; set; }

    public decimal PrecioVenta { get; set; }

    public string ModoPago { get; set; } = null!;

    public DateOnly FechaEntrega { get; set; }

    public string Matricula { get; set; } = null!;

    public bool EsDeStock { get; set; }

    public virtual AutomovilesStock? IdAutomovilNavigation { get; set; }

    public virtual ServiciosOficiales? IdServicioOficialNavigation { get; set; }

    public virtual Vendedore? IdVendedorNavigation { get; set; }
}
