using Biblioteca.Aplicacion.Interfaces;
using Biblioteca.Dominio.DTOs;
using Biblioteca.Dominio.Entidades;
using Estacionamiento.Infraestructura.IRepositorios;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Biblioteca.Aplicacion.Servicios
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;

        public UsuarioService(IUsuarioRepositorio usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
        }

        public async Task<UsuarioDto> ObtenerUsuarioPorIdAsync(int id)
        {
            var usuario = await _usuarioRepositorio.ObtenerPorIdAsync(id);
            if (usuario == null) return null;
            return MapToDto(usuario);
        }

        public async Task<IEnumerable<UsuarioDto>> ObtenerTodosLosUsuariosAsync()
        {
            var usuarios = await _usuarioRepositorio.ObtenerTodosAsync();
            return usuarios.Select(MapToDto);
        }

        public async Task<UsuarioDto> CrearUsuarioAsync(CrearUsuarioDto crearUsuarioDto)
        {
            // NOTA: Aquí se debe implementar el hash de la contraseña. Por ahora se guarda en texto plano.
            var nuevoUsuario = new Usuario
            {
                Username = crearUsuarioDto.Username,
                Email = crearUsuarioDto.Email,
                PasswordHash = crearUsuarioDto.Password, // ¡HASH ESTA CONTRASEÑA!
                Nombres = crearUsuarioDto.NombreCompleto,
                RolId = crearUsuarioDto.IdRol,
                Activo = true
            };

            await _usuarioRepositorio.AgregarAsync(nuevoUsuario);
            
            // Para obtener el DTO completo, necesitamos el usuario con su rol cargado
            var usuarioCreado = await _usuarioRepositorio.ObtenerPorUsernameAsync(nuevoUsuario.Username);
            return MapToDto(usuarioCreado);
        }

        public async Task<bool> ActualizarUsuarioAsync(int id, UsuarioDto usuarioDto)
        {
            var usuarioExistente = await _usuarioRepositorio.ObtenerPorIdAsync(id);
            if (usuarioExistente == null) return false;

            usuarioExistente.Username = usuarioDto.Username;
            usuarioExistente.Email = usuarioDto.Email;
            usuarioExistente.Nombres = usuarioDto.NombreCompleto;
            usuarioExistente.RolId = usuarioDto.IdRol;
            usuarioExistente.Activo = usuarioDto.Activo;

            await _usuarioRepositorio.ActualizarAsync(usuarioExistente);
            return true;
        }

        public async Task<bool> EliminarUsuarioAsync(int id)
        {
            var usuarioExistente = await _usuarioRepositorio.ObtenerPorIdAsync(id);
            if (usuarioExistente == null) return false;

            await _usuarioRepositorio.EliminarAsync(usuarioExistente);
            return true;
        }

        private UsuarioDto MapToDto(Usuario usuario)
        {
            return new UsuarioDto
            {
                IdUsuario = usuario.Id,
                Username = usuario.Username,
                Email = usuario.Email,
                NombreCompleto = usuario.Nombres + usuario.Apellidos,
                IdRol = usuario.RolId,
                NombreRol = usuario.Rol?.Nombre ?? "N/A",
                Activo = usuario.Activo
            };
        }
    }
}
