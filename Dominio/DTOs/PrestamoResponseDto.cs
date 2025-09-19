namespace Biblioteca.Dominio.DTOs
{
    public class PrestamoResponseDto
    {
        public int Id { get; set; }
        public int ClienteId { get; set; }
        public string NombreCliente { get; set; } = string.Empty;
        public DateTime FechaPrestamo { get; set; }
        public DateTime FechaDevolucionProgramada { get; set; }
        public DateTime? FechaDevolucionReal { get; set; }
        public string Estado { get; set; } = string.Empty;
        public decimal MontoTotal { get; set; }
        public List<LibroPrestamoDto> Libros { get; set; } = new List<LibroPrestamoDto>();
    }

    public class LibroPrestamoDto
    {
        public int CopiaLibroId { get; set; }
        public string CodigoBarras { get; set; } = string.Empty;
        public string TituloLibro { get; set; } = string.Empty;
        public decimal PrecioPrestamo { get; set; }
    }
}
