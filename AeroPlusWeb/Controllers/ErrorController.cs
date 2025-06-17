using Microsoft.AspNetCore.Mvc;

namespace AeroPlusWeb.Controllers
{
    public class ErrorController : Controller
    {
        public IActionResult NoAutorizado()
        {
            return View();
        }
    }
}
