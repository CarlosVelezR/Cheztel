using Cheztel.Models;
using Cheztel.Servicios;
using Microsoft.AspNetCore.Mvc;

namespace Cheztel.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly IAutenticarUsuarios servicioAutenticar;

        public UsuarioController(IAutenticarUsuarios servicioAutenticar)
        {
            this.servicioAutenticar = servicioAutenticar;
        }

        public IActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult>Iniciar(Usuario usuario)
        {

            var existeUsuario = await servicioAutenticar.Existe(usuario.Nombre, usuario.Password);
            

    
            if (existeUsuario)
            {

                

                return RedirectToAction("Index", "Hoteles");
            }

            else
            {

                ModelState.AddModelError(nameof(usuario.Password), 
                    $"El usuario o contraseña es incorrecta.");

                return View("Index", usuario);
            }

        }


    }
}
