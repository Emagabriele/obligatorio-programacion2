using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio;

namespace WebApplication.Controllers
{
    public class UsuarioController : Controller
    {
        private Sistema s = Sistema.GetInstancia();
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(Periodista p)
        {
            try
            {
                s.AltaUsuario(p);
                ViewBag.msg = "Alta Correcta";
                return RedirectToAction("Index","Home");
            }
            catch (Exception e)
            {
                ViewBag.msg = "Error: " + e.Message;
            }
            return View();
        }
    }
}
