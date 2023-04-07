using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//
using System.ComponentModel.DataAnnotations;

namespace CL3_POOII_JosueDanielChupicaInga.Models
{
    public class Matricula
    {
        [Display(Name = "Id del Alumno", Order = 0)]
        public string IdAlum { get; set; }

        [Display(Name = "Apellidos", Order = 1)]
        public string ApeAlum { get; set; }

        [Display(Name = "Nombres", Order = 2)]
        public string NomAlum { get; set; }

        [Display(Name = "Direccion", Order = 3)]
        public string DirAlum { get; set; }

        [Display(Name = "Telefono", Order = 4)]
        public string TelAlum { get; set; }

        [Display(Name = "Email", Order = 5)]
        public string EmailAlum { get; set; }

        [Display(Name = "Clave", Order = 6)]
        public string ClavelAlum { get; set; }
    }
}