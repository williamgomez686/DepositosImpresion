using imprimirPDF.common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using imprimirPDF.Models;
using imprimirPDF.CapaNegocio;
using Rotativa.AspNetCore;
using Rotativa.AspNetCore.Options;

namespace imprimirPDF.Controllers
{
    public class DepositosController : Controller
    {
        // GET: DepositosController
        public ActionResult Index()
        {
            var servicios = new DepositosServicios();
            var test = servicios.Todos();

            return View(test);
        }
        // GET: DepositosController/Details/5
        public ActionResult Details(int id)
        {
            var servicios = new DepositosServicios();
            var test = servicios.DepositosPorId(id);

            return View(test);
        }
        public IActionResult ListaDepositos()
        {
            return View();
        }
        public IActionResult ListaDepositosImprimir(long id)
        {
            var servicios = new DepositosServicios();
            var result = servicios.ObtenerLiquidacion(id);
            return View(result);
        }
        public IActionResult ImprimirPDF(long id)
        {
            var servicios = new DepositosServicios();
            var result = servicios.ObtenerLiquidacion(id);

           //return View(result.OrderByDescending(n => n.Numero));

            return new ViewAsPdf("ImprimirPDF", result)
            {
                FileName = "Liq_" + id + DateTime.Now + ".pdf",
                PageOrientation = Rotativa.AspNetCore.Options.Orientation.Portrait,
                PageSize = Rotativa.AspNetCore.Options.Size.Legal,
                PageMargins = new Margins(0, 0, 0, 0),
                //CustomSwitches = "--page-offset 0 --footer-center [page] --footer-font-size 9",
                PageWidth = 165,
                PageHeight = 93
            };
        }

        public IActionResult GetAllDepositos()
        {
            var servicios = new DepositosServicios();
            var result = servicios.GetAll();
            return View(result);
        }
    }
}
