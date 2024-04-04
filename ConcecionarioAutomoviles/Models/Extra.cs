using System;
using System.Collections.Generic;

namespace ConcecionarioAutomoviles.Models;

public partial class Extra
{
    public int IdExtra { get; set; }

    public string NombreExtra { get; set; } = null!;

    public decimal PrecioExtra { get; set; }

    public virtual ICollection<Modelo> IdModelos { get; set; } = new List<Modelo>();
}
