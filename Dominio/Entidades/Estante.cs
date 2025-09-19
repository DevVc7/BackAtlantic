using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Biblioteca.Dominio.Entidades
{
    [Table("estantes")]
    public class Estante
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Required]
        [MaxLength(20)]
        [Column("codigo")]
        public string Codigo { get; set; } = string.Empty;

        [MaxLength(255)]
        [Column("descripcion")]
        public string? Descripcion { get; set; }

        [MaxLength(100)]
        [Column("ubicacion")]
        public string? Ubicacion { get; set; }

        [Column("capacidad_maxima")]
        public int CapacidadMaxima { get; set; } = 100;

        [Column("activo")]
        public bool Activo { get; set; } = true;

        // Navigation properties
        public virtual ICollection<CopiaLibro> CopiasLibros { get; set; } = new List<CopiaLibro>();
    }
}
