using System;

namespace ParqueaderoAPI.DTOs
{
    /// <summary>
    /// Datos del ingreso del vehículo.
    /// </summary>
    public class IngresoDTO
    {
        /// <summary>
        /// ID del inicio del parqueadero.
        /// </summary>
        public int IdInicio { get; set; }

        /// <summary>
        /// Placa del vehículo (5 caracteres).
        /// </summary>
        public string? Placa { get; set; }

        /// <summary>
        /// Fecha de ingreso del vehículo (opcional).
        /// </summary>
        public DateTime? FechaIngreso { get; set; }
    }
}

