using Microsoft.AspNetCore.Authorization;

namespace Cheztel.Models
{
    public class Reserva
    {
        public int Id { get; set; }
        public int UsuarioReserva { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public string CodigoReserva { get; set; }
    }
}
