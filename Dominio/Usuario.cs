using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio
{
    public abstract class Usuario:IComparable<Usuario>
    {
        private static int UltimoId { get; set; }
        public int Id { get; set; }
        public string Nombre { get; set; }

        public string Apellido { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public Usuario()
        {

        }

        public Usuario(string nombre, string apellido, string email, string password)
        {
            Id = UltimoId;
            UltimoId++;
            Nombre = nombre;
            Apellido = apellido;
            Email = email;
            Password = password;
        }

        public abstract string GetRol();

        public void EsValido()
        {
            if (Nombre.Equals(""))
            {
                throw new Exception("Nombre vacio");
            }
            if (Apellido.Equals(""))
            {
                throw new Exception("Apellido vacio");
            }
            if (Email.Equals(""))
            {
                throw new Exception("Email vacio");
            }

            bool arroba = false;
            bool pos = false;

            for (int i = 0; i < Email.Length; i++)
            {
                char caracter = Email[i];
                if (caracter.ToString() == "@")
                {
                    arroba = true;
                }

                if (Email[0].ToString() == "@" || Email[Email.Length - 1].ToString() == "@")
                {
                    pos = true;
                }
            }

            if (arroba.Equals(false))
            {
                throw new Exception("El correo no tiene @");
            }

            if (pos.Equals(true))
            {
                throw new Exception("Correo invalido");
            }

            if (Password.Length < 7)
            {
                throw new Exception("La password debe contener minimo 8 caracteres");
            }
        }

        public int CompareTo(Usuario other)
        {
            if (Apellido.CompareTo(other.Apellido) > 0)
            {
                return 1;
            }
            else if (Apellido.CompareTo(other.Apellido) < 0)
            {
                return -1;
            }
            else
            {
                if (Nombre.CompareTo(other.Nombre) > 0)
                {
                    return 1;
                }
                else if (Nombre.CompareTo(other.Nombre) < 0)
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
