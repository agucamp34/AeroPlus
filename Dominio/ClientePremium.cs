using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class ClientePremium: Cliente
    {
        public int Puntos { get; set; }

        public ClientePremium(string documento, string nombre, string email, string contrasena,string nacionalidad, int puntos) : base(documento, nombre, email, contrasena, nacionalidad)// esto llama al constructor de Cliente

        {
            Puntos = puntos; // esto inicializa el nuevo campo exclusivo de ClientePremium
        }

        public override string ToString()
        {
            return base.ToString() + $", Puntos: {Puntos}";
        }
        public override decimal CalcularRecargoPorEquipaje(Equipaje equipaje)
        {
            if (equipaje == Equipaje.BODEGA)
            {
                return 0.05m;
            }
            else
            {
                return 0m;
            }

        }
    }
}
