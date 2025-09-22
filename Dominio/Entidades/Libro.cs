using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Biblioteca.Dominio.Entidades
{
    [Table("libros")]
    public class Libro
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [MaxLength(20)]
        [Column("isbn")]
        public string? Isbn { get; set; }

        [Required]
        [MaxLength(255)]
        [Column("titulo")]
        public string Titulo { get; set; } = string.Empty;

        [MaxLength(255)]
        [Column("subtitulo")]
        public string? Subtitulo { get; set; }

        [Column("descripcion")]
        public string? Descripcion { get; set; }

        [Column("categoria_id")]
        public int CategoriaId { get; set; }

        [Column("fecha_publicacion")]
        public DateTime? FechaPublicacion { get; set; }

        [Column("numero_paginas")]
        public int? NumeroPaginas { get; set; }

        [MaxLength(50)]
        [Column("idioma")]
        public string Idioma { get; set; } = "Español";

        [Column("precio_venta", TypeName = "decimal(10,2)")]
        public decimal PrecioVenta { get; set; }

        [Column("precio_alquiler_dia", TypeName = "decimal(10,2)")]
        public decimal PrecioAlquilerDia { get; set; }

        [Column("disponible_venta")]
        public bool DisponibleVenta { get; set; } = true;

        [Column("disponible_alquiler")]
        public bool DisponibleAlquiler { get; set; } = true;

        [MaxLength(255)]
        [Column("imagen_portada")]
        public string? ImagenPortada { get; set; }

        [Column("activo")]
        public bool Activo { get; set; } = true;

        [Column("fecha_creacion")]
        public DateTime FechaCreacion { get; set; } = DateTime.Now;

        // Navigation properties
        [ForeignKey("CategoriaId")]
        public virtual Categoria Categoria { get; set; } = null!;

        public virtual ICollection<CopiaLibro> CopiasLibros { get; set; } = new List<CopiaLibro>();
    }
}
