using System.ComponentModel.DataAnnotations;

namespace Biblioteca.Dominio.DTOs
{
    public class CrearUsuarioDto
    {
        [Required]
        public string Username { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        public string NombreCompleto { get; set; }

        [Required]
        public int IdRol { get; set; }
    }
}
