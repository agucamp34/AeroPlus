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
                    //ListarPasajesEntreFechas();
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
            Console.WriteLine($"Tipo: {tipoCliente}, {cliente}");
        }
    }

    private static void ListarVuelosPorCodigoAeropuerto()
    {
        Console.Write("\nIngrese el código del aeropuerto: ");
        string codigo = Console.ReadLine();

        Console.WriteLine("\n=== Vuelos que incluyen el aeropuerto ===");
        foreach (var vuelo in sistema.ObtenerVuelosPorAeropuerto(codigo))
        {
            Console.WriteLine($"Número de vuelo: {vuelo.NumeroVuelo}, Modelo del avión: {vuelo.Avion.Modelo}, Ruta: {vuelo.Ruta.AeropuertoSalida.CodigoIATA} -> {vuelo.Ruta.AeropuertoEntrada.CodigoIATA}, Frecuencia: {string.Join(", ", vuelo.Frecuencia)}");
        }
    }

    private static void AltaClienteOcasional()
    {
        Console.Clear();
        Console.WriteLine("=== Alta de Cliente Ocasional ===");
        Console.Write("Ingrese el nombre: ");
        string nombre = Console.ReadLine();
        Console.Write("Ingrese el documento: ");
        string documento = Console.ReadLine();
        Console.Write("Ingrese el email: ");
        string email = Console.ReadLine();
        Console.Write("Ingrese la contraseña: ");
        string contrasena = Console.ReadLine();
        Console.Write("Ingrese la nacionalidad: ");
        string nacionalidad = Console.ReadLine();

        // Crear el cliente ocasional
        ClienteOcasional clienteOcasional = new ClienteOcasional(documento, nombre, email, contrasena, nacionalidad);

        // Agregar el cliente al sistema
        sistema.AgregarCliente(clienteOcasional);

        Console.WriteLine($"Cliente Ocasional {nombre} agregado exitosamente.");
    }
}
