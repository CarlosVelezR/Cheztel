using Cheztel.Models;
using Dapper;
using System.Data.SqlClient;

namespace Cheztel.Servicios
{
    public interface IRepositorioHoteles
    {

        Task CrearHotel(Hotel hotel);
        Task EditarHodel(Hotel hotel);
        Task<IEnumerable<Hotel>> Eliminar(int id);
        Task<IEnumerable<Hotel>> Listar();
        Task<Hotel> ObtenerHotelId(int id);
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

        public async Task <Hotel> ObtenerHotelId(int id)
        {

            using var conn = new SqlConnection(connectionString);


            return await conn.QueryFirstOrDefaultAsync<Hotel>(@"SELECT Id,Nombre ,Direccion,Telefono,Responsable,Calificacion 
                                                       FROM Cheztel.dbo.Hoteles WHERE Id = @id", new { id });

        }
      

        public async Task EditarHodel(Hotel hotel)
        {

            using var conn = new SqlConnection(connectionString);

            var ActualizarHotel = await conn.QuerySingleOrDefaultAsync<int>("SP_EDITAR_HOTEL",

            new

            {
                hotel.Id,
                hotel.Nombre,
                hotel.Direccion,
                hotel.Telefono,
                hotel.Responsable,
                hotel.Calificacion

            }, commandType: System.Data.CommandType.StoredProcedure);                
                
               
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


        public async Task <IEnumerable<Hotel>> Eliminar (int id)
        {

            var conn = new SqlConnection(connectionString);

            return await conn.QueryAsync<Hotel>(@"DELETE Hoteles WHERE ID = @id ", new {id} );
        }

        
    
    }
}
