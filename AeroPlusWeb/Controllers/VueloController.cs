using Dominio;
using Microsoft.AspNetCore.Mvc;

namespace AeroPlusWeb.Controllers
{
    public class VueloController : Controller
    {
        public Sistema sistema = Sistema.ObtenerInstancia();
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ListaVuelos(string? codigoVuelo)

        {
            List<Vuelo> vuelos = sistema.ObtenerVuelos(codigoVuelo);

            return View(vuelos);
        }

        public IActionResult DetalleVuelo(int id)
        {
            try
            {
                Vuelo v = sistema.ObtenerVueloPorId(id);
                return View(v);
            }
            catch (Exception ex)
            {
                return View();
            }
        }
    }

    
}
