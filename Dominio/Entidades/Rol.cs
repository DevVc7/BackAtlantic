using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Biblioteca.Dominio.Entidades
{
    [Table("roles")]
    public class Rol
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

        [Column("fecha_creacion")]
        public DateTime FechaCreacion { get; set; } = DateTime.Now;

        // Navigation properties
        public virtual ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
    }
}
