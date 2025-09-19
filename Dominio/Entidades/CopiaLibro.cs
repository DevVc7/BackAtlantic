using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Biblioteca.Dominio.Entidades
{
    [Table("copias_libros")]
    public class CopiaLibro
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("libro_id")]
        public int LibroId { get; set; }

        [MaxLength(50)]
        [Column("codigo_barras")]
        public string? CodigoBarras { get; set; }

        [MaxLength(100)]
        [Column("codigo_qr")]
        public string? CodigoQr { get; set; }

        [Column("estante_id")]
        public int? EstanteId { get; set; }

        [MaxLength(20)]
        [Column("estado")]
        public string Estado { get; set; } = "Disponible";

        [MaxLength(20)]
        [Column("condicion")]
        public string Condicion { get; set; } = "Bueno";

        [Column("fecha_adquisicion")]
        public DateTime FechaAdquisicion { get; set; } = DateTime.Now;

        [Column("precio_adquisicion", TypeName = "decimal(10,2)")]
        public decimal? PrecioAdquisicion { get; set; }

        [MaxLength(255)]
        [Column("observaciones")]
        public string? Observaciones { get; set; }

        [Column("activo")]
        public bool Activo { get; set; } = true;

        [Column("fecha_baja")]
        public DateTime? FechaBaja { get; set; }

        [MaxLength(255)]
        [Column("motivo_baja")]
        public string? MotivoBaja { get; set; }

        // Navigation properties
        [ForeignKey("LibroId")]
        public virtual Libro Libro { get; set; } = null!;

        [ForeignKey("EstanteId")]
        public virtual Estante? Estante { get; set; }

        public virtual ICollection<SolicitudDetalle> SolicitudDetalles { get; set; } = new List<SolicitudDetalle>();
        public virtual ICollection<PrestamoDetalle> PrestamoDetalles { get; set; } = new List<PrestamoDetalle>();
        public virtual ICollection<VentaDetalle> VentaDetalles { get; set; } = new List<VentaDetalle>();
    }
}
