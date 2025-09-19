using Biblioteca.Dominio.DTOs;

namespace Biblioteca.Aplicacion.Interfaces
{
    public interface IPrestamoService
    {
        Task<ResultadoPrestamoDto> RegistrarPrestamoAsync(RegistrarPrestamoDto request);
        Task<ResultadoPrestamoDto> DevolverPrestamoAsync(int prestamoId);
        Task<bool> ValidarDisponibilidadLibrosAsync(List<int> copiaLibroIds);
        Task<bool> ClienteTienePrestamosVencidosAsync(int clienteId);
        Task<int> ContarPrestamosActivosClienteAsync(int clienteId);
    }
}
