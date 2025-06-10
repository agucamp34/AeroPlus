using System.Security.Cryptography.X509Certificates;

using Dominio;

     internal static class Program
    {
        private static Sistema sistema = new Sistema();
        static void Main(string[] args)
        {
          Sistema sistema = new Sistema();

        int opcion= -1; // La variable opcion se inicializa en -1 para garantizar que el valor inicial sea un número que no coincida con ninguna de las opciones válidas del menú
        do
        {
            Console.Clear();
            Console.WriteLine("=== Menú Principal ===");
            Console.WriteLine("1. Listas todos los clientes");
            Console.WriteLine("2. Listar vuelos por código de aeropuerto");
            Console.WriteLine("3. Alta de Cliente Ocasional");
            Console.WriteLine("4. Listar pasajes entre dos fechas");
            Console.WriteLine("0. Salir");
            Console.Write("Seleccione una opción: ");
            opcion = int.Parse(Console.ReadLine());
          
            switch (opcion)
            {
                case 1:
                    ListarClientes();
                    break;
                case 2:
                    ListarVuelosPorCodigoAeropuerto();
                    break;
                case 3:
                    AltaClienteOcasional();
                    break;
                case 4:
                    ListarPasajesEntreFechas();
                    break;
                case 0:
                    Console.WriteLine("Saliendo del programa...");
                    break;
                default:
                    Console.WriteLine("Opción no válida. Intente nuevamente.");
                    break;
            }

            if(opcion != 0)
            {
                Console.WriteLine("Presione cualquier tecla para continuar...");
                Console.ReadKey();
            }
        }
        while (opcion != 0);
    }


    private static void ListarClientes()
    {
        Console.Clear();
        Console.WriteLine("=== Lista de Clientes ===");
        foreach (var cliente in sistema.Clientes)
        {
            string tipoCliente = cliente.GetType().Name;
            Console.Write($"Tipo: {tipoCliente}, Nombre: {cliente.Nombre}, Email: {cliente.Email}, Nacionalidad: {cliente.Nacionalidad}");

            if (cliente is ClientePremium clientePremium)
            {
                Console.WriteLine($", Puntos: {clientePremium.Puntos}");
            }
            else if (cliente is ClienteOcasional clienteOcasional)
            {
                Console.WriteLine($", Elegible: {(clienteOcasional.RegaloElegible ? "Sí" : "No")}");
            }
        }
    }

    private static void ListarVuelosPorCodigoAeropuerto()
    {
        Console.Clear();
        Console.WriteLine("=== Listar Vuelos por Código de Aeropuerto ===");
        Console.Write("Ingrese el código del aeropuerto: ");
        string codigo = Console.ReadLine().ToUpper(); // Convertir a mayúsculas

        Console.WriteLine("\n=== Vuelos que incluyen el aeropuerto ===");

        var vuelos = sistema.ObtenerVuelosPorAeropuerto(codigo);

        if (vuelos.Count == 0)
        {
            Console.WriteLine($"No se encontraron vuelos que incluyan el aeropuerto con código {codigo}.");
            return;
        }

        foreach (var vuelo in vuelos)
        {
            string ruta = $"{vuelo.Ruta.AeropuertoSalida.CodigoIATA} – {vuelo.Ruta.AeropuertoEntrada.CodigoIATA}";
            string frecuencia = string.Join(", ", vuelo.Frecuencia);

            Console.WriteLine($"Número de vuelo: {vuelo.NumeroVuelo}, Modelo del avión: {vuelo.Avion.Modelo}, Ruta: {ruta}, Frecuencia: {frecuencia}");
        }
    }

    private static void AltaClienteOcasional()
    {
        Console.Clear();
        Console.WriteLine("=== Alta de Cliente Ocasional ===");

        string nombre = "";
        while (true)
        {
            Console.Write("Ingrese el nombre: ");
            nombre = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(nombre))
                break;
            Console.WriteLine("El nombre no puede estar vacío. Intente nuevamente.");
        }

        string documento = "";
        while (true)
        {
            Console.Write("Ingrese el documento: ");
            documento = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(documento) && documento.All(char.IsDigit))
                break;
            Console.WriteLine("El documento debe ser un número y no puede estar vacío. Intente nuevamente.");
        }

        string email = "";
        while (true)
        {
            Console.Write("Ingrese el email: ");
            email = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(email))
                break;
            Console.WriteLine("El email no puede estar vacío. Intente nuevamente.");
        }

        string contrasena = "";
        while (true)
        {
            Console.Write("Ingrese la contraseña: ");
            contrasena = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(contrasena))
                break;
            Console.WriteLine("La contraseña no puede estar vacía. Intente nuevamente.");
        }

        string nacionalidad = "";
        while (true)
        {
            Console.Write("Ingrese la nacionalidad: ");
            nacionalidad = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(nacionalidad))
                break;
            Console.WriteLine("La nacionalidad no puede estar vacía. Intente nuevamente.");
        }

        // Crear el cliente ocasional
        ClienteOcasional clienteOcasional = new ClienteOcasional(documento, nombre, email, contrasena, nacionalidad);

        // Agregar el cliente al sistema
        sistema.AgregarCliente(clienteOcasional);

        Console.WriteLine($"Cliente Ocasional {nombre} agregado exitosamente.");
    }


    private static void ListarPasajesEntreFechas()
    {
        Console.Clear();
        Console.WriteLine("=== Listar Pasajes entre Fechas ===");

        // Solicitar y validar la fecha de inicio
        DateTime fechaInicio;
        while (true)
        {
            Console.Write("Ingrese la fecha de inicio (dd/MM/yyyy): ");
            if (DateTime.TryParse(Console.ReadLine(), out fechaInicio))
                break;
            Console.WriteLine("Fecha inválida. Intente nuevamente.");
        }

        // Solicitar y validar la fecha de fin
        DateTime fechaFin;
        while (true)
        {
            Console.Write("Ingrese la fecha de fin (dd/MM/yyyy): ");
            if (DateTime.TryParse(Console.ReadLine(), out fechaFin))
                break;
            Console.WriteLine("Fecha inválida. Intente nuevamente.");
        }

        // Verificar que la fecha de inicio no sea mayor que la fecha de fin
        if (fechaInicio > fechaFin)
        {
            Console.WriteLine("La fecha de inicio no puede ser mayor que la fecha de fin.");
            return;
        }

        // Obtener pasajes entre fechas usando método en Sistema
        List<Pasaje> pasajes = sistema.ObtenerPasajeEntreFechas(fechaInicio, fechaFin);

        // Mostrar resultados
        if (pasajes.Count == 0)
        {
            Console.WriteLine($"\nNo se encontraron pasajes entre {fechaInicio:dd/MM/yyyy} y {fechaFin:dd/MM/yyyy}.");
        }
        else
        {
            Console.WriteLine($"\n=== Pasajes entre {fechaInicio:dd/MM/yyyy} y {fechaFin:dd/MM/yyyy} ===");
            foreach (Pasaje pasaje in pasajes)
            {
                Console.WriteLine($"ID: {pasaje.IdPasaje}, Pasajero: {pasaje.Pasajero.Nombre}, Vuelo: {pasaje.Vuelo.NumeroVuelo}, Fecha: {pasaje.Fecha:dd/MM/yyyy}, Precio: {pasaje.Precio:C}, Equipaje: {pasaje.TipoEquipaje}");
            }
        }
    }




}



//asdasdaaaaaaaaa