using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Biblioteca.Dominio.Entidades;
using Biblioteca.Dominio.DTOs;
using Estacionamiento.Infraestructura.Context;

namespace BibliotecaSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientesController : ControllerBase
    {
        private readonly BibliotecaDbContext _context;

        public ClientesController(BibliotecaDbContext context)
        {
            _context = context;
        }

        [HttpPost("registrar")]
        public async Task<ActionResult<ClienteResponseDto>> RegistrarCliente([FromBody] RegistrarClienteDto request)
        {
            // Validar que no exista cliente con mismo email o documento
            var clienteExistente = await _context.Clientes
                .FirstOrDefaultAsync(c => c.Email == request.Email || c.NumeroDocumento == request.NumeroDocumento);

            if (clienteExistente != null)
            {
                return BadRequest(new { mensaje = "Ya existe un cliente con ese email o número de documento" });
            }

            var cliente = new Cliente
            {
                Nombres = request.Nombres,
                Apellidos = request.Apellidos,
                TipoDocumento = request.TipoDocumento,
                NumeroDocumento = request.NumeroDocumento,
                Email = request.Email,
                Telefono = request.Telefono,
                Direccion = request.Direccion,
                Ubigeo = request.Ubigeo,
                Activo = true,
                FechaCreacion = DateTime.Now
            };

            _context.Clientes.Add(cliente);
            await _context.SaveChangesAsync();

            var response = new ClienteResponseDto
            {
                Id = cliente.Id,
                Nombres = cliente.Nombres,
                Apellidos = cliente.Apellidos,
                Email = cliente.Email,
                Telefono = cliente.Telefono,
                Estado = cliente.Activo.ToString()
            };

            return CreatedAtAction(nameof(GetCliente), new { id = cliente.Id }, response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ClienteDetalleDto>> GetCliente(int id)
        {
            var cliente = await _context.Clientes
                .FirstOrDefaultAsync(c => c.Id == id);

            if (cliente == null)
            {
                return NotFound(new { mensaje = "Cliente no encontrado" });
            }

            var prestamosActivos = await _context.Prestamos
                .Where(p => p.ClienteId == id && p.Estado == "Activo")
                .CountAsync();

            var response = new ClienteDetalleDto
            {
                Id = cliente.Id,
                Nombres = cliente.Nombres,
                Apellidos = cliente.Apellidos,
                TipoDocumento = cliente.TipoDocumento,
                NumeroDocumento = cliente.NumeroDocumento,
                Email = cliente.Email,
                Telefono = cliente.Telefono,
                Direccion = cliente.Direccion,
                Estado = cliente.Activo.ToString(),
                FechaCreacion = cliente.FechaCreacion,
                EnListaNegra = cliente.EnListaNegra,
                PrestamosActivos = prestamosActivos
            };

            return Ok(response);
        }

        [HttpPost("{id}/verificar-otp")]
        public async Task<ActionResult> VerificarOTP(int id, [FromBody] VerificarOTPDto request)
        {
            var cliente = await _context.Clientes.FindAsync(id);

            if (cliente == null)
            {
                return NotFound(new { mensaje = "Cliente no encontrado" });
            }

            if (cliente.Activo.ToString() != "Pendiente")
            {
                return BadRequest(new { mensaje = "Cliente ya está verificado" });
            }

            if (request.CodigoOTP.Length != 6 || !request.CodigoOTP.All(char.IsDigit))
            {
                return BadRequest(new { mensaje = "Código OTP inválido" });
            }

            cliente.Activo = true;

            await _context.SaveChangesAsync();

            return Ok(new { mensaje = "Cliente verificado exitosamente" });
        }
    }
}
