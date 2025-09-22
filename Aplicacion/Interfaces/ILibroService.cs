using Biblioteca.Dominio.DTOs;
using Biblioteca.Dominio.Entidades;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Biblioteca.Aplicacion.Interfaces
{
    public interface ILibroService
    {
        Task<LibroDetalleDto> ObtenerLibroPorIdAsync(int id);
        Task<IEnumerable<LibroDetalleDto>> ObtenerTodosLibrosAsync();
        Task<LibroResponseDto> RegistrarLibroAsync(RegistrarLibroDto registrarLibroDto);
        Task<bool> ActualizarLibroAsync(int id, RegistrarLibroDto registrarLibroDto);
        Task<bool> EliminarLibroAsync(int id);
    }
}
