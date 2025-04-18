using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Sistema
    {
        public List<Usuario> Usuarios { get; set; }
        public List<Avion> Aviones { get; set; }
        public List<Ruta> Rutas { get; set; }
        public List<Vuelo> Vuelos { get; set; }
        public List<Cliente> Clientes { get; set; } // Lista unificada para todos los Clientes.
        public List<Administrador> Administradores{ get; set; }
        public List<Pasaje> Pasajes { get; set; }
        public List<Aeropuerto> Aeropuertos { get; set; }
       
        public Sistema() 
        {
            Usuarios = new List<Usuario>();
            Aviones = new List<Avion>();
            Rutas = new List<Ruta>();
            Vuelos = new List<Vuelo>();
            Clientes = new List<Cliente>(); 
            Administradores = new List<Administrador>();
            Pasajes = new List<Pasaje>();
            Aeropuertos = new List<Aeropuerto>();

            

        }

        private void PrecargarAeropuertos()
        {
            Aeropuertos.Add(new Aeropuerto("MVD", "Montevideo", 200, 50));
            Aeropuertos.Add(new Aeropuerto("EZE", "Buenos Aires", 150, 40));
            Aeropuertos.Add(new Aeropuerto("SFO", "San Francisco", 300, 60));
            Aeropuertos.Add(new Aeropuerto("LAX", "Los Angeles", 250, 70));
        }   

        public void AgregarPasaje(Pasaje pasaje)
        {
            Pasajes.Add(pasaje);
        }   

        public void AgregarCliente(Cliente cliente)
        {
            cliente.ValidarCliente();
            Clientes.Add(cliente);
        }

        private void PrecargarClientes()
        {
            Clientes.Add(new ClientePremium(
                documento: "12345678",
                nombre: "Juan Perez",
                email: "juan.perez@gmail.com",
                contrasena: "1234",
                nacionalidad: "Argentina",
                puntos: 1500
                ));

            Clientes.Add(new ClientePremium(
                documento: "51998917",
                nombre: "Facundo Reynaldo",
                email: "facureynaldo1891@gmail.com",
                contrasena: "facurey1891",
                nacionalidad: "Uruguay",
                puntos: 100000
                ));
            Clientes.Add(new ClienteOcasional(
                documento: "53618884",
                nombre: "Agustin Campos",
                email: "alaguscamp@hotmail.com",
                contrasena: "12314",
                nacionalidad: "Uruguay"
                ));
        }

        private void PrecargarAviones()
        {
            Aviones.Add(new Avion(
                fabricante: "Boeing",
                modelo: "737",
                cantidadAsientos: 180,
                alcance: 5000,
                costoOperacionPorKm: 10.5
            ));

            Aviones.Add(new Avion(
                fabricante: "Airbus",
                modelo: "A320",
                cantidadAsientos: 200,
                alcance: 6000,
                costoOperacionPorKm: 12.0
            ));
        }

       

        private void PrecargarRutas()
        {
            Aeropuerto aeropuertoSalida = new Aeropuerto("MVD", "Montevideo", 200, 50);
            Aeropuerto aeropuertoEntrada = new Aeropuerto("EZE", "Buenos Aires", 150, 40);

            Aeropuertos.Add(aeropuertoSalida);
            Aeropuertos.Add(aeropuertoEntrada);

            Rutas.Add(new Ruta
            {
                AeropuertoSalida = aeropuertoSalida,
                AeropuertoEntrada = aeropuertoEntrada,
                Distancia = 200
            });
        }

        // Método para precargar vuelos
        private void PrecargarVuelos()
        {
            if (Rutas.Count == 0 || Aviones.Count == 0)
            {
                throw new Exception("Debe precargar rutas y aviones antes de precargar vuelos.");
            }

            Vuelos.Add(new Vuelo(
                numeroVuelo: "UY123",
                ruta: Rutas[0],
                avion: Aviones[0],
                frecuencia: new List<DiaSemana> { DiaSemana.Lunes, DiaSemana.Miercoles, DiaSemana.Viernes }
            ));

            Vuelos.Add(new Vuelo(
                numeroVuelo: "UY456",
                ruta: Rutas[0],
                avion: Aviones[1],
                frecuencia: new List<DiaSemana> { DiaSemana.Martes, DiaSemana.Jueves }
            ));
        }

        private void PrecargarAdministradores()
        {
            Administradores.Add(new Administrador(
                apodo: "admin1",
                email: "admin1@example.com",
                contrasena: "securepassword123"
            ));
        }


        // Método central para precargar todos los objetos
        public void PrecargaObjetos()
        {
            PrecargarClientes();
            PrecargarAviones();
            PrecargarRutas();
            PrecargarVuelos();
            PrecargarAdministradores();
        }

        public List<Vuelo> ObtenerVuelosPorAeropuerto(string codigoAeropuerto)
        {
            List<Vuelo> vuelosPorAeropuerto = new List<Vuelo>();

            foreach (var vuelo in Vuelos)
            {
                if (vuelo.Ruta.AeropuertoSalida.CodigoIATA == codigoAeropuerto || vuelo.Ruta.AeropuertoEntrada.CodigoIATA == codigoAeropuerto)
                {
                    vuelosPorAeropuerto.Add(vuelo);
                }
            }
            return vuelosPorAeropuerto;
        }


        public void AgregarCliente(Cliente cliente)
        {

        }
        public List<Pasaje> ObtenerPasajeEntreFechas(DateTime desde, DateTime hasta)
        {
            List<Pasaje> pasajesEntreFechas = new List<Pasaje>();
            foreach (var pasaje in Pasajes)
            {
                if (pasaje.Fecha >= desde && pasaje.Fecha <= hasta)
                {
                    pasajesEntreFechas.Add(pasaje);
                }
            }
            return pasajesEntreFechas;
        }

        public List<Pasaje> ObtenerPasajesPorCliente(List<Pasaje> pasajes, Cliente cliente)
        {
            List<Pasaje> pasajesCliente = new List<Pasaje>();
            foreach (var pasaje in pasajes)
            {
                if (pasaje.Pasajero == cliente)
                {
                    pasajesCliente.Add(pasaje);
                }
            }
            return pasajesCliente;
        }
    }
}
    

