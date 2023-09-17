using Cheztel.Models;
using Dapper;
using Microsoft.AspNetCore.Identity;
using System.Data.SqlClient;

namespace Cheztel.Servicios
{

    public interface IRepositorioHabitaciones
    {
        Task<IEnumerable<Habitacion>> ActualizarHabitacion(int idHotel, int IdHabitacion);
        Task Crear(Habitacion habitacion);
        Task EditarHabitacion(Habitacion habitacion);
        Task<IEnumerable<Habitacion>> EditarHabPorUsuario(Habitacion habitacion);
        Task<IEnumerable<Acomodacion>> ListarAcomodaciones();
        Task<IEnumerable<Habitacion>> ListarHabitaciones(Habitacion habitacion);
        Task<IEnumerable<Habitacion>> ListarHabPorUsuario(int idHotel);
        Task<Habitacion> ObtenerHabitacionId(int hotel);
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

        public async Task<Habitacion> ObtenerHabitacionId(int hotel)
        {

            using var conn = new SqlConnection(connectionString);


            return await conn.QueryFirstOrDefaultAsync<Habitacion>(@"SELECT Id,Nombre ,Acomodacion,Disponibilidad,Hotel 
                                                       FROM Cheztel.dbo.Habitacion WHERE Hotel = @hotel", new { hotel });

        }


        public async Task EditarHabitacion(Habitacion habitacion)
        {


            using var connection = new SqlConnection(connectionString);

            var editarHabitacion = await connection.QuerySingleOrDefaultAsync<int>("SP_EDITAR_HABITACION_HOTEL", 
                
            new           
            { 

                habitacion.Id,
                habitacion.Nombre,
                habitacion.Acomodacion,
                habitacion.Disponibilidad,               
                habitacion.Hotel
                    
            }, commandType : System.Data.CommandType.StoredProcedure);
            

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

        public async Task<IEnumerable<Habitacion>> EditarHabPorUsuario(Habitacion habitacion)
        {

            using var connection = new SqlConnection(connectionString);

            var consulta = await connection.QueryAsync<Habitacion>(@"SELECT Id,Nombre,Acomodacion,Disponibilidad,FechaCreacion,Hotel 
                                                             FROM Cheztel.dbo.Habitacion where Hotel = @Hotel and Id = @Id",
                                                             new {habitacion.Hotel, habitacion.Id });


            return await connection.QueryAsync<Habitacion>(@"SELECT Id,Nombre,Acomodacion,Disponibilidad,FechaCreacion,Hotel 
                                                             FROM Cheztel.dbo.Habitacion where Hotel = @Hotel and Id = @Id", 
                                                             new { habitacion.Hotel, habitacion.Id });


        }

        public async Task<IEnumerable<Habitacion>> ActualizarHabitacion(int idHotel, int IdHabitacion)
        {

            using var connection = new SqlConnection(connectionString);

            return await connection.QueryAsync<Habitacion>(@"UPDATE Habitacion SET Disponibilidad = '0' 
                                                           WHERE hotel = @IdHotel AND Id = @IdHabitacion", new { idHotel, IdHabitacion });
            
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
