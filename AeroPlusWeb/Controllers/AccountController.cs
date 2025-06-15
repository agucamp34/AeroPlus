using Dominio;
using Microsoft.AspNetCore.Mvc;

namespace AeroPlusWeb.Controllers
{
    public class AccountController : Controller
    {
        private Sistema sistema = Sistema.ObtenerInstancia();

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        public IActionResult Registro()
        {
            return View();
        }

        //[HttpPost]
        //public IActionResult Login(string email, string contrasena)
        //{
        //    try
        //    {
        //        // Validar que los campos no estén vacíos
        //        if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(contrasena))
        //        {
        //            ViewBag.Error = "Debe completar todos los campos.";
        //            return View();
        //        }

        //        // Intentar encontrar el usuario en el sistema
        //        var usuarioValido = sistema.Ingresar(email, contrasena);

        //        if (usuarioValido != null)
        //        {
        //            // Crear cookie para mantener sesión
        //            Response.Cookies.Append("UsuarioEmail", usuarioValido.Email, new CookieOptions { Expires = DateTime.Now.AddHours(8) });

        //            return RedirectToAction("Index", "Home"); // Redirigir si el usuario es válido
        //        }
        //        else
        //        {
        //            ViewBag.Error = "Email o contraseña incorrectos.";
        //            return View();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        ViewBag.Error = $"Ocurrió un error: {ex.Message}";
        //        return View();
        //    }
        //}


        //login con session
        [HttpPost]
        public IActionResult Login(string email, string contrasena)
        {
            //metodo de sistema para encontrar el objeto usuario por parametros
            Usuario user = sistema.Ingresar(email, contrasena);


            if (user != null)
            {
                // Guardar el email en la sesión
                HttpContext.Session.SetString("UsuarioEmail", user.Email);

                return RedirectToAction("Index", "Home");
            }

            ViewBag.Error = "Email o contraseña incorrectos";
            return View();
        }

        //comentario

        [HttpPost]
        public IActionResult Registro(ClienteOcasional? c)
        {
            try
            {
                sistema.AltaClienteOcasional(c);

                //esto no se puede hacer, viewbag con View, rtAction con TempData
                //ViewBag.Alta = "Se registró exitosamente";
                HttpContext.Session.SetString("UsuarioEmail", c.Email);
                HttpContext.Session.SetString("UsuarioRol", c.Rol.ToString());
                return RedirectToAction("ListaVuelos", "Vuelo");
            }
            catch (Exception ex)
            {
                ViewBag.Error = $"Error en el registro: {ex.Message}";
                return View(c); // Si hay error, vuelve a la vista con los datos ingresados
            }
        }

    }
}








