namespace Biblioteca.Dominio.DTOs
{
    public class LibroDto
    {
        public int Id { get; set; }
        public string Titulo { get; set; } = string.Empty;
        public string ISBN { get; set; } = string.Empty;
        public string Categoria { get; set; } = string.Empty;
        public string Editorial { get; set; } = string.Empty;
        public List<string> Autores { get; set; } = new List<string>();
        public decimal PrecioVenta { get; set; }
        public decimal PrecioPrestamo { get; set; }
        public int CopiasDisponibles { get; set; }
        public int CopiasTotal { get; set; }
    }

    public class LibroDetalleDto : LibroDto
    {
        public string? Descripcion { get; set; }
        public DateTime? FechaPublicacion { get; set; }
        public int? NumeroPaginas { get; set; }
        public List<AutorDto> Autores { get; set; } = new List<AutorDto>();
        public List<CopiaLibroDto> Copias { get; set; } = new List<CopiaLibroDto>();
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
}
