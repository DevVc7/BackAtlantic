using Biblioteca.Aplicacion.Interfaces;
using Biblioteca.Dominio.DTOs;
using Biblioteca.Dominio.Entidades;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BibliotecaSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientesController : ControllerBase
    {
        private readonly IClienteService _clienteService;

        public ClientesController(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        [HttpPost("registrar")]
        public async Task<ActionResult<ClienteResponseDto>> RegistrarCliente([FromBody] RegistrarClienteDto request)
        {
            try
            {
                var response = await _clienteService.RegistrarClienteAsync(request);
                return CreatedAtAction(nameof(GetCliente), new { id = response.Id }, response);
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensaje = ex.Message });
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ClienteDetalleDto>> GetCliente(int id)
        {
            var cliente = await _clienteService.ObtenerClientePorIdAsync(id);
            if (cliente == null)
            {
                return NotFound(new { mensaje = "Cliente no encontrado" });
            }
            return Ok(cliente);
        }

        [HttpGet("obtenerTodos")]
        public async Task<ActionResult<Cliente>> GetClientes()
        {
            var cliente = await _clienteService.ObtenerTodosLosClientesAsync();
            if (cliente == null)
            {
                return NotFound(new { mensaje = "Cliente no encontrado" });
            }
            return Ok(cliente);
        }

        [HttpPost("{id}/verificar-otp")]
        public async Task<ActionResult> VerificarOTP(int id, [FromBody] VerificarOTPDto request)
        {
            try
            {
                var result = await _clienteService.VerificarOtpAsync(id, request);
                if (result)
                {
                    return Ok(new { mensaje = "Cliente verificado exitosamente" });
                }
                return NotFound(new { mensaje = "Cliente no encontrado" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensaje = ex.Message });
            }
        }

        [HttpPost("{id}/actualizarCliente")]
        public async Task<ActionResult> ActualizarCliente(int id, [FromBody] ActualizarClienteDto request)
        {
            try
            {
                var result = await _clienteService.ActualizarClienteAsync(id, request);
                if (result)
                {
                    return Ok(new { mensaje = "Cliente actualizado exitosamente" });
                }
                return NotFound(new { mensaje = "Cliente no encontrado" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensaje = ex.Message });
            }
        }
    }
}
