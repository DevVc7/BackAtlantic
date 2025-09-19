using Biblioteca.Dominio.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Biblioteca.Aplicacion.Interfaces
{
    public interface IClienteService
    {
        Task<ClienteDetalleDto> ObtenerClientePorIdAsync(int id);
        Task<IEnumerable<ClienteResponseDto>> ObtenerTodosLosClientesAsync();
        Task<ClienteDetalleDto> RegistrarClienteAsync(RegistrarClienteDto registrarClienteDto);
        Task<bool> ActualizarClienteAsync(int id, RegistrarClienteDto registrarClienteDto);
        Task<bool> EliminarClienteAsync(int id);
    }
}
