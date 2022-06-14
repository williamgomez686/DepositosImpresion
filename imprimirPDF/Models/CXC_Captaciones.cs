using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace imprimirPDF.Models
{
    public class CXC_Captaciones:mmc
    {
        public long PROMESA { get; set; }
        public string TIPCAPCOD { get; set; }
        [Display(Name = "Fecha")]
        public DateTime FECHAPROMESA { get; set; }
        [Display(Name = "Codigo del cliente")]
        public string CLICOD { get; set; }
        public string CAPTIPOFR { get; set; }
        public string CAPHORALR { get; set; }
        [Display(Name = "Nombres")]
        public string NOMBRES { get; set; }
        public string CAPSTARUT { get; set; }
        [Display(Name = "Estado")]
        public string ESTATUS { get; set; }
        public string CAPTIPPAG { get; set; }
        public string CAPORIGEN { get; set; }

    }
}
