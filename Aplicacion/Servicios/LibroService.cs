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
    public class LibroService : ILibroService
    {
        private readonly ILibroRepositorio _libroRepositorio;
        private readonly BibliotecaDbContext _context;

        public LibroService(ILibroRepositorio libroRepositorio, BibliotecaDbContext context)
        {
            _libroRepositorio = libroRepositorio;
            _context = context;
        }

        public async Task<LibroResponseDto> RegistrarLibroAsync(RegistrarLibroDto request)
        {
            var libroExistente = await _libroRepositorio.ObtenerPorISBNAsync(request.ISBN);

            if (libroExistente != null)
            {
                throw new Exception("Ya existe un libro con el ISBN ingresado");
            }

            var libro = new Libro
            {
                Titulo = request.Titulo,
                Subtitulo = request.Titulo.ToLower(),
                Isbn = request.ISBN,
                Descripcion = request.Descripcion,
                CategoriaId = request.Categoria,
                FechaPublicacion = request.FechaPublicacion,
                NumeroPaginas = request.NumeroPaginas,
                Idioma = request.Idioma,
                PrecioAlquilerDia = request.PrecioPrestamo,
                PrecioVenta = request.PrecioVenta,
                DisponibleAlquiler = true,
                DisponibleVenta = true,
                Activo = true,
                FechaCreacion = DateTime.Now
            };

            await _libroRepositorio.AgregarAsync(libro);

            return new LibroResponseDto
            {
                Id = libro.Id,
                Titulo = libro.Titulo,
                ISBN = libro.Isbn,
                Categoria = libro.CategoriaId.ToString(),
                Idioma = libro.Idioma,
                PrecioVenta = libro.PrecioVenta,
                PrecioPrestamo = libro.PrecioAlquilerDia
            };
        }

        public async Task<LibroDetalleDto> ObtenerLibroPorIdAsync(int id)
        {
            var libro = await _libroRepositorio.ObtenerPorIdAsync(id);
            var categorias = await _libroRepositorio.ObtenerCategoriasAsync();

            if (libro == null)
            {
                return null;
            }

            var categoria = categorias.FirstOrDefault(c => c.Id == libro.CategoriaId);

            return new LibroDetalleDto
            {
                Id = libro.Id,
                Titulo = libro.Titulo,
                ISBN = libro.Isbn,
                Descripcion = libro.Descripcion,
                Categoria = categoria?.Nombre,
                Idioma = libro.Idioma,
                FechaPublicacion = libro.FechaPublicacion,
                PrecioPrestamo = libro.PrecioAlquilerDia,
                PrecioVenta = libro.PrecioVenta,
                NumeroPaginas = libro.NumeroPaginas
            };
        }

        public async Task<IEnumerable<LibroDetalleDto>> ObtenerTodosLibrosAsync()
        {
            var listaLibros = await _libroRepositorio.ObtenerTodosAsync();
            var categorias = await _libroRepositorio.ObtenerCategoriasAsync();

            if (listaLibros == null)
            {
                return Enumerable.Empty<LibroDetalleDto>();
            }

            var resultado = new List<LibroDetalleDto>();

            foreach (var libro in listaLibros)
            {
                var categoria = categorias.FirstOrDefault(c => c.Id == libro.CategoriaId);

                resultado.Add(new LibroDetalleDto
                {
                    Id = libro.Id,
                    ISBN = libro.Isbn,
                    Titulo = libro.Titulo,
                    Descripcion = libro.Descripcion,
                    Categoria = categoria?.Nombre,
                    Idioma = libro.Idioma,
                    CopiasDisponibles = libro.CopiasLibros.Count(),
                    PrecioPrestamo = libro.PrecioAlquilerDia,
                    PrecioVenta = libro.PrecioVenta,
                    FechaPublicacion = libro.FechaPublicacion,
                    NumeroPaginas = libro.NumeroPaginas
                });
            }

            return resultado;
        }

        public async Task<bool> ActualizarLibroAsync(int id, RegistrarLibroDto rq)
        {
            var libro = await _libroRepositorio.ObtenerPorIdAsync(id);

            if (libro == null)
            {
                return false;
            }

            if (!string.IsNullOrEmpty(rq.ISBN))
            {
                var libroExistente = await _libroRepositorio.ObtenerPorISBNAsync(rq.ISBN);
                if (libroExistente != null && libroExistente.Id != id)
                {
                    throw new Exception("El ISBN ya está en uso por otro libro.");
                }
            }

            if (!libro.Activo)
            {
                throw new Exception("El libro no se encuentra habilitado");
            }

            libro.Titulo = rq.Titulo ?? libro.Titulo;
            libro.Subtitulo = rq.Titulo != null ? rq.Titulo.ToLower() : libro.Subtitulo;
            libro.Isbn = rq.ISBN ?? libro.Isbn;
            libro.Descripcion = rq.Descripcion ?? libro.Descripcion;
            libro.CategoriaId = rq.Categoria != 0 ? rq.Categoria : libro.CategoriaId;
            libro.FechaPublicacion = rq.FechaPublicacion != default ? rq.FechaPublicacion : libro.FechaPublicacion;
            libro.NumeroPaginas = rq.NumeroPaginas != 0 ? rq.NumeroPaginas : libro.NumeroPaginas;
            libro.Idioma = rq.Idioma ?? libro.Idioma;
            libro.PrecioAlquilerDia = rq.PrecioPrestamo != 0 ?
                rq.PrecioPrestamo : libro.PrecioAlquilerDia;
            libro.PrecioVenta = rq.PrecioVenta != 0 ? rq.PrecioVenta : libro.PrecioVenta;

            await _libroRepositorio.ActualizarAsync(libro);

            return true;
        }

        public async Task<bool> EliminarLibroAsync(int id)
        {
            var libro = await _libroRepositorio.ObtenerPorIdAsync(id);
            if (libro == null)
            {
                return false;
            }

            libro.Activo = false;

            await _libroRepositorio.ActualizarAsync(libro);

            return true;
        }
    }
}
