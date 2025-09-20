using Azure.Core;
using Biblioteca.Aplicacion.Interfaces;
using Biblioteca.Dominio.DTOs;
using Biblioteca.Dominio.Entidades;
using Estacionamiento.Infraestructura.Context;
using Estacionamiento.Infraestructura.IRepositorios;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Biblioteca.Aplicacion.Servicios
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepositorio _clienteRepositorio;
        private readonly BibliotecaDbContext _context;

        public ClienteService(IClienteRepositorio clienteRepositorio, BibliotecaDbContext context)
        {
            _clienteRepositorio = clienteRepositorio;
            _context = context;
        }

        public async Task<ClienteResponseDto> RegistrarClienteAsync(RegistrarClienteDto request)
        {
            var clienteExistente = await _clienteRepositorio.ObtenerPorEmailONumeroDocumentoAsync(request.Email, request.NumeroDocumento);

            if (clienteExistente != null)
            {
                throw new Exception("Ya existe un cliente con ese email o número de documento");
            }

            var cliente = new Cliente
            {
                Nombres = request.Nombres,
                Apellidos = request.Apellidos,
                PasswordHash = "abc123*+",
                TipoDocumento = request.TipoDocumento,
                NumeroDocumento = request.NumeroDocumento,
                Email = request.Email,
                Telefono = request.Telefono,
                Direccion = request.Direccion,
                Ubigeo = request.Ubigeo,
                Activo = true,
                FechaCreacion = DateTime.Now
            };

            await _clienteRepositorio.AgregarAsync(cliente);

            return new ClienteResponseDto
            {
                Id = cliente.Id,
                Nombres = cliente.Nombres,
                Apellidos = cliente.Apellidos,
                Email = cliente.Email,
                Telefono = cliente.Telefono,
                Estado = cliente.Activo.ToString()
            };
        }

        public async Task<ClienteDetalleDto> ObtenerClientePorIdAsync(int id)
        {
            var cliente = await _clienteRepositorio.ObtenerPorIdAsync(id);

            if (cliente == null)
            {
                return null;
            }

            var prestamosActivos = await _context.Prestamos
                .Where(p => p.ClienteId == id && p.Estado == "Activo")
                .CountAsync();

            return new ClienteDetalleDto
            {
                Id = cliente.Id,
                Nombres = cliente.Nombres,
                Apellidos = cliente.Apellidos,
                TipoDocumento = cliente.TipoDocumento,
                NumeroDocumento = cliente.NumeroDocumento,
                Email = cliente.Email,
                Telefono = cliente.Telefono,
                Direccion = cliente.Direccion,
                Estado = cliente.Activo.ToString(),
                FechaCreacion = cliente.FechaCreacion,
                EnListaNegra = cliente.EnListaNegra,
                PrestamosActivos = prestamosActivos
            };
        }

        public async Task<bool> VerificarOtpAsync(int id, VerificarOTPDto request)
        {
            var cliente = await _clienteRepositorio.ObtenerPorIdAsync(id);

            if (cliente == null)
            {
                return false;
            }

            if (cliente.CodigoOtp != null)
            {
                throw new Exception("Cliente ya está verificado");
            }

            if (request.CodigoOTP.Length != 6 || !request.CodigoOTP.All(char.IsDigit))
            {
                throw new Exception("Código OTP inválido");
            }

            cliente.CodigoOtp = request.CodigoOTP;
            cliente.TelefonoVerificado = true;
            cliente.OtpExpiracion = DateTime.Now.AddYears(1);
            cliente.FechaVerificacion = DateTime.Now; 

            await _clienteRepositorio.ActualizarAsync(cliente);

            return true;
        }

        public async Task<IEnumerable<Cliente>> ObtenerTodosLosClientesAsync()
        {
            var lista = await _clienteRepositorio.ObtenerTodosAsync();

            if (lista == null)
            {
                return null;
            }

            return lista;
        }

        public async Task<bool> ActualizarClienteAsync(int id, ActualizarClienteDto rq)
        {
            var cliente = await _clienteRepositorio.ObtenerPorIdAsync(id);

            if (cliente == null)
            {
                return false;
            }

            if (!string.IsNullOrEmpty(rq.Email) || !string.IsNullOrEmpty(rq.NumeroDocumento))
            {
                var clienteExistente = await _clienteRepositorio.ObtenerPorEmailONumeroDocumentoAsync(rq.Email, rq.NumeroDocumento);
                if (clienteExistente != null && clienteExistente.Id != id)
                {
                    throw new Exception("El email o número de documento ya está en uso por otro cliente.");
                }
            }

            if(cliente.CodigoOtp == null || !cliente.TelefonoVerificado)
            {
                throw new Exception("El cliente aún no está verificado.");
            }

            cliente.Nombres = rq.Nombres ?? cliente.Nombres;
            cliente.Apellidos = rq.Apellidos ?? cliente.Apellidos;
            cliente.TipoDocumento = rq.TipoDocumento ?? cliente.TipoDocumento;
            cliente.NumeroDocumento = rq.NumeroDocumento ?? cliente.NumeroDocumento;
            cliente.Email = rq.Email ?? cliente.Email;
            cliente.Telefono = rq.Telefono ?? cliente.Telefono;
            cliente.Direccion = rq.Direccion ?? cliente.Direccion;
            cliente.Ubigeo = rq.Ubigeo ?? cliente.Ubigeo;

            await _clienteRepositorio.ActualizarAsync(cliente);

            return true;
        }

        public Task<bool> EliminarClienteAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
