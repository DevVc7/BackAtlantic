using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Biblioteca.Dominio.Entidades
{
    [Table("auditoria")]
    public class Auditoria
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        [Column("tabla_afectada")]
        public string TablaAfectada { get; set; } = string.Empty;

        [Required]
        [MaxLength(20)]
        [Column("operacion")]
        public string Operacion { get; set; } = string.Empty;

        [Column("registro_id")]
        public int RegistroId { get; set; }

        [Column("usuario_id")]
        public int? UsuarioId { get; set; }

        [Column("fecha_operacion")]
        public DateTime FechaOperacion { get; set; } = DateTime.Now;

        [Column("valores_anteriores")]
        public string? ValoresAnteriores { get; set; }

        [Column("valores_nuevos")]
        public string? ValoresNuevos { get; set; }

        [MaxLength(45)]
        [Column("ip_address")]
        public string? IpAddress { get; set; }

        [MaxLength(255)]
        [Column("user_agent")]
        public string? UserAgent { get; set; }

        // Navigation properties
        [ForeignKey("UsuarioId")]
        public virtual Usuario? Usuario { get; set; }
    }
}
