using System;

namespace ParqueaderoAPI.DTOs
{
    /// <summary>
    /// Datos de la salida del vehículo.
    /// </summary>
    public class SalidaDTO
    {
        /// <summary>
        /// ID de la factura del vehículo.
        /// </summary>
        public int IdFactura { get; set; }

        /// <summary>
        /// Fecha de salida del vehículo (opcional).
        /// </summary>
        public DateTime? FechaSalida { get; set; }
    }
}

