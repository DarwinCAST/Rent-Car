using System;
using System.Collections.Generic;

namespace ConcecionarioAutomoviles.Models;

public partial class Vendedore
{
    public int IdVendedor { get; set; }

    public string NombreVendedor { get; set; } = null!;

    public string Nif { get; set; } = null!;

    public string DomicilioVendedor { get; set; } = null!;

    public virtual ICollection<Venta> Venta { get; set; } = new List<Venta>();
}
