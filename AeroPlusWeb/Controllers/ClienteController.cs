using Dominio;
using Microsoft.AspNetCore.Mvc;

namespace AeroPlusWeb.Controllers
{
    public class ClienteController : Controller
    {
        private Sistema sistema = Sistema.ObtenerInstancia();

        [HttpPost]
        public IActionResult SeleccionarPasaje(int idVuelo, DateTime fecha, Equipaje tipoEquipaje)
        {
            // aca habria que hacer un try and cath con estas 3 infos adentro pero me da error en el constructor
            // si lo implemento, revisar despues (no estabas metiendo todo lo importante en el try payaso jajaja)

                Vuelo vuelo = sistema.ObtenerVueloPorId(idVuelo);

                // Obtener el email del usuario logueado desde la sesión
                string email = HttpContext.Session.GetString("UsuarioEmail");
                if (string.IsNullOrEmpty(email))
                {
                    return RedirectToAction("Login", "Account");
                }

                // Obtener el cliente por su email
                Cliente cliente = (Cliente)sistema.ObtenerPorEmail(email);


            // Crear el pasaje correctamente con precio y pasajero
            Pasaje pasaje = new Pasaje(vuelo, fecha, tipoEquipaje, cliente);

            //return View("ConfirmarPasaje", pasaje); // Vista de confirmación
            return RedirectToAction("ConfirmarPasaje", "Pasaje", new {pasaje});

        }

        public IActionResult PasajesCliente() 
        {
            string email = HttpContext.Session.GetString("UsuarioEmail");

            if (string.IsNullOrEmpty(email))
            {
                return RedirectToAction("Login", "Account");
            }

            // Obtener el cliente por su email
            Cliente cliente = (Cliente)sistema.ObtenerPorEmail(email);

            if (cliente == null)
            {
                return RedirectToAction("Login", "Account");
            }

            // Obtener la lista de pasajes
            List<Pasaje> pasajes = cliente.PasajesComprados;

            return View(pasajes);
        }



        //[httppost]
        //public iactionresult comprarpasaje(pasaje p)
        //{
        //    try
        //    {
        //        //sistema.obtenerclienteporid(); //usamos el id de la sesion iniciada
        //        sistema.comprarpasaje(p);
        //        return redirecttoaction("pasajescliente", "cliente");
        //    }
        //    catch (exception)
        //    {
        //        return view();
        //    }
        //}
    }
}
