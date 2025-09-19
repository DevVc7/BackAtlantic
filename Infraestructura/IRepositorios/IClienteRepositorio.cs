using Biblioteca.Dominio.Entidades;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Estacionamiento.Infraestructura.IRepositorios
{
    public interface IClienteRepositorio
    {
        Task<Cliente> ObtenerPorIdAsync(int id);
        Task<IEnumerable<Cliente>> ObtenerTodosAsync();
        Task AgregarAsync(Cliente cliente);
        Task ActualizarAsync(Cliente cliente);
        Task EliminarAsync(Cliente cliente);
    }
}
