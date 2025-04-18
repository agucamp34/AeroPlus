using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Usuario
    {
        public string Email { get; private set; }
        public string Contrasena { get; private set; }

        public Usuario(string email, string contrasena)
        {
            Email = email;
            Contrasena = contrasena;
        }

        public override string ToString()
        {
            return $"Email: {Email}";
        }
    }
}
