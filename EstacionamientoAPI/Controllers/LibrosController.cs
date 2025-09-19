using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Biblioteca.Dominio.Entidades;
using Biblioteca.Dominio.DTOs;
using Estacionamiento.Infraestructura.Context;

namespace BibliotecaSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LibrosController : ControllerBase
    {
        private readonly BibliotecaDbContext _context;

        public LibrosController(BibliotecaDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<PagedResultDto<LibroDto>>> GetLibros(
            [FromQuery] int page = 1, 
            [FromQuery] int pageSize = 10,
            [FromQuery] string? search = null,
            [FromQuery] int? categoriaId = null)
        {
            var query = _context.Libros
                .Include(l => l.Categoria)
                .Include(l => l.CopiasLibros)
                .AsQueryable();

            if (categoriaId.HasValue)
            {
                query = query.Where(l => l.CategoriaId == categoriaId.Value);
            }

            var totalItems = await query.CountAsync();
            var libros = await query
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .Select(l => new LibroDto
                {
                    Id = l.Id,
                    Titulo = l.Titulo,
                    Categoria = l.Categoria.Nombre,
                    PrecioVenta = l.PrecioVenta,
                    CopiasDisponibles = l.CopiasLibros.Count(cl => cl.Estado == "Disponible"),
                    CopiasTotal = l.CopiasLibros.Count()
                })
                .ToListAsync();

            return Ok(new PagedResultDto<LibroDto>
            {
                Items = libros,
                TotalItems = totalItems,
                Page = page,
                PageSize = pageSize,
                TotalPages = (int)Math.Ceiling((double)totalItems / pageSize)
            });
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<LibroDetalleDto>> GetLibro(int id)
        {
            var libro = await _context.Libros
                .Include(l => l.Categoria)
                .Include(l => l.CopiasLibros)
                .FirstOrDefaultAsync(l => l.Id == id);

            if (libro == null)
            {
                return NotFound(new { mensaje = "Libro no encontrado" });
            }

            var response = new LibroDetalleDto
            {
                Id = libro.Id,
                Titulo = libro.Titulo,
                Descripcion = libro.Descripcion,
                FechaPublicacion = libro.FechaPublicacion,
                NumeroPaginas = libro.NumeroPaginas,
                Categoria = libro.Categoria.Nombre,
                PrecioVenta = libro.PrecioVenta,
                CopiasDisponibles = libro.CopiasLibros.Count(cl => cl.Estado == "Disponible"),
                CopiasTotal = libro.CopiasLibros.Count(),
                Copias = libro.CopiasLibros.Select(cl => new CopiaLibroDto
                {
                    Id = cl.Id,
                    CodigoBarras = cl.CodigoBarras,
                    Estado = cl.Estado,
                }).ToList()
            };

            return Ok(response);
        }

        [HttpGet("{id}/disponibilidad")]
        public async Task<ActionResult<DisponibilidadLibroDto>> CheckDisponibilidad(int id)
        {
            var libro = await _context.Libros
                .Include(l => l.CopiasLibros)
                .FirstOrDefaultAsync(l => l.Id == id);

            if (libro == null)
            {
                return NotFound(new { mensaje = "Libro no encontrado" });
            }

            var copiasDisponibles = libro.CopiasLibros.Where(cl => cl.Estado == "Disponible").ToList();

            return Ok(new DisponibilidadLibroDto
            {
                LibroId = libro.Id,
                Titulo = libro.Titulo,
                CopiasDisponibles = copiasDisponibles.Count,
                CopiasTotal = libro.CopiasLibros.Count,
                Disponible = copiasDisponibles.Any(),
                CopiasDisponiblesIds = copiasDisponibles.Select(cl => cl.Id).ToList()
            });
        }
    }
}
