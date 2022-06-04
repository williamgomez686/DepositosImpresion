using System;

namespace imprimirPDF.Models
{
    public class Fac_Factura_Detalle : mmc
    {
        public string TieCod { get; set; }//Codigo de la Tienda
        public string CajCod { get; set; }//Codigo de Cajero
        public int FacNotx { get; set; }//Notx
        public int FacNoLin { get; set; }//numero de linea
        public string ArtCod { get; set; }//Codigo del articulo
        public string CodSubPro1 { get; set; }//
        public string CodSubPro2 { get; set; }
        public int FacCanFac { get; set; }//Cantidad Facturada
        public decimal FacPreFac { get; set; }//Precio++++++++++++
        public decimal FacCosFac { get; set; }//Costo
        public string FacEstLin { get; set; }//Estado de la Linea (A/N)
        public string FacEsc { get; set; }//Escaneado (si/no)
        public string FacEstOfe { get; set; }//estado oferta (S/N)
        public string FacArtDes { get; set; }//Articulo despachado (S/N/P)
        public int FacCantDes { get; set; }//Cantidad de articulo++++++++++++
        public int FacDes { get; set; }//Descuento
        public decimal FacPorDesc { get; set; }// % de descuento
        public string FacTipVen { get; set; }// Tipo de venta
        public decimal FacMonIVA { get; set; }// Monto Con IVA
        public decimal FacMonSinIVA { get; set; }// Monto sin IVA
        public string FacObsDet { get; set; }//Observaciones 
        public Inv_Articulo Articulo { get; set; }//referencia al articulo
        public DateTime FacFecAlt { get; set; }//Fecha de Alta       
    }
}
