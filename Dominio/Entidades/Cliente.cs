using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Biblioteca.Dominio.Entidades
{
    [Table("clientes")]
    public class Cliente
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        [Column("email")]
        public string Email { get; set; } = string.Empty;

        [Required]
        [MaxLength(255)]
        [Column("password_hash")]
        public string PasswordHash { get; set; } = string.Empty;

        [Required]
        [MaxLength(100)]
        [Column("nombres")]
        public string Nombres { get; set; } = string.Empty;

        [Required]
        [MaxLength(100)]
        [Column("apellidos")]
        public string Apellidos { get; set; } = string.Empty;

        [Required]
        [MaxLength(20)]
        [Column("tipo_documento")]
        public string TipoDocumento { get; set; } = string.Empty;

        [Required]
        [MaxLength(20)]
        [Column("numero_documento")]
        public string NumeroDocumento { get; set; } = string.Empty;

        [Required]
        [MaxLength(20)]
        [Column("telefono")]
        public string Telefono { get; set; } = string.Empty;

        [Required]
        [MaxLength(255)]
        [Column("direccion")]
        public string Direccion { get; set; } = string.Empty;

        [Required]
        [MaxLength(10)]
        [Column("ubigeo")]
        public string Ubigeo { get; set; } = string.Empty;

        [MaxLength(100)]
        [Column("distrito")]
        public string? Distrito { get; set; }

        [MaxLength(100)]
        [Column("provincia")]
        public string? Provincia { get; set; }

        [MaxLength(100)]
        [Column("departamento")]
        public string? Departamento { get; set; }

        [Column("telefono_verificado")]
        public bool TelefonoVerificado { get; set; } = false;

        [MaxLength(6)]
        [Column("codigo_otp")]
        public string? CodigoOtp { get; set; }

        [Column("otp_expiracion")]
        public DateTime? OtpExpiracion { get; set; }

        [Column("activo")]
        public bool Activo { get; set; } = true;

        [Column("en_lista_negra")]
        public bool EnListaNegra { get; set; } = false;

        [MaxLength(255)]
        [Column("motivo_lista_negra")]
        public string? MotivoListaNegra { get; set; }

        [Column("fecha_lista_negra")]
        public DateTime? FechaListaNegra { get; set; }

        [Column("fecha_creacion")]
        public DateTime FechaCreacion { get; set; } = DateTime.Now;

        [Column("fecha_verificacion")]
        public DateTime? FechaVerificacion { get; set; }

        // Navigation properties
        public virtual ICollection<Solicitud> Solicitudes { get; set; } = new List<Solicitud>();
        public virtual ICollection<Prestamo> Prestamos { get; set; } = new List<Prestamo>();
        public virtual ICollection<Venta> Ventas { get; set; } = new List<Venta>();
        public virtual ICollection<Notificacion> Notificaciones { get; set; } = new List<Notificacion>();
    }
}
