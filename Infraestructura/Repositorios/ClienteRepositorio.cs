using Biblioteca.Dominio.Entidades;
using Estacionamiento.Infraestructura.Context;
using Estacionamiento.Infraestructura.IRepositorios;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Estacionamiento.Infraestructura.Repositorios
{
    public class ClienteRepositorio : IClienteRepositorio
    {
        private readonly BibliotecaDbContext _context;

        public ClienteRepositorio(BibliotecaDbContext context)
        {
            _context = context;
        }

        public async Task<Cliente> ObtenerPorIdAsync(int id)
        {
            return await _context.Clientes.FindAsync(id);
        }

        public async Task<IEnumerable<Cliente>> ObtenerTodosAsync()
        {
            return await _context.Clientes.Where(c => c.Activo).ToListAsync();
        }

        public async Task<Cliente> ObtenerPorEmailONumeroDocumentoAsync(string email, string numeroDocumento)
        {
            return await _context.Clientes.FirstOrDefaultAsync(c => c.Email == email || c.NumeroDocumento == numeroDocumento);
        }

        public async Task AgregarAsync(Cliente cliente)
        {
            await _context.Clientes.AddAsync(cliente);
            await _context.SaveChangesAsync();
        }

        public async Task ActualizarAsync(Cliente cliente)
        {
            await _context.SaveChangesAsync();
        }

        public async Task EliminarAsync(Cliente cliente)
        {
            cliente.Activo = false;
            await _context.SaveChangesAsync();
        }
    }
}
