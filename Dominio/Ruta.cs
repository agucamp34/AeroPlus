using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Ruta : IValidable

    {
        public static int UltimoIdRuta = 0;
        public int IdRuta {  get;  private set; }
        public   Aeropuerto AeropuertoSalida  {  get; set; }
        public   Aeropuerto AeropuertoEntrada  { get; set; }
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

       
        public void Validar()
        {
            if (AeropuertoSalida == null)
            {
                throw new Exception("El aeropuerto de salida no puede ser nulo");
            }
            if (AeropuertoEntrada == null)
            {
                throw new Exception("El aeropuerto de entrada no puede ser nulo");
            }
            if (AeropuertoSalida.CodigoIATA == AeropuertoEntrada.CodigoIATA)
            {
                throw new Exception("El aeropuerto de salida y el de entrada no pueden ser el mismo");
            }
            if (Distancia <= 0)
            {
                throw new Exception( "La distancia debe ser mayor a cero");
            }
        }
    }
}
