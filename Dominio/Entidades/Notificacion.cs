using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Biblioteca.Dominio.Entidades
{
    [Table("notificaciones")]
    public class Notificacion
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("cliente_id")]
        public int ClienteId { get; set; }

        [Required]
        [MaxLength(255)]
        [Column("titulo")]
        public string Titulo { get; set; } = string.Empty;

        [Required]
        [Column("mensaje")]
        public string Mensaje { get; set; } = string.Empty;

        [Required]
        [MaxLength(50)]
        [Column("tipo")]
        public string Tipo { get; set; } = string.Empty;

        [Column("leida")]
        public bool Leida { get; set; } = false;

        [Column("fecha_creacion")]
        public DateTime FechaCreacion { get; set; } = DateTime.Now;

        [Column("fecha_lectura")]
        public DateTime? FechaLectura { get; set; }

        [Column("fecha_expiracion")]
        public DateTime? FechaExpiracion { get; set; }

        // Navigation properties
        [ForeignKey("ClienteId")]
        public virtual Cliente Cliente { get; set; } = null!;
    }
}
