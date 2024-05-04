using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.Models;
using Dominio;
using Microsoft.AspNetCore.Http;

namespace WebApplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private Sistema s = Sistema.GetInstancia();

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string email, string password)
        {
            Usuario logueada = s.Login(email, password);

            if (logueada != null)
            {
                HttpContext.Session.SetInt32("LogueadoId", logueada.Id);
                HttpContext.Session.SetString("LogueadoRol", logueada.GetRol());
                if(HttpContext.Session.GetString("LogueadoRol") == "Operador")
                {
                    return RedirectToAction("Index", "Operador");
                }
                return RedirectToAction("Index", "Periodista");
            }
            else
            {
                ViewBag.msg = "Error en los datos";
            }

            return View();
        }

        public IActionResult Selecciones()
        {
            return View(s.GetSeleccionesOrdenadas());
        }
        public IActionResult Jugadores(int id)
        {

            List<Jugador> j = s.GetJugadoresDe(id);
            return View(j);
        }
        public IActionResult AccesoDenegado()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
