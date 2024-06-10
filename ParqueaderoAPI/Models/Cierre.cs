using System;
using System.Collections.Generic;

namespace ParqueaderoAPI.Models;

public partial class Cierre
{
    public int IdCierre { get; set; }

    public int? IdInicio { get; set; }

    public double TotalFacturas { get; set; }

    public DateTime FechaCierre { get; set; }

    public virtual Inicio? IdInicioNavigation { get; set; }
}
