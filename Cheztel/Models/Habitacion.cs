namespace Cheztel.Models
{
    public class Habitacion
    {

        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Acomodacion { get; set; }
        public string Disponibilidad { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public DateTime FechaCreacion { get; set; }
        public int Hotel { get; set; }
        public int IdReserva { get; set; }
    }
}
