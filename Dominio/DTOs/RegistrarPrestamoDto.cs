using System.ComponentModel.DataAnnotations;

namespace Biblioteca.Dominio.DTOs
{
    public class RegistrarPrestamoDto
    {
        [Required(ErrorMessage = "El ID del cliente es requerido")]
        public int ClienteId { get; set; }

        [Required(ErrorMessage = "El ID del usuario es requerido")]
        public int UsuarioId { get; set; }

        [Required(ErrorMessage = "Debe seleccionar al menos un libro")]
        [MinLength(1, ErrorMessage = "Debe seleccionar al menos un libro")]
        [MaxLength(3, ErrorMessage = "No se pueden prestar más de 3 libros")]
        public List<int> CopiaLibroIds { get; set; } = new List<int>();

        public string? Observaciones { get; set; }
    }
}
