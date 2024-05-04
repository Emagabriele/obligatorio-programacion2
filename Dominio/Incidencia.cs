using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio
{
    public class Incidencia:IValidacion
    {
        public string Tipo { get; set; }
        public int Minuto { get; set; }
        public Jugador Jugador { get; set; }
        public Incidencia()
        {

        }
        public Incidencia(string tipo, int minuto, Jugador jugador)
        {
            Tipo = tipo;
            Minuto = minuto;
            Jugador = jugador;
        }

        public void EsValido()
        {
            if (Minuto < -1)
            {
                throw new Exception("Minuto invalido");
            }
            if (Tipo.Equals(""))
            {
                throw new Exception("Tipo vacio");
            }
            if (Jugador == null)
            {
                throw new Exception("Jugador null");
            }
        }
    }
}
