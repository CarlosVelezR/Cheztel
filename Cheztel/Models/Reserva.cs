using Microsoft.AspNetCore.Authorization;

namespace Cheztel.Models
{
    public class Reserva
    {
        public int Id { get; set; }
        public string UsuarioReserva { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
    }
}
