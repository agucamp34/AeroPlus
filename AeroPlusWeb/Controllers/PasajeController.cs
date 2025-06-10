using Dominio;
using Microsoft.AspNetCore.Mvc;

namespace AeroPlusWeb.Controllers
{
    public class PasajeController : Controller
    {
        private Sistema sistema = Sistema.ObtenerInstancia();
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ConfirmarPasaje(int idVuelo, DateTime fecha, Equipaje tipoEquipaje)
        {
            //arreglar los retornos de estas cosas

            Vuelo vuelo = sistema.ObtenerVueloPorId(idVuelo);
            if (vuelo == null) { return RedirectToAction("ListaVuelos", "Vuelo"); }

            string email = HttpContext.Session.GetString("UsuarioEmail");
            if (string.IsNullOrEmpty(email)) { return RedirectToAction("Login", "Account"); }

            Cliente cliente = sistema.ObtenerPorEmail(email) as Cliente;
            if (cliente == null) { return RedirectToAction("Login", "Account"); }

            Pasaje p = new Pasaje(vuelo, fecha, tipoEquipaje, cliente);

            return View(p);
        }

        [HttpPost]
        public IActionResult ComprarPasaje(int idVuelo, DateTime fecha, Equipaje tipoEquipaje)
        {
            Vuelo vuelo = sistema.ObtenerVueloPorId(idVuelo);
            if (vuelo == null)
            {
                return RedirectToAction("ListaVuelos", "Vuelo");
            }

            string email = HttpContext.Session.GetString("UsuarioEmail");
            if (string.IsNullOrEmpty(email))
            {
                return RedirectToAction("Login", "Account");
            }

            Cliente cliente = sistema.ObtenerPorEmail(email) as Cliente;
            if (cliente == null)
            {
                return RedirectToAction("Login", "Account");
            }

            //Pasaje pasaje = new Pasaje(vuelo, fecha, tipoEquipaje, cliente);

            sistema.ComprarPasaje(vuelo, fecha, tipoEquipaje, cliente);

            return RedirectToAction("PasajesCliente", "Cliente");
        }

        public IActionResult ObtenerPorId(int id)
        {
            try
            {
                Pasaje p = sistema.ObtenerPasajePorId(id);
                return View(p);
            }
            catch (Exception ex)
            {
                return View();
            }
        }
    }
}
