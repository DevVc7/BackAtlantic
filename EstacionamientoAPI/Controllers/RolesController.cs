using Biblioteca.Aplicacion.Interfaces;
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
    }
}
