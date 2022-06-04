using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace imprimirPDF.Models
{
    public class Depositos: mmc
    {
        [Display(Name ="Codigo")]
        public string clicod { get; set; }
        public String Serie { get; set; }
        public int Numero { get; set; }
        [Display(Name = "Fecha")]
        public DateTime FechaAlta { get; set; }
        [Display(Name = "Nombre")]
        public String ClienteRazon { get; set; }
        [Display(Name = "Cantidad")]
        public double Monto { get; set; }
        [Display(Name = "No. Liquidacion")]
        public long NumeroLiquidacion { get; set; }
        [Display(Name = "En Letras")]
        public String MontoLetras { get; set; }
        [Display(Name = "No Promesa")]
        public long NumeroPromesa { get; set; }
    }
}
