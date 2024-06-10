using System;
using System.Collections.Generic;

namespace ParqueaderoAPI.Models;

public partial class Factura
{
    public int IdFactura { get; set; }

    public int? IdIngreso { get; set; }

    public double ValorFactura { get; set; }

    public DateTime FechaFactura { get; set; }

    public virtual Ingreso? IdIngresoNavigation { get; set; }

    public virtual ICollection<Salida> Salida { get; set; } = new List<Salida>();
}
