using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio
{
    public class Operador:Usuario
    {
        public DateTime FechaComienzoTrabajo { get; set; }

        public Operador()
        {

        }
        public Operador(DateTime fechaComienzoTrabajo, string nombre, string apellido, string email, string password) : base (nombre, apellido, email, password)
        {
            FechaComienzoTrabajo = fechaComienzoTrabajo;
        }

        public override string GetRol()
        {
            return "Operador";
        }
    }
}
