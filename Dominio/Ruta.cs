using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Ruta

    {
        public static int UltimoIdRuta = 0;
        public int IdRuta {  get;  private set; }
        public  required Aeropuerto AeropuertoSalida  {  get; set; }
        public  required Aeropuerto AeropuertoEntrada  { get; set; }
        public double Distancia { get; set; }

        

        public Ruta()
        {
            IdRuta = ++UltimoIdRuta;
        }

        public Ruta(int idRuta, Aeropuerto aeropuertoSalida, Aeropuerto aeropuertoEntrada, double distancia)
        {
            IdRuta = idRuta;
            AeropuertoSalida = aeropuertoSalida;
            AeropuertoEntrada = aeropuertoEntrada;
            Distancia = distancia;
        }

        public void ValidarRuta()
        {
            if (AeropuertoSalida == null)
            {
                throw new Exception("El aeropuerto de salida no puede ser nulo");
            }
            if (AeropuertoEntrada == null)
            {
                throw new Exception("El aeropuerto de entrada no puede ser nulo");
            }
            if (Distancia <= 0)
            {
                throw new Exception("La distancia debe ser mayor a cero");
            }
        }
    }
}
