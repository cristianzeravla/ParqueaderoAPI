using System;
using System.Collections.Generic;
using ParqueaderoAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.OpenApi;
using Microsoft.AspNetCore.Http.HttpResults;

namespace ParqueaderoAPI.Models;

public partial class Inicio
{
    public int IdInicio { get; set; }

    public DateTime FechaInicio { get; set; }

    public virtual ICollection<Cierre> Cierres { get; set; } = new List<Cierre>();

    public virtual ICollection<Ingreso> Ingresos { get; set; } = new List<Ingreso>();
}