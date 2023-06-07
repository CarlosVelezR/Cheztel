using Cheztel.Models;
using Cheztel.Servicios;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Runtime.InteropServices;


namespace Cheztel.Controllers
{
    public class HabitacionController : Controller
    {

        private readonly IRepositorioHabitaciones repositorioHabitaciones;
        private readonly IRepositorioHoteles repositorioHoteles;

        public HabitacionController(IRepositorioHabitaciones repositorioHabitaciones, IRepositorioHoteles repositorioHoteles)
        {
            this.repositorioHabitaciones = repositorioHabitaciones;
            this.repositorioHoteles = repositorioHoteles;
        }


        public async Task<IActionResult> Index(int idHotel)
        {

            var obtenerHab = await repositorioHabitaciones.ListarHabPorUsuario(idHotel);
         
            return View(obtenerHab);
        }


        public async Task<IActionResult> Crear()
        {
            
            var modelo = new CrearHabitacionViewModel();
            modelo.Hoteles = await ObtenerHotelesId();
            modelo.Acomodaciones = await ObtenerAcomodacionesId();

            return View(modelo);

        }


        public async Task<IActionResult> ActualizarConsulta(int idHabitacion, int idHotel)
        {

            var actualizarReserva = await repositorioHabitaciones.ActualizarHabitacion(idHotel, idHabitacion);

            return RedirectToAction("Index","Habitacion", new { idHotel = idHotel});
        }


        private async Task<IEnumerable<SelectListItem>> ObtenerHotelesId()
        {
            
            var tipoHoteles = await repositorioHoteles.Listar();
            
            return tipoHoteles.Select(x => new SelectListItem(x.Nombre, x.Id.ToString())); 

        }

        private async Task<IEnumerable<SelectListItem>> ObtenerAcomodacionesId()
        {

            var tipoAcomodacion = await repositorioHabitaciones.ListarAcomodaciones();

            return tipoAcomodacion.Select(x => new SelectListItem(x.Nombre, x.Id.ToString()));
        }


        [HttpPost]
        public async Task<IActionResult> Crear(Habitacion habitacion)

        {

            if (!ModelState.IsValid)
            {
                return View(habitacion);
            }

            await repositorioHabitaciones.Crear(habitacion);



            return RedirectToAction("Index","Hoteles");

        }


    }
}
