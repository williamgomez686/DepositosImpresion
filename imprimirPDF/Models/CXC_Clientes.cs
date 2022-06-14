using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace imprimirPDF.Models
{
    public class CXC_Clientes : mmc
    {
        [Display(Name = "Codigo")]
        public string CODIGO { get; set; }
        [Display(Name = "Razon")]
        public string RAZON { get; set; }
        [Display(Name = "Nombres")]
        public string NOMBRE { get; set; }
        [Display(Name = "Teléfono Celular")]
        public string CELULAR { get; set; }
        [Display(Name = "Teléfono Casa")]
        public string CASA { get; set; }
        [Display(Name = "Otro Teléfono")]
        public string OTRO { get; set; }
        [Display(Name = "NIT")]
        public string NIT { get; set; }
        [Display(Name = "Correo Electronico")]
        public string EMAIL { get; set; }
        [Display(Name = "Estatus")]
        public string ESTATUS { get; set; }
        [Display(Name = "Estado Civil")]
        public string ESTADOCIVIL { get; set; }
        [Display(Name = "DPI")]
        public string DPI_POSIBLE { get; set; }
        [Display(Name = "Genero")]
        public string GENERO { get; set; }
        [Display(Name = "Nombre del Padre")]
        public string PADRE { get; set; }
        [Display(Name = "Nombre de la Madre")]
        public string MADRE { get; set; }
        [Display(Name = "Nombre del cónyuge")]
        public string CONYUGE { get; set; }
        [Display(Name = "Pertenece a Iglesia")]
        public string PERTENECEIGLESIA { get; set; }
        [Display(Name = "Codigo Miembro")]
        public string CODIGOMIEBRO { get; set; }
        public string PROFCOD { get; set; }
        [Display(Name = "Direccion")]
        public string DIRECCION { get; set; }
        public string CODDEPTO { get; set; }
        public string CODMUN { get; set; }
        public string ZONA { get; set; }
        public string CLISOCHON { get; set; }
        [Display(Name = "Fecha Nacimiento")]
        public DateTime FechaNacimiento { get; set; }
        public IEnumerable<CXC_Captaciones> Promesas { get; set; }
    }
}
