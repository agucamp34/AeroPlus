using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Sistema
    {

        //Sigleton

        private static Sistema instancia;

        public static Sistema ObtenerInstancia()
        {
            if (instancia == null)
            {
                instancia = new Sistema();
            }
            return instancia;
        }


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


            PrecargaObjetos();
        }



        public void AgregarPasaje(Pasaje pasaje)
        {
            try {
                    pasaje.Validar();
                    Pasajes.Add(pasaje);
            }
            catch (Exception ex) {
                Console.WriteLine($"Error al agregar pasaje: {ex.Message}");
            }

        }   

        public void AgregarCliente(Cliente cliente)
        {
            try {
            cliente.Validar();
            Clientes.Add(cliente);
            }
            catch (Exception ex) {
                Console.WriteLine($"Error al agregar cliente: {ex.Message}");
            }
        }

        private void PrecargarClientes()
        {
            // Precarga de 5 Clientes Premium
            Clientes.Add(new ClientePremium(
                documento: "12345678",
                nombre: "Juan Perez",
                email: "juan.perez@gmail.com",
                contrasena: "1234",
                nacionalidad: "Argentina",
                puntos: 1500
            ));
            Clientes.Add(new ClientePremium(
                documento: "87654321",
                nombre: "Maria Lopez",
                email: "maria.lopez@gmail.com",
                contrasena: "abcd",
                nacionalidad: "Uruguay",
                puntos: 2000
            ));
            Clientes.Add(new ClientePremium(
                documento: "11223344",
                nombre: "Carlos Gomez",
                email: "carlos.gomez@gmail.com",
                contrasena: "pass123",
                nacionalidad: "Chile",
                puntos: 3000
            ));
            Clientes.Add(new ClientePremium(
                documento: "44332211",
                nombre: "Ana Torres",
                email: "ana.torres@gmail.com",
                contrasena: "torres123",
                nacionalidad: "Peru",
                puntos: 2500
            ));
            Clientes.Add(new ClientePremium(
                documento: "55667788",
                nombre: "Luis Martinez",
                email: "luis.martinez@gmail.com",
                contrasena: "martinez456",
                nacionalidad: "Brasil",
                puntos: 1800
            ));

            // Precarga de 5 Clientes Ocasionales
            Clientes.Add(new ClienteOcasional(
                documento: "99887766",
                nombre: "Sofia Diaz",
                email: "sofia.diaz@gmail.com",
                contrasena: "sofia123",
                nacionalidad: "Argentina"
            ));
            Clientes.Add(new ClienteOcasional(
                documento: "66778899",
                nombre: "Pedro Alvarez",
                email: "pedro.alvarez@gmail.com",
                contrasena: "pedro456",
                nacionalidad: "Uruguay"
            ));
            Clientes.Add(new ClienteOcasional(
                documento: "33445566",
                nombre: "Lucia Fernandez",
                email: "lucia.fernandez@gmail.com",
                contrasena: "lucia789",
                nacionalidad: "Chile"
            ));
            Clientes.Add(new ClienteOcasional(
                documento: "22334455",
                nombre: "Jorge Ramirez",
                email: "jorge.ramirez@gmail.com",
                contrasena: "jorge321",
                nacionalidad: "Peru"
            ));
            Clientes.Add(new ClienteOcasional(
                documento: "77889900",
                nombre: "Camila Suarez",
                email: "camila.suarez@gmail.com",
                contrasena: "camila654",
                nacionalidad: "Brasil"
            ));
        }

        private void PrecargarAeropuertos()
        {
            // Precarga de aeropuertos con códigos IATA válidos
            Aeropuertos.Add(new Aeropuerto("MVD", "Montevideo", 200, 50));
            Aeropuertos.Add(new Aeropuerto("EZE", "Buenos Aires", 150, 40));
            Aeropuertos.Add(new Aeropuerto("SFO", "San Francisco", 300, 60));
            Aeropuertos.Add(new Aeropuerto("LAX", "Los Angeles", 250, 70));
            Aeropuertos.Add(new Aeropuerto("JFK", "New York", 400, 80));
            Aeropuertos.Add(new Aeropuerto("CDG", "Paris", 350, 75));
            Aeropuertos.Add(new Aeropuerto("LHR", "London", 300, 70));
            Aeropuertos.Add(new Aeropuerto("GRU", "Sao Paulo", 200, 60));
            Aeropuertos.Add(new Aeropuerto("SYD", "Sydney", 500, 90));
            Aeropuertos.Add(new Aeropuerto("NRT", "Tokyo", 450, 85));
            Aeropuertos.Add(new Aeropuerto("FRA", "Frankfurt", 320, 65));
            Aeropuertos.Add(new Aeropuerto("AMS", "Amsterdam", 310, 60));
            Aeropuertos.Add(new Aeropuerto("DXB", "Dubai", 400, 80));
            Aeropuertos.Add(new Aeropuerto("HND", "Tokyo Haneda", 420, 85));
            Aeropuertos.Add(new Aeropuerto("PEK", "Beijing", 430, 88));
            Aeropuertos.Add(new Aeropuerto("MIA", "Miami", 280, 55));
            Aeropuertos.Add(new Aeropuerto("ORD", "Chicago", 290, 58));
            Aeropuertos.Add(new Aeropuerto("ATL", "Atlanta", 300, 60));
            Aeropuertos.Add(new Aeropuerto("BCN", "Barcelona", 310, 62));
            Aeropuertos.Add(new Aeropuerto("MAD", "Madrid", 320, 65));
        }



        private void PrecargarRutas()
        {
            if (Aeropuertos.Count < 10)
            {
                throw new Exception("Debe precargar al menos 10 aeropuertos antes de precargar rutas.");
            }

            // Crear rutas manualmente
            Rutas.Add(new Ruta(1, Aeropuertos[0], Aeropuertos[1], 200)); // MVD -> EZE
            Rutas.Add(new Ruta(2, Aeropuertos[1], Aeropuertos[2], 300)); // EZE -> SFO
            Rutas.Add(new Ruta(3, Aeropuertos[2], Aeropuertos[3], 400)); // SFO -> LAX
            Rutas.Add(new Ruta(4, Aeropuertos[3], Aeropuertos[4], 500)); // LAX -> JFK
            Rutas.Add(new Ruta(5, Aeropuertos[4], Aeropuertos[5], 600)); // JFK -> CDG

            Rutas.Add(new Ruta(6, Aeropuertos[5], Aeropuertos[6], 700)); // CDG -> LHR
            Rutas.Add(new Ruta(7, Aeropuertos[6], Aeropuertos[7], 800)); // LHR -> GRU
            Rutas.Add(new Ruta(8, Aeropuertos[7], Aeropuertos[8], 900)); // GRU -> SYD
            Rutas.Add(new Ruta(9, Aeropuertos[8], Aeropuertos[9], 1000)); // SYD -> NRT
            Rutas.Add(new Ruta(10, Aeropuertos[9], Aeropuertos[10], 1100)); // NRT -> FRA

            Rutas.Add(new Ruta(11, Aeropuertos[10], Aeropuertos[11], 1200)); // FRA -> AMS
            Rutas.Add(new Ruta(12, Aeropuertos[11], Aeropuertos[12], 1300)); // AMS -> DXB
            Rutas.Add(new Ruta(13, Aeropuertos[12], Aeropuertos[13], 1400)); // DXB -> HND
            Rutas.Add(new Ruta(14, Aeropuertos[13], Aeropuertos[14], 1500)); // HND -> PEK
            Rutas.Add(new Ruta(15, Aeropuertos[14], Aeropuertos[15], 1600)); // PEK -> MIA

            Rutas.Add(new Ruta(16, Aeropuertos[15], Aeropuertos[16], 1700)); // MIA -> ORD
            Rutas.Add(new Ruta(17, Aeropuertos[16], Aeropuertos[17], 1800)); // ORD -> ATL
            Rutas.Add(new Ruta(18, Aeropuertos[17], Aeropuertos[18], 1900)); // ATL -> BCN
            Rutas.Add(new Ruta(19, Aeropuertos[18], Aeropuertos[19], 2000)); // BCN -> MAD
            Rutas.Add(new Ruta(20, Aeropuertos[19], Aeropuertos[0], 2100)); // MAD -> MVD

            Rutas.Add(new Ruta(21, Aeropuertos[0], Aeropuertos[2], 2200)); // MVD -> SFO
            Rutas.Add(new Ruta(22, Aeropuertos[1], Aeropuertos[3], 2300)); // EZE -> LAX
            Rutas.Add(new Ruta(23, Aeropuertos[2], Aeropuertos[4], 2400)); // SFO -> JFK
            Rutas.Add(new Ruta(24, Aeropuertos[3], Aeropuertos[5], 2500)); // LAX -> CDG
            Rutas.Add(new Ruta(25, Aeropuertos[4], Aeropuertos[6], 2600)); // JFK -> LHR

            Rutas.Add(new Ruta(26, Aeropuertos[5], Aeropuertos[7], 2700)); // CDG -> GRU
            Rutas.Add(new Ruta(27, Aeropuertos[6], Aeropuertos[8], 2800)); // LHR -> SYD
            Rutas.Add(new Ruta(28, Aeropuertos[7], Aeropuertos[9], 2900)); // GRU -> NRT
            Rutas.Add(new Ruta(29, Aeropuertos[8], Aeropuertos[10], 3000)); // SYD -> FRA
            Rutas.Add(new Ruta(30, Aeropuertos[9], Aeropuertos[11], 3100)); // NRT -> AMS
        }

        // Método para precargar vuelos
        private void PrecargarVuelos()
        {
            if (Rutas.Count < 5 || Aviones.Count < 3)
            {
                throw new Exception("Debe precargar al menos 5 rutas y 3 aviones antes de precargar vuelos.");
            }

            Vuelos.Add(new Vuelo(1, "UY001", Rutas[0], Aviones[0], new List<DayOfWeek> { DayOfWeek.Monday, DayOfWeek.Wednesday }));
            Vuelos.Add(new Vuelo(2, "UY002", Rutas[1], Aviones[1], new List<DayOfWeek> { DayOfWeek.Tuesday, DayOfWeek.Thursday }));
            Vuelos.Add(new Vuelo(3, "UY003", Rutas[2], Aviones[2], new List<DayOfWeek> { DayOfWeek.Friday, DayOfWeek.Saturday }));
            Vuelos.Add(new Vuelo(4, "UY004", Rutas[3], Aviones[0], new List<DayOfWeek> { DayOfWeek.Sunday }));
            Vuelos.Add(new Vuelo(5, "UY005", Rutas[4], Aviones[1], new List<DayOfWeek> { DayOfWeek.Monday, DayOfWeek.Friday }));

            Vuelos.Add(new Vuelo(6, "UY006", Rutas[0], Aviones[2], new List<DayOfWeek> { DayOfWeek.Tuesday, DayOfWeek.Thursday }));
            Vuelos.Add(new Vuelo(7, "UY007", Rutas[1], Aviones[0], new List<DayOfWeek> { DayOfWeek.Wednesday, DayOfWeek.Saturday }));
            Vuelos.Add(new Vuelo(8, "UY008", Rutas[2], Aviones[1], new List<DayOfWeek> { DayOfWeek.Sunday }));
            Vuelos.Add(new Vuelo(9, "UY009", Rutas[3], Aviones[2], new List<DayOfWeek> { DayOfWeek.Monday, DayOfWeek.Wednesday }));
            Vuelos.Add(new Vuelo(10, "UY010", Rutas[4], Aviones[0], new List<DayOfWeek> { DayOfWeek.Friday }));

            Vuelos.Add(new Vuelo(11, "UY011", Rutas[0], Aviones[1], new List<DayOfWeek> { DayOfWeek.Tuesday, DayOfWeek.Thursday }));
            Vuelos.Add(new Vuelo(12, "UY012", Rutas[1], Aviones[2], new List<DayOfWeek> { DayOfWeek.Saturday }));
            Vuelos.Add(new Vuelo(13, "UY013", Rutas[2], Aviones[0], new List<DayOfWeek> { DayOfWeek.Sunday }));
            Vuelos.Add(new Vuelo(14, "UY014", Rutas[3], Aviones[1], new List<DayOfWeek> { DayOfWeek.Monday, DayOfWeek.Friday }));
            Vuelos.Add(new Vuelo(15, "UY015", Rutas[4], Aviones[2], new List<DayOfWeek> { DayOfWeek.Wednesday }));

            Vuelos.Add(new Vuelo(16, "UY016", Rutas[0], Aviones[0], new List<DayOfWeek> { DayOfWeek.Tuesday, DayOfWeek.Thursday }));
            Vuelos.Add(new Vuelo(17, "UY017", Rutas[1], Aviones[1], new List<DayOfWeek> { DayOfWeek.Friday, DayOfWeek.Saturday }));
            Vuelos.Add(new Vuelo(18, "UY018", Rutas[2], Aviones[2], new List<DayOfWeek> { DayOfWeek.Sunday }));
            Vuelos.Add(new Vuelo(19, "UY019", Rutas[3], Aviones[0], new List<DayOfWeek> { DayOfWeek.Monday, DayOfWeek.Wednesday }));
            Vuelos.Add(new Vuelo(20, "UY020", Rutas[4], Aviones[1], new List<DayOfWeek> { DayOfWeek.Friday }));

            Vuelos.Add(new Vuelo(21, "UY021", Rutas[0], Aviones[2], new List<DayOfWeek> { DayOfWeek.Tuesday, DayOfWeek.Thursday }));
            Vuelos.Add(new Vuelo(22, "UY022", Rutas[1], Aviones[0], new List<DayOfWeek> { DayOfWeek.Saturday }));
            Vuelos.Add(new Vuelo(23, "UY023", Rutas[2], Aviones[1], new List<DayOfWeek> { DayOfWeek.Sunday }));
            Vuelos.Add(new Vuelo(24, "UY024", Rutas[3], Aviones[2], new List<DayOfWeek> { DayOfWeek.Monday, DayOfWeek.Friday }));
            Vuelos.Add(new Vuelo(25, "UY025", Rutas[4], Aviones[0], new List<DayOfWeek> { DayOfWeek.Wednesday }));

            Vuelos.Add(new Vuelo(26, "UY026", Rutas[0], Aviones[1], new List<DayOfWeek> { DayOfWeek.Tuesday, DayOfWeek.Thursday }));
            Vuelos.Add(new Vuelo(27, "UY027", Rutas[1], Aviones[2], new List<DayOfWeek> { DayOfWeek.Friday, DayOfWeek.Saturday }));
            Vuelos.Add(new Vuelo(28, "UY028", Rutas[2], Aviones[0], new List<DayOfWeek> { DayOfWeek.Sunday }));
            Vuelos.Add(new Vuelo(29, "UY029", Rutas[3], Aviones[1], new List<DayOfWeek> { DayOfWeek.Monday, DayOfWeek.Wednesday }));
            Vuelos.Add(new Vuelo(30, "UY030", Rutas[4], Aviones[2], new List<DayOfWeek> { DayOfWeek.Friday }));

        }



        private void PrecargarPasajes()
        {
            if (Vuelos.Count < 2 || Clientes.Count < 5)
            {
                throw new Exception("Debe precargar al menos 2 vuelos y 5 clientes antes de precargar pasajes.");
            }

            // Crear pasajes manualmente con fechas explícitas
            Pasajes.Add(new Pasaje(Vuelos[0], new DateTime(2025, 5, 10), Equipaje.CABINA, Clientes[0]));
            Pasajes.Add(new Pasaje(Vuelos[0], new DateTime(2025, 5, 11), Equipaje.BODEGA, Clientes[1]));
            Pasajes.Add(new Pasaje(Vuelos[0], new DateTime(2025, 5, 12), Equipaje.LIGHT, Clientes[2]));
            Pasajes.Add(new Pasaje(Vuelos[1], new DateTime(2025, 5, 13), Equipaje.CABINA, Clientes[3]));
            Pasajes.Add(new Pasaje(Vuelos[1], new DateTime(2025, 5, 14), Equipaje.BODEGA, Clientes[4]));
            Pasajes.Add(new Pasaje(Vuelos[0], new DateTime(2025, 5, 15), Equipaje.LIGHT, Clientes[0]));
            Pasajes.Add(new Pasaje(Vuelos[1], new DateTime(2025, 5, 16), Equipaje.CABINA, Clientes[1]));
            Pasajes.Add(new Pasaje(Vuelos[0], new DateTime(2025, 5, 17), Equipaje.BODEGA, Clientes[2]));
            Pasajes.Add(new Pasaje(Vuelos[1], new DateTime(2025, 5, 18), Equipaje.LIGHT, Clientes[3]));
            Pasajes.Add(new Pasaje(Vuelos[0], new DateTime(2025, 5, 19), Equipaje.CABINA, Clientes[4]));
            Pasajes.Add(new Pasaje(Vuelos[1], new DateTime(2025, 5, 20), Equipaje.BODEGA, Clientes[0]));
            Pasajes.Add(new Pasaje(Vuelos[0], new DateTime(2025, 5, 21), Equipaje.LIGHT, Clientes[1]));
            Pasajes.Add(new Pasaje(Vuelos[1], new DateTime(2025, 5, 22), Equipaje.CABINA, Clientes[2]));
            Pasajes.Add(new Pasaje(Vuelos[0], new DateTime(2025, 5, 23), Equipaje.BODEGA, Clientes[3]));
            Pasajes.Add(new Pasaje(Vuelos[1], new DateTime(2025, 5, 24), Equipaje.LIGHT, Clientes[4]));
            Pasajes.Add(new Pasaje(Vuelos[0], new DateTime(2025, 5, 25), Equipaje.CABINA, Clientes[0]));
            Pasajes.Add(new Pasaje(Vuelos[1], new DateTime(2025, 5, 26), Equipaje.BODEGA, Clientes[1]));
            Pasajes.Add(new Pasaje(Vuelos[0], new DateTime(2025, 5, 27), Equipaje.LIGHT, Clientes[2]));
            Pasajes.Add(new Pasaje(Vuelos[1], new DateTime(2025, 5, 28), Equipaje.CABINA, Clientes[3]));
            Pasajes.Add(new Pasaje(Vuelos[0], new DateTime(2025, 5, 29), Equipaje.BODEGA, Clientes[4]));
            Pasajes.Add(new Pasaje(Vuelos[1], new DateTime(2025, 5, 30), Equipaje.LIGHT, Clientes[0]));
            Pasajes.Add(new Pasaje(Vuelos[0], new DateTime(2025, 5, 31), Equipaje.CABINA, Clientes[1]));
            Pasajes.Add(new Pasaje(Vuelos[1], new DateTime(2025, 6, 1), Equipaje.BODEGA, Clientes[2]));
            Pasajes.Add(new Pasaje(Vuelos[0], new DateTime(2025, 6, 2), Equipaje.LIGHT, Clientes[3]));
            Pasajes.Add(new Pasaje(Vuelos[1], new DateTime(2025, 6, 3), Equipaje.CABINA, Clientes[4]));
        }
        private void PrecargarUsuarios()
        {
            foreach (var c in Clientes)
            {
                Usuarios.Add(c); // Upcasting implícito a Usuario
            }

            foreach (var a in Administradores)
            {
                Usuarios.Add(a);
            }

        }

        private void PrecargarAviones()
        {
            Aviones.Add(new Avion("Boeing", "737", 180, 5000, 10.5));
            Aviones.Add(new Avion("Airbus", "A320", 200, 6000, 12.0));
            Aviones.Add(new Avion("Boeing", "747", 400, 13000, 25.0));
            Aviones.Add(new Avion("Airbus", "A380", 800, 15000, 30.0));
            Aviones.Add(new Avion("Embraer", "E190", 100, 4000, 8.0));
            Aviones.Add(new Avion("Bombardier", "CRJ900", 90, 3500, 7.5));
            Aviones.Add(new Avion("Boeing", "767", 250, 11000, 20.0));
            Aviones.Add(new Avion("Airbus", "A350", 300, 14000, 22.0));
            Aviones.Add(new Avion("Boeing", "787", 330, 12000, 21.0));
            Aviones.Add(new Avion("Cessna", "Citation X", 12, 6000, 5.0));
        }

        private void PrecargarAdministradores()
        {
            Administradores.Add(new Administrador(
                apodo: "admin1",
                email: "admin1@example.com",
                contrasena: "securepassword123"
            ));

            Administradores.Add(new Administrador(
                apodo: "admin2",
                email: "admin2@example.com",
                contrasena: "securepassword321"
                ));
        }


        // Método central para precargar todos los objetos
        public void PrecargaObjetos()
        {
            PrecargarAdministradores();
            PrecargarClientes();
            PrecargarUsuarios();
            PrecargarAviones();
            PrecargarAeropuertos();
            PrecargarRutas();
            PrecargarVuelos();
            PrecargarPasajes();
        }

        public List<Vuelo> ObtenerVuelosPorAeropuerto(string codigoAeropuerto)
        {
            List<Vuelo> vuelosPorAeropuerto = new List<Vuelo>();

            foreach (var vuelo in Vuelos)
            {
                if (vuelo.Ruta.AeropuertoSalida.CodigoIATA.ToUpper() == codigoAeropuerto.ToUpper() ||
                    vuelo.Ruta.AeropuertoEntrada.CodigoIATA.ToUpper() == codigoAeropuerto.ToUpper())
                {
                    vuelosPorAeropuerto.Add(vuelo);
                }
            }
            return vuelosPorAeropuerto;
        }


        public void AgregarVuelo(Vuelo vuelo)
        {
            try{
                vuelo.Validar();
                Vuelos.Add(vuelo);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al agregar el vuelo: {ex.Message}");
            }
            
        }
        public void AgregarRuta(Ruta ruta)
        {
            try
            {
                ruta.Validar();
                Rutas.Add(ruta);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al agregar la ruta: {ex.Message}");
            }
        }

        public void AgregarAvion(Avion avion)
        {
            try{
                    avion.Validar();
                    Aviones.Add(avion);
               }
               catch (Exception ex){
                Console.WriteLine($"Error al agregar el avion: {ex.Message}");
               }
          
        }

        public void AgregarAeropuerto(Aeropuerto aeropuerto)
        {
            try
            {
                aeropuerto.Validar();
                ValidarAeropuerto(aeropuerto);
                Aeropuertos.Add(aeropuerto);
            }
            catch(Exception ex) {
                Console.WriteLine($"Error al agregar un aeropuerto: {ex.Message}");
            }
        }

        public void AgregarAdministrador(Administrador administrador)
        {
            try {
                administrador.Validar();
                Administradores.Add(administrador);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al agregar administrador: {ex.Message}");
            }
            try
            {
                if (administrador == null)
                {
                    throw new Exception("El administrador no puede ser nulo");
                }

                administrador.Validar();
                Administradores.Add(administrador);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al agregar el administrador: {ex.Message}");
            }
        }

        public void AgregarUsuario(Usuario usuario)
        {
            try
            {  usuario.Validar();          
               Usuarios.Add(usuario);
            }
            catch (Exception ex){
                Console.WriteLine($"Error al agregar usuario: {ex.Message}");
            }
        }
        
     
        
        
        // METODOS PARA EL MENU/PROGRAM
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

      
   

    // METODOS DE VALIDAR CONTAINS

    private void ValidarAeropuerto(Aeropuerto aeropuerto)
        {
            if (Aeropuertos.Contains(aeropuerto))
            {
                throw new Exception("Ya existe un aeropuerto con ese códigoIATA.");
            }

        }
    

    private void ValidarAeropuertosEnRuta(Aeropuerto salida, Aeropuerto entrada)
        {
            if (!Aeropuertos.Contains(salida))
            {
                throw new Exception($"El aeropuerto de salida {salida.CodigoIATA} no está registrado en el sistema.");
            }
            if (!Aeropuertos.Contains(entrada))
            {
                throw new Exception($"El aeropuerto de entrada {entrada.CodigoIATA} no está registrado en el sistema.");
            }
        }

        // METODOS DE LOGIN

        public Usuario Ingresar(string email, string contrasena)
        {
            foreach (Usuario u in Usuarios)
            {
                if (u.Email == email && u.Contrasena == contrasena)
                {
                    return u;
                }
            }
            return null;
        }

        public void AltaClienteOcasional(Cliente c)
        {
            // Validar que el email no esté repetido
            foreach (Cliente cli in Clientes)
            {
                if (cli.Email == c.Email) throw new Exception("Ya existe un usuario con ese correo electronico.");
            }
            // Crear un ClienteOcasional 
            ClienteOcasional nuevoCliente = new ClienteOcasional(c.Documento, c.Nombre, c.Email, c.Contrasena, c.Nacionalidad);

            // Agregar a las listas
            Usuarios.Add(nuevoCliente);
            Clientes.Add(nuevoCliente);
        }




        public List<Vuelo> ObtenerVuelos()
        {
            
            return Vuelos.ToList();
        }
        public Pasaje ObtenerPasajePorId(int id)
        {
            foreach (Pasaje p in Pasajes)
            {
                if (p.IdPasaje == id)
                {
                    return p;
                }
            }
            throw new Exception($"No se ha encontrado el pasaje con el id {id}");
        }

        public Vuelo ObtenerVueloPorId(int id)
        {
            foreach (Vuelo p in Vuelos)
            {
                if (p.Id == id)
                {
                    return p;
                }
            }
            throw new Exception($"No se ha encontrado el producto con el id {id}");
        }

       // metodo para usar en ClienteController
        public Pasaje ComprarPasaje(Vuelo vuelo, DateTime fecha, Equipaje tipoEquipaje, Cliente cliente, Double precio)
        {
            Pasaje p = new Pasaje
            {
                Vuelo = vuelo,
                Fecha = fecha,
                TipoEquipaje = tipoEquipaje,
                Pasajero = cliente,
                Precio = precio
            };

            p.Validar();

            Pasajes.Add(p);
            cliente.PasajesComprados.Add(p);

            return p;
        }


        //obtener por email para obtener la sesion
        public Usuario ObtenerPorEmail(string email)
        {
            foreach (Usuario u in Usuarios)
            {
                if (u.Email == email)
                {
                    return u;
                }
            }
            throw new Exception ("email no encontrado.");
        }

    }
}






