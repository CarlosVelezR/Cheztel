using Cheztel.Models;
using Dapper;
using System.Data.SqlClient;

namespace Cheztel.Servicios
{
    public interface IRepositorioHoteles
    {

        Task CrearHotel(Hotel hotel);
        Task<IEnumerable<Hotel>> Listar();
    }

    public class RepositorioHoteles : IRepositorioHoteles 
    {

        private readonly string connectionString;

        public RepositorioHoteles(IConfiguration configuration)
        {

            connectionString = configuration.GetConnectionString("DefaultConnection");

        }
        

        public async Task<IEnumerable<Hotel>>Listar()
        {

            using var connection = new SqlConnection(connectionString);


            return await connection.QueryAsync<Hotel>(@"SELECT Id,Nombre ,Direccion,Telefono,Responsable,Calificacion,IdServicio 
                                                       FROM Cheztel.dbo.Hoteles");
        }



        public async Task CrearHotel (Hotel hotel)

        {

            using var conn = new SqlConnection(connectionString);

            var crearHotel = await conn.QuerySingleOrDefaultAsync<int>("SP_CREAR_HOTEL", 
                
                new
                {

                    hotel.Nombre,
                    hotel.Direccion,
                    hotel.Telefono,
                    hotel.Responsable,
                    hotel.Calificacion
                }, commandType: System.Data.CommandType.StoredProcedure);

            hotel.Id = crearHotel;
        }

        
    
    }
}
