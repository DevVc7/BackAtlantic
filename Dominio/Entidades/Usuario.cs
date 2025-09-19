using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Biblioteca.Dominio.Entidades
{
    [Table("usuarios")]
    public class Usuario
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        [Column("username")]
        public string Username { get; set; } = string.Empty;

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

        [MaxLength(20)]
        [Column("telefono")]
        public string? Telefono { get; set; }

        [Column("rol_id")]
        public int RolId { get; set; }

        [Column("activo")]
        public bool Activo { get; set; } = true;

        [Column("fecha_creacion")]
        public DateTime FechaCreacion { get; set; } = DateTime.Now;

        [Column("ultimo_acceso")]
        public DateTime? UltimoAcceso { get; set; }

        // Navigation properties
        [ForeignKey("RolId")]
        public virtual Rol Rol { get; set; } = null!;

        public virtual ICollection<Solicitud> SolicitudesAprobadas { get; set; } = new List<Solicitud>();
        public virtual ICollection<Prestamo> Prestamos { get; set; } = new List<Prestamo>();
        public virtual ICollection<Venta> Ventas { get; set; } = new List<Venta>();
        public virtual ICollection<Auditoria> Auditorias { get; set; } = new List<Auditoria>();
    }
}
