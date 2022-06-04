using System;
using System.ComponentModel.DataAnnotations;

namespace imprimirPDF.Models
{
    public class mmc
    {
        [Display(Name = "Pais")]
        public string PaiCod { get; set; }//pais
        [Display(Name = "Empresa")]
        public string EmpCod { get; set; }//Empresa
        [Display(Name = "Fecha Alta")]
        [DataType(DataType.Date)]
        public DateTime FechAlt { get; set; }// Fecha de alta
        [Display(Name = "Fecha Modificacion")]
        public DateTime FechMod { get; set; }// Fecha de Modificacion
        [Display(Name = "Usuario Alta")]
        public string UsuAlt { get; set; }// Usuario de alta
        [Display(Name = "Usuario Modifica")]
        public string UsuMod { get; set; }// usuario que modifica
    }
}
