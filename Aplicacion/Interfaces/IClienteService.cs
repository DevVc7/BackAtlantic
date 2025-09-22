using Biblioteca.Dominio.DTOs;
using Biblioteca.Dominio.Entidades;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Biblioteca.Aplicacion.Interfaces
{
    public interface IClienteService
    {
        Task<ClienteDetalleDto> ObtenerClientePorIdAsync(int id);
        Task<IEnumerable<ClienteDetalleDto>> ObtenerTodosLosClientesAsync();
        Task<ClienteResponseDto> RegistrarClienteAsync(RegistrarClienteDto registrarClienteDto);
        Task<bool> ActualizarClienteAsync(int id, ActualizarClienteDto registrarClienteDto);
        Task<bool> EliminarClienteAsync(int id);
        Task<bool> VerificarOtpAsync(int id, VerificarOTPDto verificarOtpDto);
    }
}
