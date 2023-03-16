using Cheztel.Models;
using Dapper;
using System.Data.SqlClient;

namespace Cheztel.Servicios
{

    public interface IRepositorioHabitaciones
    {
        Task Crear(Habitacion habitacion);
        Task<IEnumerable<Acomodacion>> ListarAcomodaciones();
        Task<IEnumerable<Habitacion>> ListarHabitaciones(Habitacion habitacion);
        Task<IEnumerable<Habitacion>> ListarHabPorUsuario(int idHotel);
    }


    public class RepositorioHabitaciones : IRepositorioHabitaciones
    {

        private readonly string connectionString;


        public RepositorioHabitaciones(IConfiguration configuration)
        {

            connectionString = configuration.GetConnectionString("DefaultConnection");

        }



        public async Task <IEnumerable<Habitacion>> ListarHabitaciones(Habitacion habitacion)
        {


            using var connection = new SqlConnection(connectionString);

            return await connection.QueryAsync<Habitacion>(@"SELECT Id,Nombre,Acomodacion,Disponibilidad,FechaInicio,FechaFin,Hotel,IdReserva 
                                                             FROM Cheztel.dbo.Habitacion");

        }

        public async Task <IEnumerable<Hotel>> HotelesHab(int id, string nombre)
        {

            using var connection = new SqlConnection(connectionString);

            return await connection.QueryAsync<Hotel>("SELECT ID, NOMBRE FROM HOTELES", new {id, nombre});

        }

        public async Task<IEnumerable<Habitacion>> ListarHabPorUsuario(int idHotel)
        {

            using var connection = new SqlConnection(connectionString);
            return await connection.QueryAsync<Habitacion>(@"SELECT Id,Nombre,Acomodacion,Disponibilidad,FechaCreacion,Hotel 
                                                             FROM Cheztel.dbo.Habitacion where Hotel = @IdHotel", new { idHotel});


        }

        public async Task<IEnumerable<Acomodacion>> ListarAcomodaciones()
        {


            using var connection = new SqlConnection(connectionString);

            return await connection.QueryAsync<Acomodacion>("SELECT ID, Nombre, Descripcion FROM ACOMODACIONES");

        }
      


        public async Task Crear(Habitacion habitacion)
        {
            using var connection = new SqlConnection(connectionString);
            var crearHab = await connection.QuerySingleOrDefaultAsync<int>("SP_CREAR_HABITACION", new
            {
                
                habitacion.Nombre,
                habitacion.Acomodacion,
                habitacion.Disponibilidad,
                habitacion.Hotel

            }, commandType: System.Data.CommandType.StoredProcedure);

            habitacion.Id = crearHab;

            
        }

    } 





}
