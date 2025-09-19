using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Biblioteca.Dominio.Entidades
{
    [Table("solicitudes")]
    public class Solicitud
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("cliente_id")]
        public int ClienteId { get; set; }

        [Required]
        [MaxLength(20)]
        [Column("tipo_solicitud")]
        public string TipoSolicitud { get; set; } = string.Empty;

        [MaxLength(20)]
        [Column("estado")]
        public string Estado { get; set; } = "Pendiente";

        [Column("fecha_solicitud")]
        public DateTime FechaSolicitud { get; set; } = DateTime.Now;

        [Column("fecha_respuesta")]
        public DateTime? FechaRespuesta { get; set; }

        [Column("usuario_respuesta_id")]
        public int? UsuarioRespuestaId { get; set; }

        [MaxLength(255)]
        [Column("observaciones")]
        public string? Observaciones { get; set; }

        [MaxLength(255)]
        [Column("motivo_rechazo")]
        public string? MotivoRechazo { get; set; }

        [Column("total_estimado", TypeName = "decimal(10,2)")]
        public decimal? TotalEstimado { get; set; }

        [Column("requiere_delivery")]
        public bool RequiereDelivery { get; set; } = false;

        [MaxLength(255)]
        [Column("direccion_entrega")]
        public string? DireccionEntrega { get; set; }

        [Column("agencia_delivery_id")]
        public int? AgenciaDeliveryId { get; set; }

        // Navigation properties
        [ForeignKey("ClienteId")]
        public virtual Cliente Cliente { get; set; } = null!;

        [ForeignKey("UsuarioRespuestaId")]
        public virtual Usuario? UsuarioRespuesta { get; set; }

        [ForeignKey("AgenciaDeliveryId")]
        public virtual AgenciaDelivery? AgenciaDelivery { get; set; }

        public virtual ICollection<SolicitudDetalle> SolicitudDetalles { get; set; } = new List<SolicitudDetalle>();
        public virtual ICollection<Prestamo> Prestamos { get; set; } = new List<Prestamo>();
        public virtual ICollection<Venta> Ventas { get; set; } = new List<Venta>();
    }
}
