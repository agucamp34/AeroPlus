using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Administrador : Usuario , IValidable
    {
        public string Apodo { get; set; }

        public Administrador(string apodo, string email, string contrasena): base(email, contrasena) // Solo email y contraseña, como espera Usuario 
        { 
            Apodo = apodo;

            
        }

        public new void Validar()
        {
            if (string.IsNullOrEmpty(Apodo))
            {
                throw new Exception("El apodo no puede estar vacío.");
            }
        }
        public override string ToString()
        {
            return base.ToString() + $"Apodo: {Apodo} ";
        }

       public void ModificarPuntosClientePremium(ClientePremium cliente, int nuevosPuntos)
        {
            if(nuevosPuntos < 0)
            {
                throw new Exception("Los puntos no pueden ser negativos.");
            }
            cliente.Puntos = nuevosPuntos;

        }

        public void CambiarElegibilidadClienteOcasional(ClienteOcasional cliente, bool elegible)
        {
            cliente.RegaloElegible = elegible;
        }   

        
    }
}
