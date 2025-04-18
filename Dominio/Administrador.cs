using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Administrador : Usuario
    {
        public string Apodo { get; set; }

        public Administrador(string apodo, string email, string contrasena): base(email, contrasena) // Solo email y contraseña, como espera Usuario 
        { 
            Apodo = apodo;
        }

        public override string ToString()
        {
            return base.ToString() + $"Apodo: {Apodo} ";
        }

        private void ModificarPuntos(int puntos)
        {

        }

        private void CambiarEligibilidad (int id) 
        {

        }
    }
}
