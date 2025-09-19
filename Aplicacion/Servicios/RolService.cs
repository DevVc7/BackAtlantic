using Biblioteca.Aplicacion.Interfaces;
using Biblioteca.Dominio.DTOs;
using Estacionamiento.Infraestructura.IRepositorios;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Biblioteca.Aplicacion.Servicios
{
    public class RolService : IRolService
    {
        private readonly IRolRepositorio _rolRepositorio;

        public RolService(IRolRepositorio rolRepositorio)
        {
            _rolRepositorio = rolRepositorio;
        }

        public async Task<RolDto> ObtenerRolPorIdAsync(int id)
        {
            var rol = await _rolRepositorio.ObtenerPorIdAsync(id);
            if (rol == null) return null;
            return new RolDto { IdRol = rol.Id, Nombre = rol.Nombre };
        }

        public async Task<IEnumerable<RolDto>> ObtenerTodosLosRolesAsync()
        {
            var roles = await _rolRepositorio.ObtenerTodosAsync();
            return roles.Select(rol => new RolDto { IdRol = rol.Id, Nombre = rol.Nombre });
        }
    }
}
