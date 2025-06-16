using Dominio;
using Microsoft.AspNetCore.Mvc;

namespace AeroPlusWeb.Controllers
{
    public class PerfilController : Controller
    {
        private Sistema sistema = Sistema.ObtenerInstancia();
       

        public IActionResult Perfil()
        {
             string email= HttpContext.Session.GetString("UsuarioEmail");

            Usuario u = sistema.ObtenerPorEmail(email);
            if (u is Cliente cliente)
            {
                return View(cliente);
            }

            // En caso de que sea admin o un tipo no esperado, lo mandás al inicio o a un error
            return RedirectToAction("Index", "Home");
        }



    }
}
