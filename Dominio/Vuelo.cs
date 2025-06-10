
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Vuelo : IValidable
    {
        public int Id = 0;
        public string NumeroVuelo { get; private set; }
        public Ruta Ruta { get; set; }
        public Avion Avion { get; set; }
        public List<DayOfWeek> Frecuencia { get; set; }

        public Vuelo(int id, string numeroVuelo, Ruta ruta, Avion avion, List<DayOfWeek> frecuencia)
        {
            Id = id;
            NumeroVuelo = numeroVuelo;
            Ruta = ruta;
            Avion = avion;
            Frecuencia = frecuencia;

        }
        public string DevolverFrecuencia()
        {
            string dias = "";
            foreach (DayOfWeek d in this.Frecuencia)
            {
                dias += d.ToString() + " ";
            }
            return dias;
        }

        public void Validar()
        {
            if (string.IsNullOrEmpty(NumeroVuelo))
            {
                throw new Exception("El número de vuelo no puede estar vacío.");
            }
            if (Ruta == null)
            {
                throw new Exception("La ruta no puede ser nula.");
            }
            if (Avion == null)
            {
                throw new Exception("El avión no puede ser nulo.");
            }
            if (Frecuencia == null || Frecuencia.Count == 0)
            {
                throw new Exception("La frecuencia no puede ser nula o vacía.");
            }
            if (!TieneAlcanceSuficiente())
            {
                throw new Exception($"El avión {Avion.Modelo} no tiene alcance suficiente para la ruta ({Ruta.Distancia} km).");
            }
        }

        private bool TieneAlcanceSuficiente()
        {
            return Avion.Alcance >= Ruta.Distancia;
        }

        public override string ToString()
        {
            string frecuenciaDias = string.Join(", ", Frecuencia);
            return $"Número de vuelo: {NumeroVuelo}, Ruta: {Ruta.AeropuertoSalida.CodigoIATA} -> {Ruta.AeropuertoEntrada.CodigoIATA}, Avión: {Avion.Modelo}, Frecuencia: {DevolverFrecuencia()}";
        }

        /*public bool SeRealizaEn(DiaSemana dia)
        {
            return Frecuencia.Contains(dia); // El método Contains verifica si un elemento está dentro de una colección.

        }
        */
        public double CalcularCostoPorAsiento()
        {
         
            Ruta.Validar();
            Avion.Validar();

            // Costo del trayecto según el avión y la distancia por KM
            double costoTrayecto = Avion.CostoOperacionPorKm * Ruta.Distancia;

            // Suma del costo de operación de los aeropuertos
            double costoAeropuertos = Ruta.AeropuertoSalida.CostoOperacion + Ruta.AeropuertoEntrada.CostoOperacion;

            // Costo total dividio entre las canidad de asientos
            double costoTotal = costoTrayecto + costoAeropuertos;

            return costoTotal / Avion.CantidadAsientos;

        }
        public string DevolverDias()
        {
            return string.Join(", ", Frecuencia);
        }

    }
}
