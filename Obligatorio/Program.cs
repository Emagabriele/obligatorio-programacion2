using System;
using Dominio;

namespace Obligatorio
{
    class Program
    {
        static void Main(string[] args)
        {
            Sistema s = Sistema.GetInstancia();

            int op = -1;

            while (op != 0)
            {
                Console.Clear();
                Console.WriteLine("1 - Alta Periodista");
                Console.WriteLine("2 - Categoria financiera");
                Console.WriteLine("3 - Dado el id de un jugador listar todos los partidos en los que haya participado");
                Console.WriteLine("4 - Listar todos los jugadores que han sido expulsados al menos una vez");
                Console.WriteLine("5 - Dado el nombre de una selección obtener el partido con más cantidad de goles en que haya participado");
                Console.WriteLine("6 - Listar todos los jugadores que hayan convertido al menos 1 gol en un partido");
                Console.WriteLine("0 - Salir");

                op = Int32.Parse(Console.ReadLine());

                switch (op)
                {
                    case 1:
                        Console.WriteLine("Ingrese nombre");
                        string nombre = Console.ReadLine();

                        Console.WriteLine("Ingrese apellido");
                        string apellido = Console.ReadLine();

                        Console.WriteLine("Ingrese email");
                        string email = Console.ReadLine();

                        Console.WriteLine("Ingrese contraseña");
                        string contraseña = Console.ReadLine();

                        Periodista nuevo = new Periodista(nombre, apellido, email, contraseña);
                        try
                        {
                            s.AltaUsuario(nuevo);
                            Console.WriteLine("Alta exitosa");
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        break;
                    case 2:
                        Console.WriteLine("Ingrese monto");
                        double monto = Double.Parse(Console.ReadLine());

                        foreach(Jugador j in s.GetJugadores())
                        {
                            j.CambiarValorMonto(monto);
                        }
                        if (monto > 0)
                        {
                            Console.WriteLine("Cambio exitoso");
                        }
                        else
                        {
                            Console.WriteLine("Error");
                        }
                        break;
                    case 3:
                        Console.WriteLine("Ingrese el id del jugador");
                        int id = Int32.Parse(Console.ReadLine());

                        if (s.GetPartidosJugador(id).Count == 0)
                        {
                            Console.WriteLine("No hay registro");
                        }
                        else
                        {
                            foreach (Partido p in s.GetPartidosJugador(id))
                            {
                                Console.WriteLine(p.ToString());
                            }
                        }
                        break;
                    case 4:

                        if (s.GetJugadoresExpulsados().Count == 0)
                        {
                            Console.WriteLine("No hay registros");
                        }
                        else
                        {
                            foreach (Jugador j in s.GetJugadoresExpulsados())
                            {
                                Console.WriteLine(j.ToString());
                            }
                        }
                        break;
                    case 5:
                        Console.WriteLine("Ingrese selección");
                        string seleccion = Console.ReadLine();

                        if (s.GetPartidoConMasGoles(seleccion).Count == 0)
                        {
                            Console.WriteLine("No hay registros");
                        }
                        else
                        {
                            foreach (Partido p in s.GetPartidoConMasGoles(seleccion))
                            {
                                Console.WriteLine(p.ToString());
                            }
                        }
                        break;

                    case 6:
                        if (s.GetJugadoresConGol().Count == 0)
                        {
                            Console.WriteLine("No hay registros");
                        }
                        else
                        {
                            foreach (Jugador j in s.GetJugadoresConGol())
                            {
                                Console.WriteLine(j.ToString());
                            }
                        }
                        break;
                }
                Console.ReadKey();
            }
        }
    }
}
