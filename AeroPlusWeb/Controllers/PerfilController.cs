using Dominio;
using Microsoft.AspNetCore.Mvc;

namespace AeroPlusWeb.Controllers
{
    public class PerfilController : Controller
    {
        private Sistema sistema = Sistema.ObtenerInstancia();
        public IActionResult Index()
        {
            return View();
        }
        

    }
}
