using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Titan.Models;
using Titan.Services;

namespace Titan.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login(string tipo)
        {
            if (tipo.Equals("admin"))
            {
                return View("IndexAdmin");
            }
            else if (tipo.Equals("vendedor"))
            {
                return View("IndexVendedor");
            }

            return View("Index");

        }

        public IActionResult Mensagem()
        {
            return View();
        }

        public IActionResult EnviaMensagem(string mensagem)
        {
            if (mensagem != null)
            {
                Email.EnviaEmail(mensagem);
            }

            return View("Mensagem");
        }

    }
}
