using Microsoft.AspNetCore.Mvc;
using ParqueaderoAPI.Models;
using ParqueaderoAPI.DTOs;

namespace ParqueaderoAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CierreController : ControllerBase
    {
        private readonly ParqueaderoContext _context;

        public CierreController(ParqueaderoContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Crea un nuevo cierre del parqueadero.
        /// </summary>
        /// <param name="cierreDto">Datos del cierre del parqueadero.
        /// <br/>Se requiere el idInicio, el total de facturas y la fecha de cierre (Si no se ingresa, se tomará la fecha actual).</param>
        /// <returns>El ID del cierre creado.</returns>
        /// <response code="200">Devuelve el ID del cierre creado.</response>
        /// <response code="400">Si el objeto cierreDto es nulo.</response>
        /// <response code="404">Si el idInicio no existe.</response>
        /// <response code="500">Si hay un error interno del servidor.</response>
        [HttpPost]
        public async Task<IActionResult> CreateCierre([FromBody] CierreDTO cierreDto)
        {
            if (cierreDto == null)
            {
                return BadRequest("El objeto cierre es nulo.");
            }

            var cierre = new Cierre
            {
                IdInicio = cierreDto.IdInicio,
                TotalFacturas = cierreDto.TotalFacturas,
                FechaCierre = cierreDto.FechaCierre ?? DateTime.Now
            };

            try
            {
                var inicio = await _context.Inicios.FindAsync(cierre.IdInicio);
                if (inicio == null)
                {
                    return NotFound($"El id_inicio: {cierre.IdInicio}, no existe.");
                }

                _context.Cierres.Add(cierre);
                await _context.SaveChangesAsync();
                return Ok(new { id_cierre = cierre.IdCierre });
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error interno del servidor: " + ex.Message);
            }
        }
    }
}