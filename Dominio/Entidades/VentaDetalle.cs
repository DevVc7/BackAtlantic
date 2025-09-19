using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Biblioteca.Dominio.Entidades
{
    [Table("venta_detalles")]
    public class VentaDetalle
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("venta_id")]
        public int VentaId { get; set; }

        [Required]
        [MaxLength(20)]
        [Column("tipo_item")]
        public string TipoItem { get; set; } = string.Empty;

        [Column("item_id")]
        public int ItemId { get; set; }

        [Column("copia_libro_id")]
        public int? CopiaLibroId { get; set; }

        [Column("cantidad")]
        public int Cantidad { get; set; }

        [Column("precio_unitario", TypeName = "decimal(10,2)")]
        public decimal PrecioUnitario { get; set; }

        [Column("subtotal", TypeName = "decimal(10,2)")]
        public decimal Subtotal { get; set; }

        // Navigation properties
        [ForeignKey("VentaId")]
        public virtual Venta Venta { get; set; } = null!;

        [ForeignKey("CopiaLibroId")]
        public virtual CopiaLibro? CopiaLibro { get; set; }
    }
}
