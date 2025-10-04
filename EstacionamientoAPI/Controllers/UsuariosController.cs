using Biblioteca.Aplicacion.Interfaces;
using Biblioteca.Dominio.DTOs;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Estacionamiento.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuariosController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;

        public UsuariosController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpGet]
        public async Task<IActionResult> ObtenerTodos()
        {
            var usuarios = await _usuarioService.ObtenerTodosLosUsuariosAsync();
            return Ok(usuarios);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ObtenerPorId(int id)
        {
            var usuario = await _usuarioService.ObtenerUsuarioPorIdAsync(id);
            if (usuario == null)
            {
                return NotFound();
            }
            return Ok(usuario);
        }

        [HttpPost]
        public async Task<IActionResult> Crear([FromBody] CrearUsuarioDto crearUsuarioDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var nuevoUsuario = await _usuarioService.CrearUsuarioAsync(crearUsuarioDto);
            return CreatedAtAction(nameof(ObtenerPorId), new { id = nuevoUsuario.IdUsuario }, nuevoUsuario);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Actualizar(int id, [FromBody] UsuarioDto usuarioDto)
        {
            if (id != usuarioDto.IdUsuario)
            {
                return BadRequest("El ID del usuario no coincide.");
            }

            var resultado = await _usuarioService.ActualizarUsuarioAsync(id, usuarioDto);
            if (!resultado)
            {
                return NotFound();
            }

            return Ok(new { mensaje = "Usuario actualizado exitosamente" });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Eliminar(int id)
        {
            var resultado = await _usuarioService.EliminarUsuarioAsync(id);
            if (!resultado)
            {
                return NotFound();
            }

            return Ok(new { mensaje = "Usuario eliminado exitosamente" });
        }
    }
}
