using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Vuelo
    {
        public string NumeroVuelo { get; private set; }
        public Ruta Ruta { get; set; }
        public Avion Avion { get; set; }
        public List<DiaSemana> Frecuencia { get; set; }

        public Vuelo(string numeroVuelo, Ruta ruta, Avion avion, List<DiaSemana> frecuencia)
        {
            //Se deberá validar, entre otras, que el avión tenga el alcance para cubrir la distancia de la ruta.

            if (avion.Alcance < ruta.Distancia)
            {
                throw new Exception($"El avión {avion.Modelo} no tiene alcance suficiente para la ruta ({ruta.Distancia}).");
            }

            NumeroVuelo = numeroVuelo;
            Ruta = ruta;
            Avion = avion;
            Frecuencia = frecuencia;
        }

        public override string ToString()
        {
            string frecuenciaDias = string.Join(", ", Frecuencia);
            return $"Número de vuelo: {NumeroVuelo}, Ruta: {Ruta.AeropuertoSalida.CodigoIATA} -> {Ruta.AeropuertoEntrada.CodigoIATA}, Avión: {Avion.Modelo}, Frecuencia: {frecuenciaDias}";
        }

        public bool SeRealizaEn(DiaSemana dia)
        {
            return Frecuencia.Contains(dia); // El método Contains verifica si un elemento está dentro de una colección.

        }

        public double CalcularCostoPorAsiento()
        {
         
            Ruta.ValidarRuta();
            Avion.ValidarAvion();

            // Costo del trayecto según el avión y la distancia por KM
            double costoTrayecto = Avion.CostoOperacionPorKm * Ruta.Distancia;

            // Suma del costo de operación de los aeropuertos
            double costoAeropuertos = Ruta.AeropuertoSalida.CostoOperacion + Ruta.AeropuertoEntrada.CostoOperacion;

            // Costo total dividio entre las canidad de asientos
            double costoTotal = costoTrayecto + costoAeropuertos;

            return costoTotal / Avion.CantidadAsientos;

        }
    }
}
