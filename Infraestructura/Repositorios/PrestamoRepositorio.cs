using Microsoft.EntityFrameworkCore;
using Biblioteca.Dominio.Entidades;
using Biblioteca.Aplicacion.Interfaces;
using Biblioteca.Dominio.DTOs;
using Estacionamiento.Infraestructura.Context;

namespace Biblioteca.Infraestructura.Repositorios
{
    public class PrestamoRepositorio : IPrestamoRepositorio
    {
        private readonly BibliotecaDbContext _context;
        private const int MAXIMO_LIBROS_POR_PRESTAMO = 3;
        private const int DIAS_PRESTAMO_MAXIMO = 30;

        public PrestamoRepositorio(BibliotecaDbContext context)
        {
            _context = context;
        }

        public async Task<ResultadoPrestamoDto> RegistrarPrestamoAsync(RegistrarPrestamoDto request)
        {
            var resultado = new ResultadoPrestamoDto();

            // Validar que el cliente existe y no está en lista negra
            var cliente = await _context.Clientes
                .Include(c => c.EnListaNegra)
                .FirstOrDefaultAsync(c => c.Id == request.ClienteId);

            if (cliente == null)
            {
                resultado.Mensaje = "Cliente no encontrado";
                return resultado;
            }

            if (cliente.EnListaNegra != null && cliente.EnListaNegra)
            {
                resultado.Mensaje = "Cliente se encuentra en lista negra";
                return resultado;
            }

            // Validar límite de libros
            if (request.CopiaLibroIds.Count > MAXIMO_LIBROS_POR_PRESTAMO)
            {
                resultado.Mensaje = $"No se pueden prestar más de {MAXIMO_LIBROS_POR_PRESTAMO} libros";
                return resultado;
            }

            // Validar que el cliente no tenga préstamos vencidos
            if (await ClienteTienePrestamosVencidosAsync(request.ClienteId))
            {
                resultado.Mensaje = "Cliente tiene préstamos vencidos pendientes";
                return resultado;
            }

            // Validar límite de préstamos activos
            var prestamosActivos = await ContarPrestamosActivosClienteAsync(request.ClienteId);
            if (prestamosActivos + request.CopiaLibroIds.Count > MAXIMO_LIBROS_POR_PRESTAMO)
            {
                resultado.Mensaje = $"Cliente excedería el límite de {MAXIMO_LIBROS_POR_PRESTAMO} libros prestados";
                return resultado;
            }

            // Validar disponibilidad de libros
            if (!await ValidarDisponibilidadLibrosAsync(request.CopiaLibroIds))
            {
                resultado.Mensaje = "Uno o más libros no están disponibles";
                return resultado;
            }

            // Obtener copias de libros con precios
            var copiasLibros = await _context.CopiasLibros
                .Include(cl => cl.Libro)
                .Where(cl => request.CopiaLibroIds.Contains(cl.Id))
                .ToListAsync();

            if (copiasLibros.Count != request.CopiaLibroIds.Count)
            {
                resultado.Mensaje = "Algunas copias de libros no fueron encontradas";
                return resultado;
            }

            using var transaction = await _context.Database.BeginTransactionAsync();
            try
            {
                // Crear el préstamo
                var prestamo = new Prestamo
                {
                    ClienteId = request.ClienteId,
                    UsuarioId = request.UsuarioId,
                    FechaPrestamo = DateTime.Now,
                    FechaDevolucionProgramada = DateTime.Now.AddDays(DIAS_PRESTAMO_MAXIMO),
                    Estado = "Activo",
                };

                _context.Prestamos.Add(prestamo);
                await _context.SaveChangesAsync();

                // Crear detalles del préstamo
                foreach (var copia in copiasLibros)
                {
                    var detalle = new PrestamoDetalle
                    {
                        PrestamoId = prestamo.Id,
                        CopiaLibroId = copia.Id
                    };
                    _context.PrestamoDetalles.Add(detalle);

                    // Marcar copia como prestada
                    copia.Estado = "Prestado";
                    _context.CopiasLibros.Update(copia);
                }

                await _context.SaveChangesAsync();
                await transaction.CommitAsync();

                resultado.Exitoso = true;
                resultado.Mensaje = "Préstamo registrado exitosamente";
                return resultado;
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                resultado.Mensaje = $"Error al registrar el préstamo: {ex.Message}";
                return resultado;
            }
        }

        public async Task<ResultadoPrestamoDto> DevolverPrestamoAsync(int prestamoId)
        {
            var resultado = new ResultadoPrestamoDto();

            var prestamo = await _context.Prestamos
                .Include(p => p.PrestamoDetalles)
                .ThenInclude(d => d.CopiaLibro)
                .FirstOrDefaultAsync(p => p.Id == prestamoId);

            if (prestamo == null)
            {
                resultado.Mensaje = "Préstamo no encontrado";
                return resultado;
            }

            if (prestamo.Estado == "Devuelto")
            {
                resultado.Mensaje = "El préstamo ya fue devuelto anteriormente";
                return resultado;
            }

            using var transaction = await _context.Database.BeginTransactionAsync();
            try
            {
                // Actualizar estado del préstamo
                prestamo.Estado = "Devuelto";
                prestamo.FechaDevolucionReal = DateTime.Now;
                _context.Prestamos.Update(prestamo);

                // Actualizar estado de las copias
                foreach (var detalle in prestamo.PrestamoDetalles)
                {
                    detalle.CopiaLibro.Estado = "Disponible";
                    _context.CopiasLibros.Update(detalle.CopiaLibro);
                }

                await _context.SaveChangesAsync();
                await transaction.CommitAsync();

                resultado.Exitoso = true;
                resultado.Mensaje = "Devolución registrada exitosamente";
                return resultado;
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                resultado.Mensaje = $"Error al registrar la devolución: {ex.Message}";
                return resultado;
            }
        }

        public async Task<bool> ValidarDisponibilidadLibrosAsync(List<int> copiaLibroIds)
        {
            return await _context.CopiasLibros
                .Where(cl => copiaLibroIds.Contains(cl.Id) && cl.Estado == "Disponible")
                .CountAsync() == copiaLibroIds.Count;
        }

        public async Task<bool> ClienteTienePrestamosVencidosAsync(int clienteId)
        {
            return await _context.Prestamos
                .AnyAsync(p => p.ClienteId == clienteId && 
                             p.Estado == "Activo" && 
                             p.FechaDevolucionProgramada < DateTime.Now);
        }

        public async Task<int> ContarPrestamosActivosClienteAsync(int clienteId)
        {
            return await _context.Prestamos
                .CountAsync(p => p.ClienteId == clienteId && p.Estado == "Activo");
        }
    }
}
