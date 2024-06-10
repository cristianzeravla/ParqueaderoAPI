using System;
using System.Collections.Generic;

namespace ParqueaderoAPI.Models;

public partial class Ingreso
{
    public int IdIngreso { get; set; }

    public string Placa { get; set; } = null!;

    public int? IdInicio { get; set; }

    public DateTime FechaIngreso { get; set; }

    public virtual ICollection<Factura> Facturas { get; set; } = new List<Factura>();

    public virtual Inicio? IdInicioNavigation { get; set; }
}
