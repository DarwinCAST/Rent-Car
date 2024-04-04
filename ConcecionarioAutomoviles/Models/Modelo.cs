using System;
using System.Collections.Generic;

namespace ConcecionarioAutomoviles.Models;

public partial class Modelo
{
    public int IdModelo { get; set; }

    public int? IdMarca { get; set; }

    public string NombreModelo { get; set; } = null!;

    public decimal Precio { get; set; }

    public decimal? Descuento { get; set; }

    public int? PotenciaFiscal { get; set; }

    public decimal? Cilindrada { get; set; }

    public virtual ICollection<AutomovilesStock> AutomovilesStocks { get; set; } = new List<AutomovilesStock>();

    public virtual Marca? IdMarcaNavigation { get; set; }

    public virtual ICollection<Extra> IdExtras { get; set; } = new List<Extra>();
}
