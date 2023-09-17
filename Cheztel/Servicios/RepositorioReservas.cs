using Cheztel.Models;
using Dapper;
using Microsoft.AspNetCore.Identity;
using System.Collections;
using System.Data.SqlClient;

namespace Cheztel.Servicios
{

    public interface IRepositorioReservas
    {
        Task<IEnumerable<Reserva>> ListarReserva();
    }


    public class RepositorioReservas : IRepositorioReservas
    {


        private readonly string connectionString;


        public RepositorioReservas(IConfiguration configuration)

        {

            connectionString = configuration.GetConnectionString("DefaultConnection");

        }


        public async Task<IEnumerable<Reserva>> ListarReserva()

        {

            var connection = new SqlConnection(connectionString);


            return await connection.QueryAsync<Reserva>(@"SELECT ID, USUARIORESERVA, FECHAINICIO, FECHAFIN, CODIGORESERVA FROM RESERVAS");

        }

            
    }




}

