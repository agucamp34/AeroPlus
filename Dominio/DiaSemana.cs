using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public enum  DiaSemana
    {
        Lunes,
        Martes,
        Miercoles,
        Jueves,
        Viernes,
        Sabado,
        Domingo
    }

    public class Dia
    {
        public DiaSemana DiaSemana { get; set; }
        public DateTime Fecha { get; set; }
        public Dia(DiaSemana diaSemana, DateTime fecha)
        {
            DiaSemana = diaSemana;
            Fecha = fecha;
        }
        public override string ToString()
        {
            return $"{DiaSemana} - {Fecha.ToShortDateString()}";
        }
    }
}
