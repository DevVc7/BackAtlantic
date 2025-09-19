using Biblioteca.Dominio.Entidades;
using Estacionamiento.Infraestructura.Context;
using Estacionamiento.Infraestructura.IRepositorios;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Estacionamiento.Infraestructura.Repositorios
{
    public class RolRepositorio : IRolRepositorio
    {
        private readonly BibliotecaDbContext _context;

        public RolRepositorio(BibliotecaDbContext context)
        {
            _context = context;
        }

        public async Task<Rol> ObtenerPorIdAsync(int id)
        {
            return await _context.Roles.FindAsync(id);
        }

        public async Task<IEnumerable<Rol>> ObtenerTodosAsync()
        {
            return await _context.Roles.ToListAsync();
        }

        public async Task AgregarAsync(Rol rol)
        {
            await _context.Roles.AddAsync(rol);
            await _context.SaveChangesAsync();
        }

        public async Task ActualizarAsync(Rol rol)
        {
            _context.Roles.Update(rol);
            await _context.SaveChangesAsync();
        }

        public async Task EliminarAsync(Rol rol)
        {
            _context.Roles.Remove(rol);
            await _context.SaveChangesAsync();
        }
    }
}
