using Biblioteca.Dominio.Entidades;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Estacionamiento.Infraestructura.IRepositorios
{
    public interface IRolRepositorio
    {
        Task<Rol> ObtenerPorIdAsync(int id);
        Task<IEnumerable<Rol>> ObtenerTodosAsync();
        Task AgregarAsync(Rol rol);
        Task ActualizarAsync(Rol rol);
        Task EliminarAsync(Rol rol);
    }
}
