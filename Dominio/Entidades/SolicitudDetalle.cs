using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Biblioteca.Dominio.Entidades
{
    [Table("solicitud_detalles")]
    public class SolicitudDetalle
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("solicitud_id")]
        public int SolicitudId { get; set; }

        [Required]
        [MaxLength(20)]
        [Column("tipo_item")]
        public string TipoItem { get; set; } = string.Empty;

        [Column("item_id")]
        public int ItemId { get; set; }

        [Column("copia_libro_id")]
        public int? CopiaLibroId { get; set; }

        [Required]
        [MaxLength(20)]
        [Column("tipo_operacion")]
        public string TipoOperacion { get; set; } = string.Empty;

        [Column("cantidad")]
        public int Cantidad { get; set; } = 1;

        [Column("precio_unitario", TypeName = "decimal(10,2)")]
        public decimal PrecioUnitario { get; set; }

        [Column("dias_alquiler")]
        public int? DiasAlquiler { get; set; }

        [Column("subtotal", TypeName = "decimal(10,2)")]
        public decimal Subtotal { get; set; }

        // Navigation properties
        [ForeignKey("SolicitudId")]
        public virtual Solicitud Solicitud { get; set; } = null!;

        [ForeignKey("CopiaLibroId")]
        public virtual CopiaLibro? CopiaLibro { get; set; }
    }
}
