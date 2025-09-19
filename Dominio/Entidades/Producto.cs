using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Biblioteca.Dominio.Entidades
{
    [Table("productos")]
    public class Producto
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        [Column("codigo")]
        public string Codigo { get; set; } = string.Empty;

        [Required]
        [MaxLength(255)]
        [Column("nombre")]
        public string Nombre { get; set; } = string.Empty;

        [Column("descripcion")]
        public string? Descripcion { get; set; }

        [MaxLength(100)]
        [Column("categoria")]
        public string? Categoria { get; set; }

        [Column("precio_venta", TypeName = "decimal(10,2)")]
        public decimal PrecioVenta { get; set; }

        [Column("stock_actual")]
        public int StockActual { get; set; } = 0;

        [Column("stock_minimo")]
        public int StockMinimo { get; set; } = 1;

        [Column("activo")]
        public bool Activo { get; set; } = true;

        [Column("fecha_creacion")]
        public DateTime FechaCreacion { get; set; } = DateTime.Now;
    }
}
