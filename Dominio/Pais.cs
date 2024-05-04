using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio
{
    public class Pais:IValidacion
    {
        private static int UltimoId { get; set; }
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Codigo { get; set; }
        public Pais()
        {

        }
        public Pais(string nombre, string codigo)
        {
            Id = UltimoId;
            UltimoId++;
            Nombre = nombre;
            Codigo = codigo;
        }

        public void EsValido()
        {
            if(Nombre.Equals(""))
            {
                throw new Exception("Nombre vacio");
            }
            if(Codigo.Length != 3)
            {
                throw new Exception("El codigo debe estar compuesto por 3 caracteres");
            }
        }
    }
}
