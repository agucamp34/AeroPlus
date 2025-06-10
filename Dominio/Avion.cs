using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Avion: IValidable
    {
        public string Fabricante {  get; set; }
        public string Modelo { get; set; }
        public int CantidadAsientos {  get; set; }
        public double Alcance { get; set; }
        public double CostoOperacionPorKm { get; set; }

        public Avion(string fabricante, string modelo, int cantidadAsientos, double alcance, double costoOperacionPorKm)
        {
            Fabricante = fabricante;
            Modelo = modelo;
            CantidadAsientos = cantidadAsientos;
            Alcance = alcance;
            CostoOperacionPorKm = costoOperacionPorKm;

        }

        public override string ToString()
        {
            return $"Avión: {Fabricante} {Modelo}, Asientos: {CantidadAsientos}, Alcance: {Alcance} km, Costo de operación por km: {CostoOperacionPorKm:C}";
        }

        public void Validar()
        {
            if(string.IsNullOrEmpty(Fabricante))
            {
                throw new Exception("El fabricante no puede estar vacío");
            }
            if (string.IsNullOrEmpty(Modelo))
            {
                throw new Exception("El modelo no puede estar vacío");
            }
            if (CantidadAsientos <= 0)
            {
                throw new Exception("La cantidad de asientos debe ser mayor a cero");
            }
            if (Alcance <= 0)
            {
                throw new Exception("El alcance debe ser mayor a cero");
            }
            if (CostoOperacionPorKm <= 0)
            {
                throw new Exception("El costo de operación por km debe ser mayor a cero");
            }
        }
    }
}
