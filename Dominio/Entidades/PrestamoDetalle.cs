using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Biblioteca.Dominio.Entidades
{
    [Table("prestamo_detalles")]
    public class PrestamoDetalle
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("prestamo_id")]
        public int PrestamoId { get; set; }

        [Column("copia_libro_id")]
        public int CopiaLibroId { get; set; }

        [Column("fecha_devolucion_real")]
        public DateTime? FechaDevolucionReal { get; set; }

        [MaxLength(20)]
        [Column("estado")]
        public string Estado { get; set; } = "Prestado";

        [Column("penalidad", TypeName = "decimal(10,2)")]
        public decimal Penalidad { get; set; } = 0;

        [MaxLength(255)]
        [Column("observaciones")]
        public string? Observaciones { get; set; }

        // Navigation properties
        [ForeignKey("PrestamoId")]
        public virtual Prestamo Prestamo { get; set; } = null!;

        [ForeignKey("CopiaLibroId")]
        public virtual CopiaLibro CopiaLibro { get; set; } = null!;
    }
}
