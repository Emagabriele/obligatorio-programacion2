using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Text;

namespace Dominio
{
    public class FaseEliminatoria:Partido
    {
        public bool Alargue { get; set; }
        public bool Penales { get; set; }
        public string Etapa { get; set; }
        private List<Incidencia> _incidencias { get; set; }
        public FaseEliminatoria()
        {

        }
        public FaseEliminatoria(bool alargue, bool penales, string etapa, Seleccion seleccionUno, Seleccion seleccionDos, DateTime fechaHora) :base(seleccionUno, seleccionDos, fechaHora)
        {
            Alargue = alargue;
            Penales = penales;
            Etapa = etapa;
            _incidencias = new List<Incidencia>();
        }

        public override void CierrePartido()
        {
            if (!Finalizado)
            {
                int contadorUno = 0;
                int contadorDos = 0;

                foreach (Incidencia i in _incidencias)
                {
                    if (i.Tipo == "Gol" & i.Jugador.Pais.Id == SeleccionUno.Pais.Id)
                    {
                        contadorUno++;
                    }
                    if (i.Tipo == "Gol" & i.Jugador.Pais.Id == SeleccionDos.Pais.Id)
                    {
                        contadorDos++;
                    }

                }

                if (contadorUno > contadorDos)
                {
                    Resultado = $"Ganador:[{SeleccionUno.Pais.Nombre}]";
                }
                else if (contadorDos > contadorUno)
                {
                    Resultado = $"Ganador:[{SeleccionDos.Pais.Nombre}]";
                }
                else if(contadorDos == contadorUno)
                {
                    foreach (Incidencia i in _incidencias)
                    {
                        if (i.Tipo == "Gol" & i.Jugador.Pais.Id == SeleccionUno.Pais.Id & Penales)
                        {
                            contadorUno++;
                        }
                        if (i.Tipo == "Gol" & i.Jugador.Pais.Id == SeleccionDos.Pais.Id & Penales)
                        {
                            contadorDos++;
                        }

                    }
                    if (contadorUno > contadorDos)
                    {
                        Resultado = $"Empate en tiempo de juego. Ganador:[{SeleccionUno.Pais.Nombre}] en tanda de penales";
                    }
                    else if (contadorDos > contadorUno)
                    {
                        Resultado = $"Empate en tiempo de juego. Ganador:[{SeleccionDos.Pais.Nombre}] en tanda de penales";
                    }
                }

                Finalizado = true;
            }
        }

        public override void EsValido()
        {
            if (Etapa.Equals(""))
            {
                throw new Exception("Etapa vacio");
            }
            if (SeleccionUno == null || SeleccionDos == null)
            {
                throw new Exception("Seleccion null");
            }
            if (FechaHora < new DateTime(2022, 11, 20) && FechaHora > new DateTime(2022, 12, 18))
            {
                throw new Exception("Fecha invalida");
            }
        }

        public override void Agregarincidencia(Incidencia i)
        {
            try
            {
                i.EsValido();
                _incidencias.Add(i);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public override int ContadorIncidencias()
        {
            int Contador = 0;
            foreach (Incidencia i in _incidencias)
            {
                Contador++;
            }
            return Contador;
        }

        public override int ContadorGolesPartido()
        {
            int contador = 0;
            foreach(Incidencia i in _incidencias)
            {
                if (i.Tipo == "Gol")
                {
                    contador++;
                }
            }
            return contador;
        }

        public override List<Incidencia> GetIncidencias()
        {
            return _incidencias;
        }

        public override int ContadorAmarillasS1()
        {
            int contador = 0;
            foreach (Incidencia i in _incidencias)
            {
                if (i.Tipo == "Amarilla" & i.Jugador.Pais.Id == SeleccionUno.Pais.Id)
                {
                    contador++;
                }
            }
            return contador;
        }
        public override int ContadorAmarillasS2()
        {
            int contador = 0;
            foreach (Incidencia i in _incidencias)
            {
                if (i.Tipo == "Amarilla" & i.Jugador.Pais.Id == SeleccionDos.Pais.Id)
                {
                    contador++;
                }
            }
            return contador;
        }

        public override int ContadorRojasS1()
        {
            int contador = 0;
            foreach (Incidencia i in _incidencias)
            {
                if (i.Tipo == "Roja" & i.Jugador.Pais.Id == SeleccionUno.Pais.Id)
                {
                    contador++;
                }
            }
            return contador;
        }

        public override int ContadorRojasS2()
        {
            int contador = 0;
            foreach (Incidencia i in _incidencias)
            {
                if (i.Tipo == "Roja" & i.Jugador.Pais.Id == SeleccionDos.Pais.Id)
                {
                    contador++;
                }
            }
            return contador;
        }
    }
}
