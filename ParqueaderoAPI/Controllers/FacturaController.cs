using Microsoft.AspNetCore.Mvc;
using ParqueaderoAPI.Models;
using ParqueaderoAPI.DTOs;

namespace ParqueaderoAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FacturaController : ControllerBase
    {
        private readonly ParqueaderoContext _context;

        public FacturaController(ParqueaderoContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Crea una nueva factura para un ingreso de vehículo.
        /// </summary>
        /// <param name="facturaDto">Datos de la factura del vehículo.
        /// <br/>Se requiere el idIngreso, el valor de la factura y la fecha de la factura (Si no se ingresa, se tomará la fecha actual).</param>
        /// <returns>El ID de la factura creada.</returns>
        /// <response code="200">Devuelve el ID de la factura creada.</response>
        /// <response code="400">Si el objeto facturaDto es nulo.</response>
        /// <response code="404">Si el idIngreso no existe.</response>
        /// <response code="500">Si hay un error interno del servidor.</response>
        [HttpPost]
        public async Task<IActionResult> CreateFactura([FromBody] FacturaDTO facturaDto)
        {
            if (facturaDto == null)
            {
                return BadRequest("El objeto factura es nulo.");
            }

            var factura = new Factura
            {
                IdIngreso = facturaDto.IdIngreso,
                ValorFactura = facturaDto.ValorFactura,
                FechaFactura = facturaDto.FechaFactura ?? DateTime.Now
            };

            try
            {
                var ingreso = await _context.Ingresos.FindAsync(factura.IdIngreso);
                if (ingreso == null)
                {
                    return NotFound($"El id_ingreso: {factura.IdIngreso}, no existe.");
                }

                _context.Facturas.Add(factura);
                await _context.SaveChangesAsync();
                return Ok(new { id_factura = factura.IdFactura });
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error interno del servidor: " + ex.Message);
            }
        }
    }
}
