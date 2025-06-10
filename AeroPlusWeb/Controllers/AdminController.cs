using Dominio;
using Microsoft.AspNetCore.Mvc;

namespace AeroPlusWeb.Controllers
{
    public class AdminController : Controller
    {
        private Sistema sistema = Sistema.ObtenerInstancia();
        public IActionResult ListaClientes()
        {
            List<Cliente> clientes = sistema.Clientes;
            return View(clientes);
        }
    }
}
