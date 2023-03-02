using Cheztel.Models;
using Dapper;
using System.Data.SqlClient;

namespace Cheztel.Servicios
{
    public interface IRepositorioHoteles
    {
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
    
    }
}
