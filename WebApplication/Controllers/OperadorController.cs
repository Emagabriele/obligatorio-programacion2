using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio;
using Microsoft.AspNetCore.Http;

namespace WebApplication.Controllers
{
    public class OperadorController : Controller
    {
        private Sistema s = Sistema.GetInstancia();
        public IActionResult Index()
        {
            if (HttpContext.Session.GetInt32("LogueadoId") != null)
            {
                if (HttpContext.Session.GetString("LogueadoRol") == "Operador")
                {
                    return View();
                }
            }
            return RedirectToAction("AccesoDenegado", "Home");
        }
        public IActionResult Partidos()
        {
            if (HttpContext.Session.GetInt32("LogueadoId") != null)
            {
                if (HttpContext.Session.GetString("LogueadoRol") == "Operador")
                {
                    return View(s.GetPartidos());
                }
            }
            return RedirectToAction("AccesoDenegado", "Home");
        }

        public IActionResult Finalizar(int id)
        {
            if (HttpContext.Session.GetInt32("LogueadoId") != null)
            {
                if (HttpContext.Session.GetString("LogueadoRol") == "Operador")
                {
                    Partido p = s.GetPartido(id);
                    p.CierrePartido();
                    return RedirectToAction("Partidos", "Operador");
                }
            }
            return RedirectToAction("AccesoDenegado", "Home");
        }

        public IActionResult EstadisticasFaseGrupo(int id)
        {
            if (HttpContext.Session.GetInt32("LogueadoId") != null)
            {
                if (HttpContext.Session.GetString("LogueadoRol") == "Operador")
                {
                    return View(s.GetPartido(id));
                }
            }
            return RedirectToAction("AccesoDenegado", "Home");
        }

        public IActionResult EstadisticasFaseEliminatoria(int id)
        {
            if (HttpContext.Session.GetInt32("LogueadoId") != null)
            {
                if (HttpContext.Session.GetString("LogueadoRol") == "Operador")
                {
                    return View(s.GetPartido(id));
                }
            }
            return RedirectToAction("AccesoDenegado", "Home");
        }

        public IActionResult SeleccionUno(int id)
        {
            if (HttpContext.Session.GetInt32("LogueadoId") != null)
            {
                if (HttpContext.Session.GetString("LogueadoRol") == "Operador")
                {
                    return View(s.GetPartido(id));
                }
            }
            return RedirectToAction("AccesoDenegado", "Home");
        }
        public IActionResult SeleccionDos(int id)
        {
            if (HttpContext.Session.GetInt32("LogueadoId") != null)
            {
                if (HttpContext.Session.GetString("LogueadoRol") == "Operador")
                {
                    return View(s.GetPartido(id));
                }
            }
            return RedirectToAction("AccesoDenegado", "Home");
        }

        public IActionResult Goles(int id, int idP)
        {
            if (HttpContext.Session.GetInt32("LogueadoId") != null)
            {
                if (HttpContext.Session.GetString("LogueadoRol") == "Operador")
                {
                    return View(s.GetIncidenciasDado(id, idP));
                }
            }
            return RedirectToAction("AccesoDenegado", "Home");
        }
        public IActionResult Amarillas(int id, int idP)
        {
            if (HttpContext.Session.GetInt32("LogueadoId") != null)
            {
                if (HttpContext.Session.GetString("LogueadoRol") == "Operador")
                {
                    return View(s.GetIncidenciasDado(id, idP));
                }
            }
            return RedirectToAction("AccesoDenegado", "Home");
        }
        public IActionResult Rojas(int id, int idP)
        {
            if (HttpContext.Session.GetInt32("LogueadoId") != null)
            {
                if (HttpContext.Session.GetString("LogueadoRol") == "Operador")
                {
                    return View(s.GetIncidenciasDado(id, idP));
                }
            }
            return RedirectToAction("AccesoDenegado", "Home");
        }
        public IActionResult Fechas()
        {
            if (HttpContext.Session.GetInt32("LogueadoId") != null)
            {
                if (HttpContext.Session.GetString("LogueadoRol") == "Operador")
                {
                    return View();
                }
            }
            return RedirectToAction("AccesoDenegado", "Home");
        }
        public IActionResult PartidoEntreFechas(DateTime fecha1, DateTime fecha2)
        {
            if (HttpContext.Session.GetInt32("LogueadoId") != null)
            {
                if (HttpContext.Session.GetString("LogueadoRol") == "Operador")
                {
                    return View(s.GetPartidoEntreFechas(fecha1, fecha2));
                }
            }
            return RedirectToAction("AccesoDenegado", "Home");
        }
        public IActionResult IncidenciasSeleccionUno(int id)
        {
            if (HttpContext.Session.GetInt32("LogueadoId") != null)
            {
                if (HttpContext.Session.GetString("LogueadoRol") == "Operador")
                {
                    return View(s.GetPartido(id));
                }
            }
            return RedirectToAction("AccesoDenegado", "Home");
        }

        public IActionResult IncidenciasSeleccionDos(int id)
        {
            if (HttpContext.Session.GetInt32("LogueadoId") != null)
            {
                if (HttpContext.Session.GetString("LogueadoRol") == "Operador")
                {
                    return View(s.GetPartido(id));
                }
            }
            return RedirectToAction("AccesoDenegado", "Home");
        }

        public IActionResult Periodistas()
        {
            if (HttpContext.Session.GetInt32("LogueadoId") != null)
            {
                if (HttpContext.Session.GetString("LogueadoRol") == "Operador")
                {
                    return View(s.GetPeriodistasOrdenados());
                }
            }
            return RedirectToAction("AccesoDenegado", "Home");
        }

        public IActionResult Reseñas(int id)
        {
            if (HttpContext.Session.GetInt32("LogueadoId") != null)
            {
                if (HttpContext.Session.GetString("LogueadoRol") == "Operador")
                {
                    return View(s.GetReseñasPeriodistaDado(id));
                }
            }
            return RedirectToAction("AccesoDenegado", "Home");
        }
        public IActionResult Email()
        {
            if (HttpContext.Session.GetInt32("LogueadoId") != null)
            {
                if (HttpContext.Session.GetString("LogueadoRol") == "Operador")
                {
                    return View();
                }
            }
            return RedirectToAction("AccesoDenegado", "Home");
        }

        public IActionResult ReseñasConRoja(string email)
        {
            if (HttpContext.Session.GetInt32("LogueadoId") != null)
            {
                if (HttpContext.Session.GetString("LogueadoRol") == "Operador")
                {
                    return View(s.GetReseñasConRoja(email));
                }
            }
            return RedirectToAction("AccesoDenegado", "Home");
        }

        public IActionResult SeleccionesConMasGoles()
        {
            if (HttpContext.Session.GetInt32("LogueadoId") != null)
            {
                if (HttpContext.Session.GetString("LogueadoRol") == "Operador")
                {
                    return View(s.GetSeleccionesGoleadoras());
                }
            }
            return RedirectToAction("AccesoDenegado", "Home");
        }

    }
}
