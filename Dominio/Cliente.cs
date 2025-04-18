using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public abstract class Cliente : Usuario
    {
        public string Documento { get; set; }
        public string Nombre {  get; set; }
        public string Nacionalidad { get; set; }

        

        public Cliente(string documento, string nombre, string email, string contrasena, string nacionalidad) : base(email, contrasena) //Solo email y contraseña, como espera Usuario

        {
            Documento = documento;
            Nombre = nombre;
            Nacionalidad = nacionalidad;
        }

        public void ValidarCliente()
        {
            if (string.IsNullOrEmpty(Documento))
            {
                throw new ArgumentException("El documento no puede estar vacío.");
            }
            if (string.IsNullOrEmpty(Nombre))
            {
                throw new ArgumentException("El nombre no puede estar vacío.");
            }
            if (string.IsNullOrEmpty(Email))
            {
                throw new ArgumentException("El email no puede estar vacío.");
            }
            if (string.IsNullOrEmpty(Contrasena))
            {
                throw new ArgumentException("La contraseña no puede estar vacía.");
            }
        }
        public override string ToString()
        {
            return $" Cliente - Nombre: {Nombre}, Email: {Email}, Nacionalidad: {Nacionalidad}";
        }

        public abstract decimal CalcularRecargoPorEquipaje (Equipaje equipaje);
    }
}
