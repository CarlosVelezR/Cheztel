using Cheztel.Models;
using Dapper;
using System.Data.SqlClient;

namespace Cheztel.Servicios
{
    public interface IAutenticarUsuarios
    {
        Task<bool> Existe(string nombre, string password);
        Task<bool> ExisteUsuario(string nombre);
    }

    public class AutenticarUsuarios : IAutenticarUsuarios
    {



        private readonly string connectionString;

        public AutenticarUsuarios(IConfiguration configuration)
        {

            connectionString = configuration.GetConnectionString("DefaultConnection");
            
        }


        /*Validar si existe el usuario*/
        public async Task<bool> ExisteUsuario(string nombre)
        {

            using var connection = new SqlConnection(connectionString);

            var obtenerUsuario = await connection.QueryFirstOrDefaultAsync<int>(@"SELECT 1 
                                                                                FROM Usuarios WHERE NOMBRE = @nombre", new { nombre });

            return obtenerUsuario == 1;
        }


        public async Task<bool>Existe(string nombre, string password)
        {

            using var connection = new SqlConnection(connectionString);

            var obtener = await connection.QueryFirstOrDefaultAsync<int>(@"SELECT 1 FROM Usuarios 
                                                             WHERE nombre = @nombre and password = @password", new {nombre, password});

            return obtener == 1;
        }


        public async Task<IEnumerable<Usuario>> Autenticar(string nombre, string password)
        {

            using var connection = new SqlConnection(connectionString);

            return await connection.QueryAsync<Usuario>(@" SELECT nombre, Password FROM usuarios", new {nombre, password});


        }

    }
}
