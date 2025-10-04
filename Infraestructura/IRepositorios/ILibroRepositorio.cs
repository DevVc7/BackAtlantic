using Biblioteca.Dominio.Entidades;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Estacionamiento.Infraestructura.IRepositorios
{
    public interface ILibroRepositorio
    {
        Task<Libro> ObtenerPorISBNAsync(string isbn);
        Task<Libro> ObtenerPorIdAsync(int id);
        Task<IEnumerable<Libro>> ObtenerTodosAsync();
        Task<IEnumerable<Categoria>> ObtenerCategoriasAsync();
        Task AgregarAsync(Libro libro);
        Task ActualizarAsync(Libro libro);
        Task EliminarAsync(Libro libro);
    }
}
