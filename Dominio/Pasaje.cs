using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Pasaje
    {
        public static int UltimoIdPasaje = 0;
        public int IdPasaje {  get; private set; }
        public Vuelo Vuelo { get; set; }
        public DateTime Fecha { get; set; }
        public Equipaje TipoEquipaje { get; set; }
        public double Precio { get; set; }

        public Cliente Pasajero  { get; set; }

        public Pasaje(int idPasaje, Vuelo vuelo,DateTime fecha, Equipaje tipoEquipaje, double precio, Cliente pasajero) 
        {
            IdPasaje = ++UltimoIdPasaje;
            Fecha = fecha;
            TipoEquipaje = tipoEquipaje;
            Precio = precio;
            Vuelo = vuelo;
            Pasajero = pasajero;
        }


      

        public override string ToString()
        {
            return $"Pasaje ID: {IdPasaje}, Pasajero: {Pasajero.Nombre}, Vuelo: {Vuelo.NumeroVuelo}, Precio: {Precio:C}, Equipaje: {TipoEquipaje}";
        }
        
        
        
        
        
        
        
        
        public double CalcularPrecioPasaje()
        {
            // El costo base es igual al costoPorAsiento()
            double costoBase = Vuelo.CalcularCostoPorAsiento();

            double precioConMargen = costoBase * 1.25; // Se le agrega un margen del 25%
            
            // Calcula el recargo por equipaje según el tipo de cliente
            decimal recargoEquipaje = Pasajero.CalcularRecargoPorEquipaje(TipoEquipaje);
            double precioConEquipaje = precioConMargen * (1 + (double)recargoEquipaje);

            // Sumar las tasas de los 2 aeropuertos
            double tasasAeropuerto = Vuelo.Ruta.AeropuertoSalida.Tasa + Vuelo.Ruta.AeropuertoEntrada.Tasa;

            //Precio Final
            return precioConEquipaje + tasasAeropuerto;

        }

      

        
    }
}
