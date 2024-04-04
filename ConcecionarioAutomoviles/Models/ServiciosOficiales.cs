using System;
using System.Collections.Generic;

namespace ConcecionarioAutomoviles.Models;

public partial class ServiciosOficiales
{
    public int IdServicioOficial { get; set; }

    public string NombreServicioOficial { get; set; } = null!;

    public string DomicilioServicioOficial { get; set; } = null!;

    public string Nif { get; set; } = null!;

    public int? IdConcesionario { get; set; }

    public virtual Concesionario? IdConcesionarioNavigation { get; set; }

    public virtual ICollection<Venta> Venta { get; set; } = new List<Venta>();
}
