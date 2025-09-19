using Biblioteca.Dominio.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Biblioteca.Aplicacion.Interfaces
{
    public interface IRolService
    {
        Task<RolDto> ObtenerRolPorIdAsync(int id);
        Task<IEnumerable<RolDto>> ObtenerTodosLosRolesAsync();
    }
}
