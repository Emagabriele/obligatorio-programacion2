using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Dominio
{
    public class Seleccion:IComparable<Seleccion>
    {
        public Pais Pais { get; set; }
        private List<Jugador> _jugadores { get; set; }
        public Seleccion()
        {

        }
        public Seleccion(Pais pais)
        {
            Pais = pais;
            _jugadores = new List<Jugador>();
        }

        public void AgregarJugador(Jugador j)
        {
            if (!_jugadores.Contains(j))
            {
                _jugadores.Add(j);
            }
        }

        public bool EncontrarJugador(int id)
        {
            foreach (Jugador j in _jugadores)
            {
                if (j.Id == id)
                {
                    return true;
                }
            }
            return false;
        }

        public List<Jugador> GetJugadores()
        {
            return _jugadores;
        }

        public int CompareTo([AllowNull] Seleccion other)
        {
            if (Pais.Nombre.CompareTo(other.Pais.Nombre) > 0)
            {
                return 1;
            }
            else if (Pais.Nombre.CompareTo(other.Pais.Nombre) < 0)
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }
    }
}
