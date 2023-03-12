using Cheztel.Models;
using Cheztel.Servicios;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using System.Diagnostics.Contracts;

namespace Cheztel.Controllers
{
    public class HotelesController : Controller
    {

        private readonly IConfiguration configuration;
        private readonly IRepositorioHoteles repositorioHoteles;

        public HotelesController(IRepositorioHoteles repositorioHoteles, IConfiguration configuration)
        {
            this.repositorioHoteles = repositorioHoteles;
            this.configuration = configuration;
        }

        public async Task<ActionResult> Index()
        {

            

            var listarHoteles = await repositorioHoteles.Listar();
            

            return View(listarHoteles);
            
        }


        public IActionResult Crear()
        {

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Crear(Hotel hotel)
        {


            if (!ModelState.IsValid)
            {
                return View(hotel);
            }

            await repositorioHoteles.CrearHotel(hotel);

            return RedirectToAction("Index");

        }



        public async Task<IActionResult> Eliminar(int Id)
        {

            await repositorioHoteles.Eliminar(Id);

            return RedirectToAction("Index");
        }

    }  
}
