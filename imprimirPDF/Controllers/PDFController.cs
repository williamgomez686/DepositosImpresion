using imprimirPDF.CapaNegocio;
using imprimirPDF.Models;
using imprimirPDF.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Rotativa.AspNetCore;
using Rotativa.AspNetCore.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace imprimirPDF.Controllers
{
    public class PDFController : Controller
    {
        public IActionResult Index()
        {
            List<FacturaViewModel> verFactura = Factura.Instancia.Listar();
            return View(verFactura);

        }

        public IActionResult ImprimirPDF()
        {
            //DateTime fechahoy;
            List<FacturaViewModel> verFactura = Factura.Instancia.Listar();
            //fechahoy = DateTime.Now;
                return new ViewAsPdf("ImprimirPDF", verFactura)
                {
                    FileName = "Factura_" + DateTime.Now + ".pdf",
                    PageOrientation = Rotativa.AspNetCore.Options.Orientation.Portrait,
                    PageSize = Rotativa.AspNetCore.Options.Size.A4,
                    PageMargins = new Margins(0, 0, 0, 0),
                    CustomSwitches = "--page-offset 0 --footer-center [page] --footer-font-size 12",
                    PageWidth = 210,
                    PageHeight = 280
                };
        }


        public IActionResult JSPrint()
        {
            return View();
        }
        public IActionResult detalle()
        {
            return View();
        }

        public IActionResult pruebas()
        {
            return View();
        }

        public JsonResult test()
        {
            var oVerFactura = new FacturaServicios();
            var result = oVerFactura.verFactura(128241);
            return Json(result);
        }
        [HttpGet]
        public JsonResult detalleJson(int id)
        {
            var oVerFactura = new FacturaServicios();
            var result = oVerFactura.verFactura(115866);
            return Json(result);
        }

        public IActionResult VerFac_Factura()
        {
            var oVerFac_Factura = new FacturaServicios();
            var oMuestra = oVerFac_Factura.ListaFacturas();
             
            return View(oMuestra);
        }
    }
}
