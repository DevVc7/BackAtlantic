using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Biblioteca.Dominio.Entidades
{
    [Table("agencias_delivery")]
    public class AgenciaDelivery
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        [Column("nombre")]
        public string Nombre { get; set; } = string.Empty;

        [MaxLength(20)]
        [Column("telefono")]
        public string? Telefono { get; set; }

        [MaxLength(100)]
        [Column("email")]
        public string? Email { get; set; }

        [Column("costo_base", TypeName = "decimal(10,2)")]
        public decimal? CostoBase { get; set; }

        [Column("tiempo_entrega_horas")]
        public int? TiempoEntregaHoras { get; set; }

        [Column("activo")]
        public bool Activo { get; set; } = true;

        // Navigation properties
        public virtual ICollection<Solicitud> Solicitudes { get; set; } = new List<Solicitud>();
    }
}
