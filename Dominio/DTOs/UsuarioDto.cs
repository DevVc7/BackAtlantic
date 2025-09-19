namespace Biblioteca.Dominio.DTOs
{
    public class UsuarioDto
    {
        public int IdUsuario { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string NombreCompleto { get; set; }
        public int IdRol { get; set; }
        public string NombreRol { get; set; }
        public bool Activo { get; set; }
    }
}
