using System.ComponentModel.DataAnnotations;

namespace Cheztel.Models
{
    public class Usuario
    {

        public int Id { get; set; }
        [Required(ErrorMessage = "El nombre de usuario es requerido.")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "La contraseña de usuario es requerida.")]
        public string Password { get; set; }
        public int TipoRol { get; set; }
    }
}
