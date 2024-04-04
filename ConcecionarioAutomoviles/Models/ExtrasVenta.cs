using System;
using System.Collections.Generic;

namespace ConcecionarioAutomoviles.Models;

public partial class ExtrasVenta
{
    public int? IdVenta { get; set; }

    public int? IdExtra { get; set; }

    public decimal PrecioExtra { get; set; }

    public virtual Extra? IdExtraNavigation { get; set; }

    public virtual Venta? IdVentaNavigation { get; set; }
}
