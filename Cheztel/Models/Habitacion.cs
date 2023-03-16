using System.ComponentModel.DataAnnotations;

namespace Cheztel.Models
{
    public class Habitacion
    {

        public int Id { get; set; }
        [Required(ErrorMessage ="El nombre de la habitacion es requerido.")]
        public string Nombre { get; set; }
        public string Acomodacion { get; set; }
        public bool Disponibilidad { get; set; }
        public DateTime FechaCreacion { get; set; }
        public int Hotel { get; set; }
    }
}
