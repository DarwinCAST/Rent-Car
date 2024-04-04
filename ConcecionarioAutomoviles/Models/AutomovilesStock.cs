using System;
using System.Collections.Generic;

namespace ConcecionarioAutomoviles.Models;

public partial class AutomovilesStock
{
    public int NumeroBastidor { get; set; }

    public int? IdModelo { get; set; }

    public int? IdConcesionario { get; set; }

    public virtual Concesionario? IdConcesionarioNavigation { get; set; }

    public virtual Modelo? IdModeloNavigation { get; set; }

    public virtual ICollection<Venta> Venta { get; set; } = new List<Venta>();
}
