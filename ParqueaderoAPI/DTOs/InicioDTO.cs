using System;

namespace ParqueaderoAPI.DTOs
{
    /// <summary>
    /// Datos del inicio del parqueadero.
    /// </summary>
    public class InicioDTO
    {
        /// <summary>
        /// Fecha de inicio del parqueadero (opcional).
        /// </summary>
        public DateTime? FechaInicio { get; set; }
    }
}