using Cheztel.Models;
using Cheztel.Servicios;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

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

    }
}
