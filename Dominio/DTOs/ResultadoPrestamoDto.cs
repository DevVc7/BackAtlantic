namespace Biblioteca.Dominio.DTOs
{
    public class ResultadoPrestamoDto
    {
        public bool Exitoso { get; set; } = false;
        public string Mensaje { get; set; } = string.Empty;
        public List<string> Errores { get; set; } = new List<string>();
        public PrestamoResponseDto? Prestamo { get; set; }
    }
}
