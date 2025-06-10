using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Pasaje: IValidable
    {
        public static int UltimoIdPasaje = 0;
        public int IdPasaje {  get; set; }
        public Vuelo Vuelo { get; set; }
        public DateTime Fecha { get; set; }
        public Equipaje TipoEquipaje { get; set; }
        public double Precio { get; set; }

        public Cliente Pasajero  { get; set; }

        public Pasaje(Vuelo vuelo, DateTime fecha, Equipaje tipoEquipaje, Cliente pasajero)
        {
            IdPasaje = ++UltimoIdPasaje;
            Vuelo = vuelo; 
            Pasajero = pasajero; 
            Fecha = fecha;
            TipoEquipaje = tipoEquipaje;
            Precio = CalcularPrecioPasaje(); 
        }

        public Pasaje()
        {
            IdPasaje = ++UltimoIdPasaje;
        }


        public void Validar()
        {
            if (Vuelo == null)
            {
                throw new Exception("El vuelo no puede ser nulo");
            }
            if (Pasajero == null)
            {
                throw new Exception("El pasajero no puede ser nulo");
            }
            
        }

        public override string ToString()
        {
            return $"Pasaje ID: {IdPasaje}, Pasajero: {Pasajero.Nombre}, Vuelo: {Vuelo.NumeroVuelo}, Precio: {Precio}, Equipaje: {TipoEquipaje}";
        }
        
        
        /// <summary>
        /// Calcular el precio de cada pasaje
        /// </summary>
        /// <returns>Precio final del pasaje</returns>
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
