using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class ClienteOcasional: Cliente, IValidable
    {
        public ClienteOcasional() { } // Constructor sin parámetros requerido 
        public bool RegaloElegible { get; set; }

        public ClienteOcasional(string documento, string nombre, string email, string contrasena, string nacionalidad) : base(documento, nombre, email, contrasena, nacionalidad)

        {
            if (!EsContrasenaValida(contrasena))
            {
                throw new Exception("La contraseña debe tener al menos 8 caracteres, incluyendo letras y números.");
            }
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

        // la contraseña debe tener al menos 8 caracteres, incluyendo letras y números.
        private bool EsContrasenaValida(string contrasena) 
        {
            return contrasena.Length >= 8 && contrasena.Any(char.IsDigit) && contrasena.Any(char.IsLetter);
        }
    }
}
