using Biblioteca.Aplicacion.Interfaces;
using Biblioteca.Aplicacion.Servicios;
using Biblioteca.Dominio.DTOs;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Estacionamiento.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RolesController : ControllerBase
    {
        private readonly IRolService _rolService;

        public RolesController(IRolService rolService)
        {
            _rolService = rolService;
        }

        [HttpGet]
        public async Task<IActionResult> ObtenerTodos()
        {
            var roles = await _rolService.ObtenerTodosLosRolesAsync();
            return Ok(roles);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ObtenerPorId(int id)
        {
            var rol = await _rolService.ObtenerRolPorIdAsync(id);
            if (rol == null)
            {
                return NotFound();
            }
            return Ok(rol);
        }

        [HttpPost("registrarRol")]
        public async Task<IActionResult> RegistrarRol([FromBody] RegistrarRolDto rq)
        {
            try
            {
                var response = await _rolService.RegistrarRolAsync(rq);
                return CreatedAtAction(nameof(ObtenerPorId), new { id = response.Id }, response);
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensaje = ex.Message });
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> EliminarRol(int id)
        {
            try
            {
                var result = await _rolService.EliminarRolAsync(id);
                if (result)
                {
                    return Ok(new { mensaje = "Rol eliminado exitosamente" });
                }
                return NotFound(new { mensaje = "Rol no encontrado" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensaje = ex.Message });
            }
        }
    }
}
