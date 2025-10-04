using System.ComponentModel.DataAnnotations;

namespace Biblioteca.Dominio.DTOs
{

    public class RolDto
    {
        public int IdRol { get; set; }
        public string Nombre { get; set; }
    }

    public class RegistrarRolDto
    {
        [Required(ErrorMessage = "El nombre del rol es requerido")]
        [MaxLength(100, ErrorMessage = "El nombre del rol no puede exceder 100 caracteres")]
        public string Nombre { get; set; } = string.Empty;
        public string? Descripcion { get; set; } = string.Empty;
    }

    public class RolResponseDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string? Descripcion { get; set; } = string.Empty;
        public string Estado { get; set; } = string.Empty;  
    }
}
