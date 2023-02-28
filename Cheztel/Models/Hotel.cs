using System.ComponentModel.DataAnnotations;

namespace Cheztel.Models
{
    public class Hotel
    {

        [Required]
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Responsable { get; set; }
        public int Calificacion { get; set; }
        public int IdServicio { get; set; }
    }
}
