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
            var existeUsername = await servicioAutenticar.ExisteUsuario(usuario.Nombre);

    
            if (existeUsuario)
            {


                return RedirectToAction("Index", "Hoteles");
            }

            else
            {

                ModelState.AddModelError(nameof(usuario.Password), 
                    $"El password {usuario.Password} es incorrecto existe");

                return View("Index", usuario);
            }

        }


    }
}
