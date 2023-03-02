using System.ComponentModel.DataAnnotations;

namespace Cheztel.Models
{
    public class Roles
    {

        [Required]
        public int Id { get; set; }
        public string Rol { get; set; }
        public int TipoPrivilegio { get; set; }
    }
}
