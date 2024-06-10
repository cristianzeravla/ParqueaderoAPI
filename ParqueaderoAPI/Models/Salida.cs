using System;
using System.Collections.Generic;

namespace ParqueaderoAPI.Models;

public partial class Salida
{
    public int IdSalida { get; set; }

    public int? IdFactura { get; set; }

    public DateTime FechaSalida { get; set; }

    public virtual Factura? IdFacturaNavigation { get; set; }
}
