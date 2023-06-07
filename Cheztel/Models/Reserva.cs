using Microsoft.AspNetCore.Authorization;
using System.ComponentModel.DataAnnotations;

namespace Cheztel.Models
{
    public class Reserva
    {
        public int Id { get; set; }
        public int UsuarioReserva { get; set; }
        [Required(ErrorMessage ="Es necesaria la fecha de reservacion")]
        public DateTime FechaInicio { get; set; }
        [Required(ErrorMessage = "Es necesaria la fecha de reservacion")]
        public DateTime FechaFin { get; set; }
        public string CodigoReserva { get; set; }
    }
}
