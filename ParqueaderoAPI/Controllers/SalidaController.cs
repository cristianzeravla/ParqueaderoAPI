using Microsoft.AspNetCore.Mvc;
using ParqueaderoAPI.Models;
using ParqueaderoAPI.DTOs;

namespace ParqueaderoAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SalidaController : ControllerBase
    {
        private readonly ParqueaderoContext _context;

        public SalidaController(ParqueaderoContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Crea una nueva salida para un vehículo.
        /// </summary>
        /// <param name="salidaDto">Datos de la salida del vehículo.
        /// <br/>Se requiere el idFactura y la fecha de salida (Si no se ingresa, se tomará la fecha actual).</param>
        /// <returns>El ID de la salida creada.</returns>
        /// <response code="200">Devuelve el ID de la salida creada.</response>
        /// <response code="400">Si el objeto salidaDto es nulo.</response>
        /// <response code="404">Si el idFactura no existe.</response>
        /// <response code="500">Si hay un error interno del servidor.</response>
        [HttpPost]
        public async Task<IActionResult> CreateSalida([FromBody] SalidaDTO salidaDto)
        {
            if (salidaDto == null)
            {
                return BadRequest("El objeto salida es nulo.");
            }

            var salida = new Salida
            {
                IdFactura = salidaDto.IdFactura,
                FechaSalida = salidaDto.FechaSalida ?? DateTime.Now
            };

            try
            {
                var factura = await _context.Facturas.FindAsync(salida.IdFactura);
                if (factura == null)
                {
                    return NotFound($"El id_factura: {salida.IdFactura}, no existe.");
                }

                _context.Salidas.Add(salida);
                await _context.SaveChangesAsync();
                return Ok(new { id_salida = salida.IdSalida });
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error interno del servidor: " + ex.Message);
            }
        }
    }
}
