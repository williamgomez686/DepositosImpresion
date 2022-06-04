using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace imprimirPDF.Models
{
    public class Fac_Factura : mmc
    {
        [Display(Name = "Tienda")]
        public string TieCod { get; set; }//Codigo de la Tienda
        [Display(Name = "Caja")]
        public string CajCod { get; set; }//Codigo de Cajero
        [Display(Name = "NOTX")]
        public int FacNotx { get; set; }//Notx
        public string TtrCod { get; set; }
        public string VenCod { get; set; }
        [Display(Name = "Cod Cliente")]
        public string CliCod { get; set; }//Codigo del cliente o NIT    
        public IEnumerable<Fac_Factura_Detalle> detalle { get; set; } // datos de prueba
        [Display(Name = "Nombre")]
        public string FacANomDe { get; set; }// a nombre de
        [Display(Name = "NIT")]
        public string FacANit { get; set; }//NIT
        [Display(Name = "Dirreccion")]
        public string FacDirFac { get; set; }//Direccion de la factura
        public string FacDirRent { get; set; }
        [Display(Name = "Estado")]
        public string FacEst { get; set; }//estado de la factura
        [Display(Name = "Observaciones")]
        public string FacObs { get; set; }//observaciones
        [Display(Name = "IVA")]
        public int FacIva { get; set; }// monto de IVA
        public int FacTasCam { get; set; }
        [Display(Name = "Serie")]
        public string FacSer { get; set; }//Serie de la Factura
        [Display(Name = "Numero")]
        public int FacNum { get; set; }//Numero de la factura
        [Display(Name = "Total")]
        public decimal FacToFac { get; set; }// el total de la factura posiblemente
        public int FacToDes { get; set; }
        //public string FacUsuAlt { get; set; }
        public string FacHoraAlt { get; set; }
        //public CXC_CLIENTES CliCodId { get; set; }

        public Fac_Factura()
        {
            detalle = new List<Fac_Factura_Detalle>();
        }
    }
}
