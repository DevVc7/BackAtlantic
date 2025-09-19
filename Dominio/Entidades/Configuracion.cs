using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Biblioteca.Dominio.Entidades
{
    [Table("configuracion")]
    public class Configuracion
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        [Column("clave")]
        public string Clave { get; set; } = string.Empty;

        [Required]
        [MaxLength(255)]
        [Column("valor")]
        public string Valor { get; set; } = string.Empty;

        [MaxLength(255)]
        [Column("descripcion")]
        public string? Descripcion { get; set; }

        [MaxLength(20)]
        [Column("tipo_dato")]
        public string TipoDato { get; set; } = "string";

        [Column("fecha_modificacion")]
        public DateTime FechaModificacion { get; set; } = DateTime.Now;

        [Column("usuario_modificacion_id")]
        public int? UsuarioModificacionId { get; set; }

        // Navigation properties
        [ForeignKey("UsuarioModificacionId")]
        public virtual Usuario? UsuarioModificacion { get; set; }
    }
}
