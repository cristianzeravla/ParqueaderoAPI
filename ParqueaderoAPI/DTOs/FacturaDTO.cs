using System;

namespace ParqueaderoAPI.DTOs
{
    /// <summary>
    /// Datos de la factura del vehículo.
    /// </summary>
    public class FacturaDTO
    {
        /// <summary>
        /// ID del ingreso del vehículo.
        /// </summary>
        public int IdIngreso { get; set; }

        /// <summary>
        /// Valor de la factura.
        /// </summary>
        public double ValorFactura { get; set; }

        /// <summary>
        /// Fecha de la factura (opcional).
        /// </summary>
        public DateTime? FechaFactura { get; set; }
    }
}
