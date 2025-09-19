using Biblioteca.Dominio.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Biblioteca.Aplicacion.Interfaces
{
    public interface IUsuarioService
    {
        Task<UsuarioDto> ObtenerUsuarioPorIdAsync(int id);
        Task<IEnumerable<UsuarioDto>> ObtenerTodosLosUsuariosAsync();
        Task<UsuarioDto> CrearUsuarioAsync(CrearUsuarioDto crearUsuarioDto);
        Task<bool> ActualizarUsuarioAsync(int id, UsuarioDto usuarioDto);
        Task<bool> EliminarUsuarioAsync(int id);
    }
}
