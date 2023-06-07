using Cheztel.Models;
using Cheztel.Servicios;
using Microsoft.AspNetCore.Mvc;

namespace Cheztel.Controllers
{
    public class ReservaController : Controller
    {

        private readonly IRepositorioReservas repositorioReservas;

        public IActionResult Index(Reserva reserva)
        {
            if (!ModelState.IsValid)
            {

                return View(reserva);
            }

            var listarReservas = repositorioReservas.ListarReserva();

            return View();
        }

        public async Task<IActionResult> Crear(Reserva reserva)
        {


            if (!ModelState.IsValid)
            {

                return View(reserva);
            }

            var listarReservas = repositorioReservas.ListarReserva();
                        
            return View();
        }
    }
}
