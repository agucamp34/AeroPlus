using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Usuario : IValidable
    {

        public string Email { get; set; }
        public string Contrasena { get; set; }
        public Rol Rol { get; set; }

        public Usuario(string email, string contrasena)
        {
            Email = email;
            Contrasena = contrasena;
        }
        public Usuario() { }


        public virtual void Validar()
        {
            if (string.IsNullOrEmpty(Email))
            {
                throw new Exception("El email no puede estar vacío.");
            }
            if (string.IsNullOrEmpty(Contrasena))
            {
                throw new Exception("La contraseña no puede estar vacía.");
            }
            else
            {
                if (Contrasena.Length < 8 ||
                    !Contrasena.Any(char.IsDigit) ||
                    !Contrasena.Any(char.IsLetter))
                {
                    throw new Exception("La contraseña debe tener al menos 8 caracteres, una letra y un numero.");
                }
            }
        }



        public override string ToString()
        {
            return $"Email: {Email}";
        }
    }
}
