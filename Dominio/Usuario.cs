using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Usuario : IValidable
    {
        
        public string Email { get; private set; }
        public string Contrasena { get; private set; }

        public Usuario(string email, string contrasena)
        {
            Email = email;
            Contrasena = contrasena;

        }
        public Usuario() { }
        public void Validar()
        {
            if (string.IsNullOrEmpty(Email))
            {
                throw new Exception("El email no puede estar vacío.");
            }
            if (string.IsNullOrEmpty(Contrasena))
            {
                throw new Exception("La contraseña no puede estar vacía.");
            }
        }
        public override string ToString()
        {
            return $"Email: {Email}";
        }
    }
}
