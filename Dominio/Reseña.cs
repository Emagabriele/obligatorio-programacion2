using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Dominio
{
    public class Reseña:IComparable<Reseña>,IValidacion
    {
        public Periodista Periodista { get; set; }
        public DateTime Fecha { get; set; }
        public Partido Partido { get; set; }
        public string Titulo { get; set; }
        public string Contenido { get; set; }
        public Reseña()
        {

        }
        public Reseña(Periodista periodista, DateTime fecha, Partido partido, string titulo, string contenido)
        {
            Periodista = periodista;
            Fecha = fecha;
            Partido = partido;
            Titulo = titulo;
            Contenido = contenido;
        }

        public int CompareTo([AllowNull] Reseña other)
        {
            if (Fecha.CompareTo(other.Fecha) > 0)
            {
                return -1;
            }
            else if (Fecha.CompareTo(other.Fecha) < 0)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

        public void EsValido()
        {
            if(Titulo == null || Contenido == null)
            {
                throw new Exception("Campos Vacios");
            }
        }
    }
}
