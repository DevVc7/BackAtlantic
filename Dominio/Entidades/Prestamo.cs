using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Biblioteca.Dominio.Entidades
{
    [Table("prestamos")]
    public class Prestamo
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("solicitud_id")]
        public int SolicitudId { get; set; }

        [Column("cliente_id")]
        public int ClienteId { get; set; }

        [Column("usuario_id")]
        public int UsuarioId { get; set; }

        [Column("fecha_prestamo")]
        public DateTime FechaPrestamo { get; set; } = DateTime.Now;

        [Column("fecha_devolucion_programada")]
        public DateTime FechaDevolucionProgramada { get; set; }

        [Column("fecha_devolucion_real")]
        public DateTime? FechaDevolucionReal { get; set; }

        [MaxLength(20)]
        [Column("estado")]
        public string Estado { get; set; } = "Activo";

        [Column("total_pagado", TypeName = "decimal(10,2)")]
        public decimal TotalPagado { get; set; }

        [Column("metodo_pago_id")]
        public int MetodoPagoId { get; set; }

        [Column("penalidad_aplicada", TypeName = "decimal(10,2)")]
        public decimal PenalidadAplicada { get; set; } = 0;

        [MaxLength(255)]
        [Column("observaciones")]
        public string? Observaciones { get; set; }

        // Navigation properties
        [ForeignKey("SolicitudId")]
        public virtual Solicitud Solicitud { get; set; } = null!;

        [ForeignKey("ClienteId")]
        public virtual Cliente Cliente { get; set; } = null!;

        [ForeignKey("UsuarioId")]
        public virtual Usuario Usuario { get; set; } = null!;

        [ForeignKey("MetodoPagoId")]
        public virtual MetodoPago MetodoPago { get; set; } = null!;

        public virtual ICollection<PrestamoDetalle> PrestamoDetalles { get; set; } = new List<PrestamoDetalle>();
    }
}
