using imprimirPDF.CapaNegocio;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace imprimirPDF.Controllers
{
    public class PromesasController : Controller
    {
        public IActionResult Index()
        {
            var result = PromesaServicio.Instancia.GetAll();
           
            return View();
        }

        public IActionResult ClientesXPromesa()
        {
            var result = PromesaServicio.Instancia.ClinetesById("380777");
            var hola = result;
            return View(hola);
        }
    }
}
