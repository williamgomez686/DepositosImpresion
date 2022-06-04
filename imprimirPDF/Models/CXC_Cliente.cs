using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace imprimirPDF.Models
{
    public class CXC_Cliente : mmc
    {
        public string CliCod { get; set; }
        public string CliRazSoc { get; set; }
        public string CliNit { get; set; }
        public string CliDirFac { get; set; }
        public DateTime CliFecAlt { get; set; }
        public string CliUsuAlt { get; set; }
        public string CliEst { get; set; }
        public string CliNom { get; set; }
    }
}
