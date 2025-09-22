using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace Biblioteca.Dominio.DTOs
{
    public class LibroDto
    {
        public int Id { get; set; }
        public string Titulo { get; set; } = string.Empty;
        public string ISBN { get; set; } = string.Empty;
        public string Categoria { get; set; } = string.Empty;
        public string Idioma { get; set; } = string.Empty;
        public decimal PrecioVenta { get; set; }
        public decimal PrecioPrestamo { get; set; }
        public int CopiasDisponibles { get; set; }
        public int CopiasTotal { get; set; }
    }

    public class RegistrarLibroDto
    {
        [Required(ErrorMessage = "El título es un campo requerido")]
        public string Titulo { get; set; } = string.Empty;
        [Required(ErrorMessage = "El ISBN es un campo requerido")]
        public string ISBN { get; set; } = string.Empty;
        [Required(ErrorMessage = "La categoria es un campo requerido")]
        public int Categoria { get; set; } = 0;
        [Required(ErrorMessage = "La descripción es un campo requerido")]
        [MaxLength(200, ErrorMessage = "La descripción no puede exceder 200 caracteres")]
        public string? Descripcion { get; set; }
        [Required(ErrorMessage = "El idioma es un campo requerido")]
        public string Idioma { get; set; } = "Español";
        [Required(ErrorMessage = "La fecha de publiación es un campo requerido")]
        public DateTime FechaPublicacion { get; set; }
        [Required(ErrorMessage = "El número de páginas es un campo requerido")]
        public int NumeroPaginas { get; set; }
        [Required(ErrorMessage = "El precio de venta es un campo requerido")]
        public decimal PrecioVenta { get; set; }
        [Required(ErrorMessage = "El precio de alquiler es un campo requerido")]
        public decimal PrecioPrestamo { get; set; }
    }

    public class LibroDetalleDto : LibroDto
    {
        public string? Descripcion { get; set; }
        public DateTime? FechaPublicacion { get; set; }
        public int? NumeroPaginas { get; set; }
    }

    public class AutorDto
    {
        public int Id { get; set; }
        public string Nombres { get; set; } = string.Empty;
        public string Apellidos { get; set; } = string.Empty;
    }

    public class CopiaLibroDto
    {
        public int Id { get; set; }
        public string CodigoBarras { get; set; } = string.Empty;
        public string Estado { get; set; } = string.Empty;
        public string? Ubicacion { get; set; }
    }

    public class DisponibilidadLibroDto
    {
        public int LibroId { get; set; }
        public string Titulo { get; set; } = string.Empty;
        public int CopiasDisponibles { get; set; }
        public int CopiasTotal { get; set; }
        public bool Disponible { get; set; }
        public List<int> CopiasDisponiblesIds { get; set; } = new List<int>();
    }

    public class LibroResponseDto
    {
        public int Id { get; set; }
        public string Titulo { get; set; } = string.Empty;
        public string ISBN { get; set; } = string.Empty;
        public string Categoria { get; set; } = string.Empty;
        public string Idioma { get; set; } = string.Empty;
        public decimal PrecioVenta { get; set; }
        public decimal PrecioPrestamo { get; set; }
    }
}
