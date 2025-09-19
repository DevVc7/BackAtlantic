using Biblioteca.Dominio.Entidades;
using Estacionamiento.Infraestructura.Context;
using Estacionamiento.Infraestructura.IRepositorios;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Estacionamiento.Infraestructura.Repositorios
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private readonly BibliotecaDbContext _context;

        public UsuarioRepositorio(BibliotecaDbContext context)
        {
            _context = context;
        }

        public async Task<Usuario> ObtenerPorIdAsync(int id)
        {
            return await _context.Usuarios.Include(u => u.Rol).FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<IEnumerable<Usuario>> ObtenerTodosAsync()
        {
            return await _context.Usuarios.Include(u => u.Rol).ToListAsync();
        }

        public async Task AgregarAsync(Usuario usuario)
        {
            await _context.Usuarios.AddAsync(usuario);
            await _context.SaveChangesAsync();
        }

        public async Task ActualizarAsync(Usuario usuario)
        {
            _context.Usuarios.Update(usuario);
            await _context.SaveChangesAsync();
        }

        public async Task EliminarAsync(Usuario usuario)
        {
            _context.Usuarios.Remove(usuario);
            await _context.SaveChangesAsync();
        }

        public async Task<Usuario> ObtenerPorUsernameAsync(string username)
        {
            return await _context.Usuarios.Include(u => u.Rol).FirstOrDefaultAsync(u => u.Username == username);
        }
    }
}
