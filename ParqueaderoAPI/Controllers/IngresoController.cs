using Microsoft.AspNetCore.Mvc;
using ParqueaderoAPI.Models;
using ParqueaderoAPI.DTOs;  // Importa el espacio de nombres del DTO

namespace ParqueaderoAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class IngresoController : ControllerBase
    {
        private readonly ParqueaderoContext _context;

        public IngresoController(ParqueaderoContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Crea un nuevo ingreso de vehículo.
        /// </summary>
        /// <param name="ingresoDto">Datos del ingreso del vehículo.
        /// <br/>Se requiere el idInicio, la placa (5 caracteres) y la fecha de ingreso (Si no se ingresa, se tomara la fecha actual).</param>
        /// <returns>El ID del ingreso creado.</returns>
        /// <response code="200">Devuelve el ID del ingreso creado.</response>
        /// <response code="400">Si el objeto ingresoDto es nulo o si la placa no tiene 5 caracteres.</response>
        /// <response code="404">Si el idInicio no existe.</response>
        /// <response code="500">Si hay un error interno del servidor.</response>

        [HttpPost]
        public async Task<IActionResult> CreateIngreso([FromBody] IngresoDTO ingresoDto)
        {
            if (ingresoDto == null)
            {
                return BadRequest("El objeto ingreso es nulo.");
            }

            if (string.IsNullOrWhiteSpace(ingresoDto.Placa) || ingresoDto.Placa.Length != 5)
            {
                return BadRequest("El campo placa debe tener exactamente 5 caracteres.");
            }

            // Asignar la fecha actual si no se proporciona
            var ingreso = new Ingreso
            {
                IdInicio = ingresoDto.IdInicio,
                Placa = ingresoDto.Placa,
                FechaIngreso = ingresoDto.FechaIngreso ?? DateTime.Now
            };

            try
            {
                var inicio = await _context.Inicios.FindAsync(ingreso.IdInicio);
                if (inicio == null)
                {
                    return NotFound($"El id_inicio: {ingreso.IdInicio}, no existe.");
                }

                _context.Ingresos.Add(ingreso);
                await _context.SaveChangesAsync();
                return Ok(new { id_ingreso = ingreso.IdIngreso });
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error interno del servidor: " + ex.Message);
            }
        }
    }
}