using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Dominio
{
    public abstract class Partido:IValidacion
    {
        public static int UltimoId { get; set; }
        public int Id { get; set; }
        public Seleccion SeleccionUno { get; set; }
        public Seleccion SeleccionDos { get; set; }
        public DateTime FechaHora { get; set; }
        public bool Finalizado { get; set; }
        public string Resultado { get; set; }
        private List<Incidencia> _incidencias { get; set; }
        public Partido()
        {
                
        }

        protected Partido(Seleccion seleccionUno, Seleccion seleccionDos, DateTime fechaHora)
        {
            Id = UltimoId;
            UltimoId++;
            SeleccionUno = seleccionUno;
            SeleccionDos = seleccionDos;
            FechaHora = fechaHora;
            Finalizado = false;
            Resultado = "";
            _incidencias = new List<Incidencia>();
        }

        public abstract void EsValido();
        public abstract void CierrePartido();
        public abstract void Agregarincidencia(Incidencia i);
        public abstract int ContadorIncidencias();
        public abstract int ContadorAmarillasS1();
        public abstract int ContadorAmarillasS2();
        public abstract int ContadorRojasS1();
        public abstract int ContadorRojasS2();
        public abstract int ContadorGolesPartido();
        public abstract List<Incidencia> GetIncidencias();
        public override string ToString()
        {
            return $"Fecha y Hora: {FechaHora}" +
                   $" Selecciones: {SeleccionUno.Pais.Nombre} {SeleccionDos.Pais.Nombre}" +
                   $" Cantidad Incideancias: {ContadorIncidencias()}";
        }

    }
}
