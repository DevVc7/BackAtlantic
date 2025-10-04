using Azure.Core;
using Biblioteca.Aplicacion.Interfaces;
using Biblioteca.Dominio.DTOs;
using Biblioteca.Dominio.Entidades;
using Estacionamiento.Infraestructura.IRepositorios;
using Estacionamiento.Infraestructura.Repositorios;
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

        public async Task<bool> EliminarRolAsync(int id)
        {
            var rol = await _rolRepositorio.ObtenerPorIdAsync(id);
            if (rol == null)
            {
                return false;
            }

            rol.Activo = false;

            await _rolRepositorio.ActualizarAsync(rol);

            return true;
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

        public async Task<RolResponseDto> RegistrarRolAsync(RegistrarRolDto registrarRolDto)
        {
            var rol = new Rol
            {
                Nombre = registrarRolDto.Nombre,
                Descripcion = registrarRolDto.Descripcion,
                Activo = true,
                FechaCreacion = DateTime.Now
            };

            await _rolRepositorio.AgregarAsync(rol);

            return new RolResponseDto
            {
                Id = rol.Id,
                Nombre = rol.Nombre,
                Descripcion = rol.Descripcion,
                Estado = rol.Activo.ToString()
            };
        }
    }
}
