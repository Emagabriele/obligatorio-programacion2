using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace Dominio
{
    public class Jugador : IValidacion, IComparable<Jugador>
    {
        public int Id { get; set; }
        public string NumeroCamiseta { get; set; }
        public string NombreCompleto { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public double Altura { get; set; }
        public string PieHabil { get; set; }
        public int ValorMercado { get; set; }
        public string TipoMoneda { get; set; }
        public Pais Pais { get; set; }
        public string Puesto { get; set; }

        public static double montoReferencia { get; set; } = 2000000;

        public Jugador()
        {

        }

        public Jugador(int id, string numeroCamiseta, string nombreCompleto, DateTime fechaNacimiento, double altura,
            string pieHabil, int valorMercado, string tipoMoneda, Pais pais, string puesto)
        {
            Id = id;
            NumeroCamiseta = numeroCamiseta;
            NombreCompleto = nombreCompleto;
            FechaNacimiento = fechaNacimiento;
            Altura = altura;
            PieHabil = pieHabil;
            ValorMercado = valorMercado;
            TipoMoneda = tipoMoneda;
            Pais = pais;
            Puesto = puesto;
            CategoriaJugador();
        }


        public void EsValido()
        {
            if (NombreCompleto.Equals(""))
            {
                throw new Exception("Nombre vacio");
            }

            if (PieHabil.Equals(""))
            {
                throw new Exception("PieHabil vacio");
            }

            if (ValorMercado < 0)
            {
                throw new Exception("Valor Mercado invalido");
            }

            if (Pais == null)
            {
                throw new Exception("Pais no valido");
            }

            if (TipoMoneda.Equals(""))
            {
                throw new Exception("Tipo moneda vacio");
            }

            if (Puesto.Equals(""))
            {
                throw new Exception("Puesto vacio");
            }
        }

        public string CategoriaJugador()
        {
            if (ValorMercado > montoReferencia)
            {
                return "VIP";
            }
            else
            {
                return "Estándar";
            }
        }
        public void CambiarValorMonto(double monto)
        {
            montoReferencia = monto;
        }
        public override string ToString()
        {
            return $"Nombre jugador: {NombreCompleto} - ValorEuros {ValorMercado} - Categoria financiera {CategoriaJugador()}";
        }

        public int CompareTo([AllowNull] Jugador other)
        {
            if (ValorMercado.CompareTo(other.ValorMercado) > 0)
            {
                return -1;
            }
            else if (ValorMercado.CompareTo(other.ValorMercado) < 0)
            {
                return 1;
            }
            else
            {

                if (NombreCompleto.CompareTo(other.NombreCompleto) > 0)
                {
                    return 1;
                }
                else if (NombreCompleto.CompareTo(other.NombreCompleto) < 0)
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
}
