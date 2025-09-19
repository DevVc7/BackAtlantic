using Biblioteca.Dominio.Entidades;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Estacionamiento.Infraestructura.IRepositorios
{
    public interface IUsuarioRepositorio
    {
        Task<Usuario> ObtenerPorIdAsync(int id);
        Task<IEnumerable<Usuario>> ObtenerTodosAsync();
        Task AgregarAsync(Usuario usuario);
        Task ActualizarAsync(Usuario usuario);
        Task EliminarAsync(Usuario usuario);
        Task<Usuario> ObtenerPorUsernameAsync(string username);
    }
}
