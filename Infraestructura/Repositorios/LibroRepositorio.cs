using Biblioteca.Dominio.Entidades;
using Estacionamiento.Infraestructura.Context;
using Estacionamiento.Infraestructura.IRepositorios;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Estacionamiento.Infraestructura.Repositorios
{
    public class LibroRepositorio : ILibroRepositorio
    {
        private readonly BibliotecaDbContext _context;

        public LibroRepositorio(BibliotecaDbContext context)
        {
            _context = context;
        }
        public async Task<Libro> ObtenerPorISBNAsync(string isbn)
        {
            return await _context.Libros.FirstOrDefaultAsync(c => c.Isbn == isbn);
        }
        public async Task<Libro> ObtenerPorIdAsync(int id)
        {
            return await _context.Libros.FindAsync(id);
        }
        public async Task<IEnumerable<Libro>> ObtenerTodosAsync()
        {
            return await _context.Libros.Where(c => c.Activo).ToListAsync();
        }
        public async Task<IEnumerable<Categoria>> ObtenerCategoriasAsync()
        {
            return await _context.Categorias.Where(c => c.Activo).ToListAsync();
        }
        public async Task AgregarAsync(Libro cliente)
        {
            await _context.Libros.AddAsync(cliente);
            await _context.SaveChangesAsync();
        }
        public async Task ActualizarAsync(Libro cliente)
        {
            await _context.SaveChangesAsync();
        }

        public async Task EliminarAsync(Libro libro)
        {
            libro.Activo = false;
            await _context.SaveChangesAsync();
        }
    }
}
