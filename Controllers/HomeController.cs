using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Titan.Models;

namespace Titan.Controllers
{
    public class HomeController : Controller
    {
        public static string Tipo = "admin";

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login(string tipo)
        {

            Tipo = tipo;
            if (Tipo.Equals("admin"))
            {
                return View("IndexAdmin");
            }
            else if (Tipo.Equals("vendedor"))
            {
                return View("IndexVendedor");
            }

            return View("Index");

        }

        [HttpGet]
        public IActionResult GetContador() {

            /*PEGA INFOS DO BANCO DO CONTADOR*/

            /*CRIA MODELO*/

            return View();

        }

        [HttpGet]
        public IActionResult GetCalor()
        {

            /*PEGA INFOS DO BANCO DO CONTADOR*/

            /*CRIA MODELO*/

            return View();

        }

        [HttpGet]
        public IActionResult GetSatisfacao()
        {

            /*PEGA INFOS DO BANCO DO CONTADOR*/

            /*CRIA MODELO*/

            return View();

        }





    }
}
