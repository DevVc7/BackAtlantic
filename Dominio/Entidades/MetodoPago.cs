using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Biblioteca.Dominio.Entidades
{
    [Table("metodos_pago")]
    public class MetodoPago
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        [Column("nombre")]
        public string Nombre { get; set; } = string.Empty;

        [MaxLength(255)]
        [Column("descripcion")]
        public string? Descripcion { get; set; }

        [Column("activo")]
        public bool Activo { get; set; } = true;

        [Column("requiere_validacion")]
        public bool RequiereValidacion { get; set; } = false;

        // Navigation properties
        public virtual ICollection<Prestamo> Prestamos { get; set; } = new List<Prestamo>();
        public virtual ICollection<Venta> Ventas { get; set; } = new List<Venta>();
    }
}
