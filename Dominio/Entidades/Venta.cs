using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Biblioteca.Dominio.Entidades
{
    [Table("ventas")]
    public class Venta
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("solicitud_id")]
        public int? SolicitudId { get; set; }

        [Column("cliente_id")]
        public int ClienteId { get; set; }

        [Column("usuario_id")]
        public int UsuarioId { get; set; }

        [Column("fecha_venta")]
        public DateTime FechaVenta { get; set; } = DateTime.Now;

        [Column("subtotal", TypeName = "decimal(10,2)")]
        public decimal Subtotal { get; set; }

        [Column("impuestos", TypeName = "decimal(10,2)")]
        public decimal Impuestos { get; set; } = 0;

        [Column("total", TypeName = "decimal(10,2)")]
        public decimal Total { get; set; }

        [Column("metodo_pago_id")]
        public int MetodoPagoId { get; set; }

        [MaxLength(20)]
        [Column("estado")]
        public string Estado { get; set; } = "Completada";

        [MaxLength(255)]
        [Column("observaciones")]
        public string? Observaciones { get; set; }

        // Navigation properties
        [ForeignKey("SolicitudId")]
        public virtual Solicitud? Solicitud { get; set; }

        [ForeignKey("ClienteId")]
        public virtual Cliente Cliente { get; set; } = null!;

        [ForeignKey("UsuarioId")]
        public virtual Usuario Usuario { get; set; } = null!;

        [ForeignKey("MetodoPagoId")]
        public virtual MetodoPago MetodoPago { get; set; } = null!;

        public virtual ICollection<VentaDetalle> VentaDetalles { get; set; } = new List<VentaDetalle>();
    }
}
