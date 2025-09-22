using Azure.Core;
using Biblioteca.Aplicacion.Interfaces;
using Biblioteca.Aplicacion.Servicios;
using Biblioteca.Dominio.DTOs;
using Biblioteca.Dominio.Entidades;
using Estacionamiento.Infraestructura.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BibliotecaSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LibrosController : ControllerBase
    {
        private readonly ILibroService _libroService;

        public LibrosController(ILibroService libroService)
        {
            _libroService = libroService;
        }

        [HttpGet]
        public async Task<ActionResult<PagedResultDto<LibroDto>>> GetLibros(
            [FromQuery] int page = 1, 
            [FromQuery] int pageSize = 10,
            [FromQuery] string? search = null,
            [FromQuery] int? categoriaId = null)
        {
            var libros = await _libroService.ObtenerTodosLibrosAsync();
            if (libros == null)
            {
                return NotFound(new { mensaje = "Libros no encontrados" });
            }
            return Ok(libros);
        }

        [HttpPost("registrarLibros")]
        public async Task<ActionResult<LibroResponseDto>> RegistrarLibro([FromBody] RegistrarLibroDto rq)
        {
            try
            {
                var response = await _libroService.RegistrarLibroAsync(rq);
                return CreatedAtAction(nameof(GetLibro), new { id = response.Id }, response);
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensaje = ex.Message });
            }
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<LibroDetalleDto>> GetLibro(int id)
        {
            var cliente = await _libroService.ObtenerLibroPorIdAsync(id);
            if (cliente == null)
            {
                return NotFound(new { mensaje = "Cliente no encontrado" });
            }
            return Ok(cliente);
        }

        [HttpPost("{id}/actualizarLibro")]
        public async Task<ActionResult> ActualizarCliente(int id, [FromBody] RegistrarLibroDto request)
        {
            try
            {
                var result = await _libroService.ActualizarLibroAsync(id, request);
                if (result)
                {
                    return Ok(new { mensaje = "Libro actualizado exitosamente" });
                }
                return NotFound(new { mensaje = "Libro no encontrado" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensaje = ex.Message });
            }
        }

        [HttpPost("{id}/eliminarLibro")]
        public async Task<ActionResult> EliminarLibro(int id)
        {
            try
            {
                var result = await _libroService.EliminarLibroAsync(id);
                if (result)
                {
                    return Ok(new { mensaje = "Libro eliminado exitosamente" });
                }
                return NotFound(new { mensaje = "Libro no encontrado" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensaje = ex.Message });
            }
        }
        //[HttpGet("{id}/disponibilidad")]
        //public async Task<ActionResult<DisponibilidadLibroDto>> CheckDisponibilidad(int id)
        //{
        //    var libro = await _context.Libros
        //        .Include(l => l.CopiasLibros)
        //        .FirstOrDefaultAsync(l => l.Id == id);

        //    if (libro == null)
        //    {
        //        return NotFound(new { mensaje = "Libro no encontrado" });
        //    }

        //    var copiasDisponibles = libro.CopiasLibros.Where(cl => cl.Estado == "Disponible").ToList();

        //    return Ok(new DisponibilidadLibroDto
        //    {
        //        LibroId = libro.Id,
        //        Titulo = libro.Titulo,
        //        CopiasDisponibles = copiasDisponibles.Count,
        //        CopiasTotal = libro.CopiasLibros.Count,
        //        Disponible = copiasDisponibles.Any(),
        //        CopiasDisponiblesIds = copiasDisponibles.Select(cl => cl.Id).ToList()
        //    });
        //}
    }
}
