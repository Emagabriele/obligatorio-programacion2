using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio;
using Microsoft.AspNetCore.Http;

namespace WebApplication.Controllers
{
    public class PeriodistaController : Controller
    {
        private Sistema s = Sistema.GetInstancia();
        public IActionResult Index()
        {
            if (HttpContext.Session.GetInt32("LogueadoId") != null)
            {
                if (HttpContext.Session.GetString("LogueadoRol") == "Periodista")
                {
                    return View();
                }
            }
            return RedirectToAction("AccesoDenegado", "Home");
        }

        public IActionResult PartidosCerrados()
        {
            if (HttpContext.Session.GetInt32("LogueadoId") != null)
            {
                if (HttpContext.Session.GetString("LogueadoRol") == "Periodista")
                {
                    return View(s.GetPartidosCerrados());
                }
            }
            return RedirectToAction("AccesoDenegado", "Home");
        }
        public IActionResult Reseña(int id)
        {
            if (HttpContext.Session.GetInt32("LogueadoId") != null)
            {
                if (HttpContext.Session.GetString("LogueadoRol") == "Periodista")
                {
                    ViewBag.idPartido = id;
                    return View(s.GetPartido(id));
                }
            }
            return RedirectToAction("AccesoDenegado", "Home");
        }

        [HttpPost]
        public IActionResult Reseña(Reseña r, int idPartido)
        {
            if (HttpContext.Session.GetInt32("LogueadoId") != null)
            {
                if (HttpContext.Session.GetString("LogueadoRol") == "Periodista")
                {
                    try
                    {
                        int? idL = HttpContext.Session.GetInt32("LogueadoId");
                        r.Periodista = s.GetPeriodista(idL);
                        r.Partido = s.GetPartido(idPartido);
                        r.Fecha = DateTime.Now;
                        s.AltaReseña(r);
                        ViewBag.msg = "Reseña exitosa";
                    }
                    catch (Exception e)
                    {
                        ViewBag.msg = "Error: " + e.Message;
                    }
                    return View(s.GetPartido(idPartido));
                }
            }
            return RedirectToAction("AccesoDenegado", "Home");
        }

        public IActionResult VerReseñas()
        {
            if (HttpContext.Session.GetInt32("LogueadoId") != null)
            {
                if (HttpContext.Session.GetString("LogueadoRol") == "Periodista")
                {
                    int? id = HttpContext.Session.GetInt32("LogueadoId");
                    return View(s.GetReseñasRealizo(id));
                }
            }
            return RedirectToAction("AccesoDenegado", "Home");
        }

    }
}
