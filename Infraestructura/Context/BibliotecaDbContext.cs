using Biblioteca.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estacionamiento.Infraestructura.Context
{
    public class BibliotecaDbContext : DbContext
    {
        public BibliotecaDbContext(DbContextOptions<BibliotecaDbContext> options) : base(options) { }
        public DbSet<Rol> Roles { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Libro> Libros { get; set; }
        public DbSet<Estante> Estantes { get; set; }
        public DbSet<CopiaLibro> CopiasLibros { get; set; }
        public DbSet<Producto> Productos { get; set; }
        public DbSet<MetodoPago> MetodosPago { get; set; }
        public DbSet<AgenciaDelivery> AgenciasDelivery { get; set; }
        public DbSet<Solicitud> Solicitudes { get; set; }
        public DbSet<SolicitudDetalle> SolicitudDetalles { get; set; }
        public DbSet<Prestamo> Prestamos { get; set; }
        public DbSet<PrestamoDetalle> PrestamoDetalles { get; set; }
        public DbSet<Venta> Ventas { get; set; }
        public DbSet<VentaDetalle> VentaDetalles { get; set; }
        public DbSet<Auditoria> Auditorias { get; set; }
        public DbSet<Notificacion> Notificaciones { get; set; }
        public DbSet<Configuracion> Configuraciones { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configuración de índices únicos
            modelBuilder.Entity<Usuario>()
                .HasIndex(u => u.Username)
                .IsUnique();

            modelBuilder.Entity<Usuario>()
                .HasIndex(u => u.Email)
                .IsUnique();

            modelBuilder.Entity<Cliente>()
                .HasIndex(c => c.Email)
                .IsUnique();

            modelBuilder.Entity<Cliente>()
                .HasIndex(c => c.NumeroDocumento)
                .IsUnique();

            modelBuilder.Entity<Libro>()
                .HasIndex(l => l.Isbn)
                .IsUnique();

            modelBuilder.Entity<CopiaLibro>()
                .HasIndex(cl => cl.CodigoBarras)
                .IsUnique();

            modelBuilder.Entity<CopiaLibro>()
                .HasIndex(cl => cl.CodigoQr)
                .IsUnique();

            modelBuilder.Entity<Producto>()
                .HasIndex(p => p.Codigo)
                .IsUnique();

            modelBuilder.Entity<Estante>()
                .HasIndex(e => e.Codigo)
                .IsUnique();

            modelBuilder.Entity<Configuracion>()
                .HasIndex(c => c.Clave)
                .IsUnique();

            // Configuración de valores por defecto
            modelBuilder.Entity<Rol>()
                .Property(r => r.FechaCreacion)
                .HasDefaultValueSql("GETDATE()");

            modelBuilder.Entity<Usuario>()
                .Property(u => u.FechaCreacion)
                .HasDefaultValueSql("GETDATE()");

            modelBuilder.Entity<Cliente>()
                .Property(c => c.FechaCreacion)
                .HasDefaultValueSql("GETDATE()");

            modelBuilder.Entity<Libro>()
                .Property(l => l.FechaCreacion)
                .HasDefaultValueSql("GETDATE()");

            modelBuilder.Entity<CopiaLibro>()
                .Property(cl => cl.FechaAdquisicion)
                .HasDefaultValueSql("GETDATE()");

            modelBuilder.Entity<Producto>()
                .Property(p => p.FechaCreacion)
                .HasDefaultValueSql("GETDATE()");

            modelBuilder.Entity<Solicitud>()
                .Property(s => s.FechaSolicitud)
                .HasDefaultValueSql("GETDATE()");

            modelBuilder.Entity<Prestamo>()
                .Property(p => p.FechaPrestamo)
                .HasDefaultValueSql("GETDATE()");

            modelBuilder.Entity<Venta>()
                .Property(v => v.FechaVenta)
                .HasDefaultValueSql("GETDATE()");

            modelBuilder.Entity<Auditoria>()
                .Property(a => a.FechaOperacion)
                .HasDefaultValueSql("GETDATE()");

            modelBuilder.Entity<Notificacion>()
                .Property(n => n.FechaCreacion)
                .HasDefaultValueSql("GETDATE()");

            modelBuilder.Entity<Configuracion>()
                .Property(c => c.FechaModificacion)
                .HasDefaultValueSql("GETDATE()");
        }
    }
}
