using System;
using System.Diagnostics.CodeAnalysis;

namespace Dominio
{
    public class Periodista:Usuario,IValidacion
    {
        public Periodista()
        {

        }
        public Periodista(string nombre, string apellido, string email, string password) : base (nombre, apellido, email, password)
        {
        }

        public override string GetRol()
        {
            return "Periodista";
        }
    }

}
