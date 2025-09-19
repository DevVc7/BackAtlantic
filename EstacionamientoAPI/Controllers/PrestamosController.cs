using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Biblioteca.Dominio.Entidades;
using Biblioteca.Dominio.DTOs;
using Estacionamiento.Infraestructura.Context;
using Biblioteca.Aplicacion.Interfaces;

namespace BibliotecaSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PrestamosController : ControllerBase
    {
        private readonly BibliotecaDbContext _context;
        private readonly IPrestamoService _prestamoService;

        public PrestamosController(BibliotecaDbContext context, IPrestamoService prestamoService)
        {
            _context = context;
            _prestamoService = prestamoService;
        }

        [HttpPost("registrar")]
        public async Task<ActionResult<PrestamoResponseDto>> RegistrarPrestamo([FromBody] RegistrarPrestamoDto request)
        {
            try
            {
                var resultado = await _prestamoService.RegistrarPrestamoAsync(request);
                
                if (!resultado.Exitoso)
                {
                    return BadRequest(new { mensaje = resultado.Mensaje, errores = resultado.Errores });
                }

                return Ok(resultado.Prestamo);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { mensaje = "Error interno del servidor", detalle = ex.Message });
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PrestamoResponseDto>> ObtenerPrestamo(int id)
        {
            var prestamo = await _context.Prestamos
                .Include(p => p.Cliente)
                .Include(p => p.Usuario)
                .Include(p => p.PrestamoDetalles)
                    .ThenInclude(pd => pd.CopiaLibro)
                        .ThenInclude(cl => cl.Libro)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (prestamo == null)
            {
                return NotFound(new { mensaje = "Préstamo no encontrado" });
            }

            var response = new PrestamoResponseDto
            {
                Id = prestamo.Id,
                ClienteId = prestamo.ClienteId,
                NombreCliente = $"{prestamo.Cliente.Nombres} {prestamo.Cliente.Apellidos}",
                FechaPrestamo = prestamo.FechaPrestamo,
                FechaDevolucionProgramada = prestamo.FechaDevolucionProgramada,
                FechaDevolucionReal = prestamo.FechaDevolucionReal,
                Estado = prestamo.Estado,
                Libros = prestamo.PrestamoDetalles.Select(pd => new LibroPrestamoDto
                {
                    CopiaLibroId = pd.CopiaLibroId,
                    CodigoBarras = pd.CopiaLibro.CodigoBarras,
                    TituloLibro = pd.CopiaLibro.Libro.Titulo
                }).ToList()
            };

            return Ok(response);
        }

        [HttpGet("cliente/{clienteId}")]
        public async Task<ActionResult<List<PrestamoResponseDto>>> ObtenerPrestamosPorCliente(int clienteId)
        {
            var prestamos = await _context.Prestamos
                .Include(p => p.Cliente)
                .Include(p => p.PrestamoDetalles)
                    .ThenInclude(pd => pd.CopiaLibro)
                        .ThenInclude(cl => cl.Libro)
                .Where(p => p.ClienteId == clienteId)
                .OrderByDescending(p => p.FechaPrestamo)
                .ToListAsync();

            var response = prestamos.Select(prestamo => new PrestamoResponseDto
            {
                Id = prestamo.Id,
                ClienteId = prestamo.ClienteId,
                NombreCliente = $"{prestamo.Cliente.Nombres} {prestamo.Cliente.Apellidos}",
                FechaPrestamo = prestamo.FechaPrestamo,
                FechaDevolucionProgramada = prestamo.FechaDevolucionProgramada,
                FechaDevolucionReal = prestamo.FechaDevolucionReal,
                Estado = prestamo.Estado,
                Libros = prestamo.PrestamoDetalles.Select(pd => new LibroPrestamoDto
                {
                    CopiaLibroId = pd.CopiaLibroId,
                    CodigoBarras = pd.CopiaLibro.CodigoBarras,
                    TituloLibro = pd.CopiaLibro.Libro.Titulo
                }).ToList()
            }).ToList();

            return Ok(response);
        }

        [HttpPut("{id}/devolver")]
        public async Task<ActionResult> DevolverPrestamo(int id)
        {
            var resultado = await _prestamoService.DevolverPrestamoAsync(id);
            
            if (!resultado.Exitoso)
            {
                return BadRequest(new { mensaje = resultado.Mensaje });
            }

            return Ok(new { mensaje = "Préstamo devuelto exitosamente" });
        }
    }
}
