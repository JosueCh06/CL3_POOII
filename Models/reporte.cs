using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//
using System.ComponentModel.DataAnnotations;

namespace CL3_POOII_JosueDanielChupicaInga.Models
{
    public class reporte
    {
        [Display(Name = "IdAlumno", Order = 0)]
        public string idAlum { get; set; }

        [Display(Name = "ApeAlumno", Order = 1)]
        public string ApeAlum { get; set; }

        [Display(Name = "NomAlumno", Order = 2)]
        public string NombAlum { get; set; }

        [Display(Name = "ExaParcial", Order = 3)]
        public decimal ExParcial { get; set; }

        [Display(Name = "ExaFinal", Order = 4)]
        public decimal ExFinal { get; set; }

        [Display(Name = "Promedio", Order = 5)]
        public decimal Prom { get; set; }
    }
}