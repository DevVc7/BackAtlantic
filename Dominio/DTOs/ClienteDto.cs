using System.ComponentModel.DataAnnotations;

namespace Biblioteca.Dominio.DTOs
{
    public class RegistrarClienteDto
    {
        [Required(ErrorMessage = "Los nombres son requeridos")]
        [MaxLength(100, ErrorMessage = "Los nombres no pueden exceder 100 caracteres")]
        public string Nombres { get; set; } = string.Empty;

        [Required(ErrorMessage = "Los apellidos son requeridos")]
        [MaxLength(100, ErrorMessage = "Los apellidos no pueden exceder 100 caracteres")]
        public string Apellidos { get; set; } = string.Empty;

        [Required(ErrorMessage = "El tipo de documento es requerido")]
        public string TipoDocumento { get; set; } = string.Empty;

        [Required(ErrorMessage = "El número de documento es requerido")]
        [MaxLength(20, ErrorMessage = "El número de documento no puede exceder 20 caracteres")]
        public string NumeroDocumento { get; set; } = string.Empty;

        [Required(ErrorMessage = "El email es requerido")]
        [EmailAddress(ErrorMessage = "El email no tiene un formato válido")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "El teléfono es requerido")]
        [MaxLength(15, ErrorMessage = "El teléfono no puede exceder 15 caracteres")]
        public string Telefono { get; set; } = string.Empty;

        [Required(ErrorMessage = "La dirección es requerida")]
        [MaxLength(200, ErrorMessage = "La dirección no puede exceder 200 caracteres")]
        public string Direccion { get; set; } = string.Empty;

        [Required(ErrorMessage = "El ubigeo es requerido")]
        [MaxLength(6, ErrorMessage = "El ubigeo debe tener 6 caracteres")]
        public string Ubigeo { get; set; } = string.Empty;

        public DateTime? FechaNacimiento { get; set; }
    }

    public class ClienteResponseDto
    {
        public int Id { get; set; }
        public string Nombres { get; set; } = string.Empty;
        public string Apellidos { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Telefono { get; set; } = string.Empty;
        public string Estado { get; set; } = string.Empty;
    }

    public class ClienteDetalleDto : ClienteResponseDto
    {
        public string TipoDocumento { get; set; } = string.Empty;
        public string NumeroDocumento { get; set; } = string.Empty;
        public string Direccion { get; set; } = string.Empty;
        public DateTime FechaCreacion { get; set; }
        public bool EnListaNegra { get; set; }
        public int PrestamosActivos { get; set; }
    }

    public class VerificarOTPDto
    {
        [Required(ErrorMessage = "El código OTP es requerido")]
        [StringLength(6, MinimumLength = 6, ErrorMessage = "El código OTP debe tener 6 dígitos")]
        public string CodigoOTP { get; set; } = string.Empty;
    }
}
