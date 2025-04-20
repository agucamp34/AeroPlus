using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class ClienteOcasional: Cliente
    {
        public bool RegaloElegible { get; set; }

        public ClienteOcasional(string documento, string nombre, string email, string contrasena, string nacionalidad) : base(documento, nombre, email, contrasena, nacionalidad)

        {
            RegaloElegible = new Random().Next(0, 2) == 1;
        }

        public override string ToString()
        {
            return base.ToString() + $", Regalo Elegible: {(RegaloElegible ? "Si" : "No")}";
        }

        public override decimal CalcularRecargoPorEquipaje(Equipaje equipaje)
        {
            if (equipaje == Equipaje.CABINA)
            {
                return 0.10m;
            }
            else if (equipaje == Equipaje.BODEGA)
            {
                return 0.20m;
            }
            else
            {
                return 0m;
            }
        }
    }
}
