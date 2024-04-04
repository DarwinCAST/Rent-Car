using System;
using System.Collections.Generic;

namespace ConcecionarioAutomoviles.Models;

public partial class Concesionario
{
    public int IdConcesionario { get; set; }

    public string NombreConcesionario { get; set; } = null!;

    public string DomicilioConcesionario { get; set; } = null!;

    public string Nif { get; set; } = null!;

    public virtual ICollection<AutomovilesStock> AutomovilesStocks { get; set; } = new List<AutomovilesStock>();

    public virtual ICollection<ServiciosOficiales> ServiciosOficiales { get; set; } = new List<ServiciosOficiales>();
}
