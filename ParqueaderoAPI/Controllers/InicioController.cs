using Microsoft.AspNetCore.Mvc;
using ParqueaderoAPI.Models;
using ParqueaderoAPI.DTOs;

namespace ParqueaderoAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InicioController : ControllerBase
    {
        private readonly ParqueaderoContext _context;

        public InicioController(ParqueaderoContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Crea un nuevo inicio del parqueadero.
        /// </summary>
        /// <param name="inicioDto">Datos del inicio del parqueadero.
        /// <br/>Se requiere la fecha de inicio (Si no se ingresa, se tomará la fecha actual).</param>
        /// <returns>El ID del inicio creado.</returns>
        /// <response code="200">Devuelve el ID del inicio creado.</response>
        /// <response code="400">Si el objeto inicioDto es nulo.</response>
        /// <response code="500">Si hay un error interno del servidor.</response>
        [HttpPost]
        public async Task<IActionResult> CreateInicio([FromBody] InicioDTO inicioDto)
        {
            if (inicioDto == null)
            {
                return BadRequest("El objeto inicio es nulo.");
            }

            var inicio = new Inicio
            {
                FechaInicio = inicioDto.FechaInicio ?? DateTime.Now
            };

            try
            {
                _context.Inicios.Add(inicio);
                await _context.SaveChangesAsync();
                return Ok(new { id_inicio = inicio.IdInicio });
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error interno del servidor: " + ex.Message);
            }
        }
    }
}
