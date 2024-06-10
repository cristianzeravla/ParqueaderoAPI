using System;

namespace ParqueaderoAPI.DTOs
{
    /// <summary>
    /// Datos del cierre del parqueadero.
    /// </summary>
    public class CierreDTO
    {
        /// <summary>
        /// ID del inicio del parqueadero.
        /// </summary>
        public int IdInicio { get; set; }

        /// <summary>
        /// Total de facturas del cierre.
        /// </summary>
        public int TotalFacturas { get; set; }

        /// <summary>
        /// Fecha de cierre del parqueadero (opcional).
        /// </summary>
        public DateTime? FechaCierre { get; set; }
    }
}
