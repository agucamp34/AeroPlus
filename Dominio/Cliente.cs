using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public abstract class Cliente : Usuario, IValidable
    {

        public string Documento { get; set; }
        public string Nombre { get; set; }
        public string Nacionalidad { get; set; }
        public List<Pasaje> PasajesComprados { get; set; }

        public Cliente() { }

        public Cliente(string documento, string nombre, string email, string contrasena, string nacionalidad) : base(email, contrasena) //Solo email y contraseña, como espera Usuario

        {
            Documento = documento;
            Nombre = nombre;
            Nacionalidad = nacionalidad;
            PasajesComprados = new List<Pasaje>();
            Rol = Rol.Cliente;
        }

        public override void Validar()
        {
            base.Validar();

            if (string.IsNullOrEmpty(Documento))
            {
                throw new Exception("El documento no puede estar vacío.");
            }
            if (Documento.Length != 8)
            {
                throw new Exception("El documento debe tener 8 dígitos");
            }
            if (string.IsNullOrEmpty(Nombre))
            {
                throw new Exception("El nombre no puede estar vacío.");
            }
        }

        public override bool Equals(object? obj)
        {
            Cliente otro = (Cliente)obj;
            return Email == otro.Email;
        }
        public override string ToString()
        {
            return $"Nombre: {Nombre}, Email: {Email}, Nacionalidad: {Nacionalidad} ";
        }

        public abstract decimal CalcularRecargoPorEquipaje(Equipaje equipaje);
    }
}
