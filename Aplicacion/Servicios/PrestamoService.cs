using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Biblioteca.Dominio.DTOs;
using Biblioteca.Aplicacion.Interfaces;

namespace Biblioteca.Aplicacion.Servicios
{
    public class PrestamoService : IPrestamoRepositorio
    {
        private readonly IPrestamoRepositorio _prestamoRepositorio;

        public PrestamoService(IPrestamoRepositorio prestamoRepositorio)
        {
            _prestamoRepositorio = prestamoRepositorio ?? throw new ArgumentNullException(nameof(prestamoRepositorio));
        }

        public async Task<ResultadoPrestamoDto> RegistrarPrestamoAsync(RegistrarPrestamoDto request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            return await _prestamoRepositorio.RegistrarPrestamoAsync(request);
        }

        public async Task<ResultadoPrestamoDto> DevolverPrestamoAsync(int prestamoId)
        {
            if (prestamoId <= 0)
                throw new ArgumentException("ID de préstamo no válido", nameof(prestamoId));

            return await _prestamoRepositorio.DevolverPrestamoAsync(prestamoId);
        }

        public async Task<bool> ValidarDisponibilidadLibrosAsync(List<int> copiaLibroIds)
        {
            if (copiaLibroIds == null || !copiaLibroIds.Any())
                return false;

            return await _prestamoRepositorio.ValidarDisponibilidadLibrosAsync(copiaLibroIds);
        }

        public async Task<bool> ClienteTienePrestamosVencidosAsync(int clienteId)
        {
            if (clienteId <= 0)
                return false;

            return await _prestamoRepositorio.ClienteTienePrestamosVencidosAsync(clienteId);
        }

        public async Task<int> ContarPrestamosActivosClienteAsync(int clienteId)
        {
            if (clienteId <= 0)
                return 0;

            return await _prestamoRepositorio.ContarPrestamosActivosClienteAsync(clienteId);
        }
    }
}
